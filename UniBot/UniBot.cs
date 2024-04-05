using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using UniBot.Model;
using UniBot.Receiver;
using Websocket.Client;
using Fleck;
using UniBot.Tools;

namespace UniBot
{
    /// <summary>
    /// 主函数
    /// </summary>
    public class Bot
    {
        #region 全局变量/构造函数
        private WebsocketClient? _client;
        public ConnectConf Conn;

        /// <summary>
        /// 收到事件
        /// </summary>
        public IObservable<MessageReceiverBase> EventReceived { get; }
        private readonly Subject<MessageReceiverBase> _eventReceivedSubject = new();
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
        public Bot(ConnectConf conf)
        {
            Conn = conf;
            EventReceived = _eventReceivedSubject.AsObservable();
            MessageReceived = _messageReceivedSubject.AsObservable();
            UnknownMessageReceived = _unknownMessageReceived.AsObservable();
            DisconnectionHappened = _disconnectionHappened.AsObservable();
        }
        #endregion

        public async Task StartAsync()
        {
            await Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task Init()
        {
            try
            {
                if (!Conn.WsReverse)
                {
                    var clientFactory = new Func<Uri, CancellationToken, Task<WebSocket>>(async (uri, cancellationToken) =>
                    {
                        var client = new ClientWebSocket();
                        if (!string.IsNullOrWhiteSpace(Conn.Token))
                            client.Options.SetRequestHeader("authorization", "Bearer " + Conn.Token);
                        await client.ConnectAsync(uri, cancellationToken).ConfigureAwait(false);
                        return client;
                    });
                    var url = new Uri(Conn.WsUrl);
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
                            HandleData(data);
                        });
                }
                if (Conn.WsReverse)
                {
                    var server = new WebSocketServer(Conn.ReverseWsUrl);
                    server.Start(socket =>
                    {
                        socket.OnMessage = message =>
                        {
                            var token = socket.ConnectionInfo;
                            HandleData(message);
                        };
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 消息数据处理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public void HandleData(string data)
        {
            try
            {
                var msg = JsonConvertTool.MessageReceiverHandel(data, Conn) ?? throw new InvalidDataException("数据无效！");
                if (msg.PostType == PostType.Message)
                    _messageReceivedSubject.OnNext(msg);
                else if (msg.PostType == PostType.Notice || msg.PostType == PostType.Request || msg.PostType == PostType.MetaEvent)
                    _eventReceivedSubject.OnNext(msg);
                else
                    _unknownMessageReceived.OnNext(data);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
