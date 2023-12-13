using System.Reactive.Linq;
using System.Reactive.Subjects;
using Websocket.Client;
using Manganese.Text;
using System.Net.WebSockets;
using ShamrockCore.Reciver;
using ShamrockCore.Utils;
using ShamrockCore.Reciver.Receivers;
using ShamrockCore.Reciver.Events;

namespace ShamrockCore
{
    /// <summary>
    /// 机器人对象
    /// </summary>
    public class Bot : IDisposable
    {
        public static Bot? Instance { get; set; }
        private WebsocketClient? _client;
        private bool disposedValue;
        private readonly ConnectConfig _connectConfig;

        public Bot(ConnectConfig config)
        {
            Instance?.Dispose();
            _connectConfig = config;
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns></returns>
        public ConnectConfig GetConfig()
        {
            return _connectConfig;
        }

        /// <summary>
        /// 启动机器人
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            Instance = this;
            await StartWebsocket();
        }

        /// <summary>
        /// 启动websocket
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidWebsocketReponseException"></exception>
        private async Task StartWebsocket()
        {
            var clientFactory = new Func<Uri, CancellationToken, Task<WebSocket>>(async (uri, cancellationToken) =>
            {
                var client = new ClientWebSocket();
                if (!string.IsNullOrWhiteSpace(_connectConfig.Token))
                    client.Options.SetRequestHeader("authorization", "Bearer " + _connectConfig.Token);
                await client.ConnectAsync(uri, cancellationToken).ConfigureAwait(false);
                return client;
            });
            var url = new Uri($"ws://{_connectConfig.Host}:{_connectConfig.WsPort}");
            _client = new WebsocketClient(url, null, clientFactory)
            {
                IsReconnectionEnabled = false,
            };
            await _client.StartOrFail();
            _client.DisconnectionHappened
                .Subscribe(x =>
                {
                    _disconnectionHappened.OnNext(x.CloseStatus ?? WebSocketCloseStatus.Empty);
                });

            _client.MessageReceived
                .Where(message => message.MessageType == WebSocketMessageType.Text)
                .Subscribe(message =>
                {
                    var data = message?.Text;
                    if (string.IsNullOrWhiteSpace(data))
                        throw new Exception("Websocket数据响应错误！");
                    ProcessWebSocketData(data);
                });
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="Exception"></exception>
        private void ProcessWebSocketData(string data)
        {
            var postType = data.Fetch("post_type");
            if (string.IsNullOrWhiteSpace(postType))
                throw new Exception("Websocket数据响应错误！");
            else if (postType == "meta_event")
            {
                var isHeart = data.Fetch(postType+"_type");
                if (!string.IsNullOrWhiteSpace(isHeart) && isHeart == "heartbeat")
                    return;
            }
            else if (postType == "message")
            {
                //群
                if (data.Fetch(postType + "_type") == "group")
                    _messageReceivedSubject.OnNext(data.ToObject<GroupReceiver>());
                //私聊
                if (data.Fetch(postType + "_type") == "private")
                    //好友
                    if (data.Fetch("sub_type") == "friend")
                        _messageReceivedSubject.OnNext(data.ToObject<FriendReceiver>());
            }
            //事件通知
            else if (postType == "notice")
            {
                //添加好友请求
                if (data.Fetch(postType + "_type") == "friend_add")
                    _messageReceivedSubject.OnNext(data.ToObject<FriendAddEvent>());
                //群成员增加事件
                if (data.Fetch(postType + "_type") == "group_increase")
                    _messageReceivedSubject.OnNext(data.ToObject<GroupIncreaseEvent>());
                //群成员减少事件
                if (data.Fetch(postType + "_type") == "group_increase")
                    _messageReceivedSubject.OnNext(data.ToObject<GroupDecreaseEvent>());
            }
            else
                _unknownMessageReceived.OnNext(data);
        }

        /// <summary>
        /// 接收到事件
        /// </summary>
        public IObservable<MessageReceiverBase> EventReceived => _eventReceivedSubject.AsObservable();
        private readonly Subject<MessageReceiverBase> _eventReceivedSubject = new();

        /// <summary>
        /// 收到消息
        /// </summary>
        public IObservable<MessageReceiverBase> MessageReceived => _messageReceivedSubject.AsObservable();
        private readonly Subject<MessageReceiverBase> _messageReceivedSubject = new();

        /// <summary>
        /// 接收到未知类型的Websocket消息
        /// </summary>
        public IObservable<string> UnknownMessageReceived => _unknownMessageReceived.AsObservable();
        private readonly Subject<string> _unknownMessageReceived = new();

        /// <summary>
        /// Websocket断开连接
        /// </summary>
        public IObservable<WebSocketCloseStatus> DisconnectionHappened => _disconnectionHappened.AsObservable();
        private readonly Subject<WebSocketCloseStatus> _disconnectionHappened = new();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~Bot()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// 链接类
    /// </summary>
    /// <param name="host">主机地址</param>
    /// <param name="wsPort">websocket端口</param>
    /// <param name="httpPort">http端口</param>
    /// <param name="token">token</param>
    public class ConnectConfig(string host, int wsPort, int httpPort, string? token = null)
    {
        /// <summary>
        /// 主机地址
        /// </summary>
        public string Host { get; set; } = host;

        /// <summary>
        /// websocket端口
        /// </summary>
        public int WsPort { get; set; } = wsPort;

        /// <summary>
        /// http端口
        /// </summary>
        public int HttpPort { get; set; } = httpPort;

        /// <summary>
        /// token
        /// </summary>
        public string? Token { get; set; } = token;
    }
}
