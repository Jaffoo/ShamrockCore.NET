using System.Reactive.Linq;
using System.Reactive.Subjects;
using Websocket.Client;
using Manganese.Text;
using System.Net.WebSockets;
using ShamrockCore.Reciver;
using ShamrockCore.Utils;
using ShamrockCore.Reciver.Receivers;
using ShamrockCore.Reciver.Events;
using ShamrockCore.Data.Model;

namespace ShamrockCore
{
    /// <summary>
    /// 机器人对象
    /// </summary>
    public sealed partial class Bot : IDisposable
    {
        public static Bot? Instance { get; set; }
        private WebsocketClient? _client;

        public Bot(ConnectConfig config)
        {
            Instance?.Dispose();
            Config = config;
            EventReceived = _eventReceivedSubject.AsObservable();
            MessageReceived = _messageReceivedSubject.AsObservable();
            UnknownMessageReceived = _unknownMessageReceived.AsObservable();
            DisconnectionHappened = _disconnectionHappened.AsObservable();
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns></returns>
        public ConnectConfig Config { get; }

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
        /// <exception cref="InvalidDataException"></exception>
        private async Task StartWebsocket()
        {
            try
            {
                var clientFactory = new Func<Uri, CancellationToken, Task<WebSocket>>(async (uri, cancellationToken) =>
                {
                    var client = new ClientWebSocket();
                    if (!string.IsNullOrWhiteSpace(Config.Token))
                        client.Options.SetRequestHeader("authorization", "Bearer " + Config.Token);
                    await client.ConnectAsync(uri, cancellationToken).ConfigureAwait(false);
                    return client;
                });
                var url = new Uri($"ws://{Config.Host}:{Config.WsPort}");
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
                            throw new InvalidDataException("Websocket数据响应错误！");
                        ProcessWebSocketData(data);
                    });
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="data"></param>
        /// <exception cref="InvalidDataException"></exception>
        private void ProcessWebSocketData(string data)
        {
            try
            {
                var postType = data.Fetch("post_type");
                var type1 = data.Fetch(postType + "_type");

                if (string.IsNullOrWhiteSpace(postType))
                    throw new InvalidDataException("Websocket数据响应错误！");
                else if (postType == "meta_event")
                {
                    if (!string.IsNullOrWhiteSpace(type1) && type1 == "heartbeat")
                        return;
                }
                else if (postType == "message")
                {
                    //群
                    if (type1 == "group")
                        _messageReceivedSubject.OnNext(data.ToObject<GroupReceiver>());
                    //私聊
                    if (type1 == "private")
                        //好友
                        if (data.Fetch("sub_type") == "friend")
                            _messageReceivedSubject.OnNext(data.ToObject<FriendReceiver>());
                }
                //事件通知
                else if (postType == "notice")
                {
                    //添加好友请求
                    if (type1 == "friend_add")
                        _eventReceivedSubject.OnNext(data.ToObject<FriendAddEvent>());
                    //群成员增加事件
                    if (type1 == "group_increase")
                        _eventReceivedSubject.OnNext(data.ToObject<GroupIncreaseEvent>());
                    //群成员减少事件
                    if (type1 == "group_decrease")
                        _eventReceivedSubject.OnNext(data.ToObject<GroupDecreaseEvent>());
                }
                else
                    _unknownMessageReceived.OnNext(data);
                Console.WriteLine("原始数据：" + data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 接收到事件
        /// </summary>
        public IObservable<EventBase> EventReceived { get; }
        private readonly Subject<EventBase> _eventReceivedSubject = new();

        /// <summary>
        /// 收到消息
        /// </summary>
        public IObservable<MessageReceiverBase> MessageReceived { get; }
        private readonly Subject<MessageReceiverBase> _messageReceivedSubject = new();

        /// <summary>
        /// 接收到未知类型的Websocket消息
        /// </summary>
        public IObservable<string> UnknownMessageReceived { get; }
        private readonly Subject<string> _unknownMessageReceived = new();

        /// <summary>
        /// Websocket断开连接
        /// </summary>
        public IObservable<WebSocketCloseStatus> DisconnectionHappened { get; }
        private readonly Subject<WebSocketCloseStatus> _disconnectionHappened = new();

        public void Dispose()
        {
            OnDispose();
            _client?.Stop(WebSocketCloseStatus.NormalClosure, "ClientClosed");
            _client?.Dispose();
            _eventReceivedSubject.Dispose();
            _messageReceivedSubject.Dispose();
            _unknownMessageReceived.Dispose();
            _disconnectionHappened.Dispose();
        }

        partial void OnDispose();

        #region 接口
        /// <summary>
        /// 登录用户信息
        /// </summary>
        /// <param name="bot"></param>
        /// <returns></returns>
        public async Task<LoginInfo?> LoginInfo()
        {
            try
            {
                var res = await Extension.GetLoginInfo();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 群列表
        /// </summary>
        /// <param name="bot"></param>
        /// <returns></returns>
        public async Task<List<Group>?> Groups()
        {
            try
            {
                var res = await Extension.GetGroups();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // <summary>
        /// 好友列表
        /// </summary>
        /// <param name="bot"></param>
        /// <returns></returns>
        public async Task<List<Friend>?> Friends()
        {
            try
            {
                var res = await Extension.GetFriends();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }

    /// <summary>
    /// 连接类
    /// </summary>
    /// <param name="Host">主机地址</param>
    /// <param name="WsPort">websocket端口</param>
    /// <param name="HttpPort">http端口</param>
    /// <param name="Token">token</param>
    public record ConnectConfig(string Host, int WsPort, int HttpPort, string? Token = null)
    {
        /// <summary>
        /// 主机地址
        /// </summary>
        public string Host { get; set; } = Host;

        /// <summary>
        /// websocket端口
        /// </summary>
        public int WsPort { get; set; } = WsPort;

        /// <summary>
        /// http端口
        /// </summary>
        public int HttpPort { get; set; } = HttpPort;

        /// <summary>
        /// token
        /// </summary>
        public string? Token { get; set; } = Token;

        /// <summary>
        /// httpUrl
        /// </summary>
        public string HttpUrl => "http://" + Host + ":" + HttpPort + "/";

        /// <summary>
        /// wsUrl
        /// </summary>
        public string WsUrl => "ws://" + Host + ":" + WsPort + "/";
    }
}
