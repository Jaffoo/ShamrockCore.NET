using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using UniBot.Model;
using UniBot.Receiver;
using Websocket.Client;
using Fleck;
using UniBot.Tools;
using ShamrockCore.Data.HttpAPI;
using Newtonsoft.Json.Linq;
using UniBot.Message.Chain;
using TBC.CommonLib;

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

        #region 扩展方法/属性
        /// <summary>
        /// 好友列表
        /// </summary>
        public Lazy<List<FriendInfo>> Friends => new(() => Conn.GetFriendList().Result);

        /// <summary>
        /// 群列表
        /// </summary>
        public Lazy<List<GroupInfo>> Groups => new(() => Conn.GetGroupList().Result);

        /// <summary>
        /// onebot实现版本信息
        /// </summary>
        public Lazy<JObject> Version => new(() => Conn.GetVersion().Result);

        /// <summary>
        /// onebot实现状态信息
        /// </summary>
        public Lazy<JObject> Status => new(() => Conn.GetStatus().Result);

        /// <summary>
        /// 检查是否可以发送语音
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CanSendRecord() => await Conn.CanSendRecord();

        /// <summary>
        /// 检查是否可以发送图片
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CanSendImage() => await Conn.CanSendImage();

        /// <summary>
        /// 重启
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Restart(int delay = 0) => await Conn.Restart(delay);

        /// <summary>
        /// 清理缓存
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CleanCache() => await Conn.CleanCache();

        #region 发送消息
        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendPrivateMessage(long qq, MessageChain msg) => await Conn.SendPrivateMsg(qq, msg);

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendPrivateMessage(long qq, string msg) => await Conn.SendPrivateMsg(qq, msg);

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="friend"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendPrivateMessage(FriendInfo friend, MessageChain msg) => await Conn.SendPrivateMsg(friend.QQ, msg);

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="friend"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendPrivateMessage(FriendInfo friend, string msg) => await Conn.SendPrivateMsg(friend.QQ, msg);

        /// <summary>
        /// 发送群聊消息
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendGroupMessage(long groupQQ, MessageChain msg) => await Conn.SendGroupMsg(groupQQ, msg);

        /// <summary>
        /// 发送群聊消息
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendGroupMessage(long groupQQ, string msg) => await Conn.SendGroupMsg(groupQQ, msg);

        /// <summary>
        /// 发送群聊消息
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendGroupMessage(GroupInfo group, MessageChain msg) => await Conn.SendGroupMsg(group.GroupQQ, msg);

        /// <summary>
        /// 发送群聊消息
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendGroupMessage(GroupInfo group, string msg) => await Conn.SendGroupMsg(group.GroupQQ, msg);
        #endregion

        #region onebot实现的扩展api调用方法
        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="apiEndpoint">请求端点</param>
        /// <param name="paramStr">请求参数字符串（url格式拼接好）</param>
        /// <returns>json格式字符串</returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<string> GetAsync(string apiEndpoint, string paramStr = "")
        {
            try
            {
                var url = Conn.HttpUrl + apiEndpoint + paramStr;
                var res = await TBC.CommonLib.Tools.GetAsync<ApiResult>(url, Conn.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                return res.Data ?? "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// post请求
        /// </summary>d
        /// <param name="apiEndpoint">请求端点</param>
        /// <param name="data">请求body数据(json字符串)</param>
        /// <returns>json格式字符串</returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<string> PostAsync(string apiEndpoint, string data)
        {
            try
            {
                var url = Conn.HttpUrl + apiEndpoint;
                var res = await TBC.CommonLib.Tools.PostAsync<ApiResult>(url, data, Conn.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                return res.Data ?? "";
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #endregion
    }
}
