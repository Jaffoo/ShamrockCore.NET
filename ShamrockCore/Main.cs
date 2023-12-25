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
using ShamrockCore.Data.HttpAPI;

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
                var postType = data.Fetch("post_type")?.Trim();
                var type1 = data.Fetch(postType + "_type")?.Trim();

                if (string.IsNullOrWhiteSpace(postType))
                    throw new InvalidDataException("Websocket数据响应错误！");
                else if (postType == "meta_event")
                {
                    if (!string.IsNullOrWhiteSpace(type1) && type1 == "heartbeat")
                        return;
                }
                //消息事件
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
                //通知事件
                else if (postType == "notice")
                {
                    switch (type1)
                    {
                        //群成员增加事件
                        case "group_increase":
                            _eventReceivedSubject.OnNext(data.ToObject<GroupIncreaseEvent>());
                            break;
                        //群成员减少事件
                        case "group_decrease":
                            _eventReceivedSubject.OnNext(data.ToObject<GroupDecreaseEvent>());
                            break;
                        //私聊消息撤回
                        case "friend_recall":
                            _eventReceivedSubject.OnNext(data.ToObject<PrivateRecallEvent>());
                            break;
                        //群聊消息撤回
                        case "group_recall":
                            _eventReceivedSubject.OnNext(data.ToObject<GroupRecallEvent>());
                            break;
                        //群管理员变动
                        case "group_admin":
                            _eventReceivedSubject.OnNext(data.ToObject<AdminChangeEvent>());
                            break;
                        //群文件上传
                        case "group_upload":
                            _eventReceivedSubject.OnNext(data.ToObject<GroupFileUploadEvent>());
                            break;
                        //私聊文件上传
                        case "private_upload":
                            _eventReceivedSubject.OnNext(data.ToObject<PrivateFileUploadEvent>());
                            break;
                        //群禁言
                        case "group_ban":
                            _eventReceivedSubject.OnNext(data.ToObject<GroupBanEvent>());
                            break;
                        //群成员名片变动
                        case "group_card":
                            _eventReceivedSubject.OnNext(data.ToObject<MemberCardChangeEvent>());
                            break;
                        //精华消息
                        case "essence":
                            _eventReceivedSubject.OnNext(data.ToObject<EssenceEvent>());
                            break;
                        //系统通知
                        case "notify":
                            {
                                var subType = data.Fetch("sub_type");
                                //头像戳一戳
                                if (subType=="poke")
                                    _eventReceivedSubject.OnNext(data.ToObject<PokeEvent>());
                                //群头衔变更
                                if (subType== "title")
                                    _eventReceivedSubject.OnNext(data.ToObject<TitleChangeEvent>());
                            }
                            break;

                        default: break;
                    }
                }
                //请求事件
                else if (postType == "request")
                {
                    //添加好友请求
                    if (type1 == "friend")
                        _eventReceivedSubject.OnNext(data.ToObject<FriendAddEvent>());
                    //加群请求／邀请
                    if (type1 == "group")
                        _eventReceivedSubject.OnNext(data.ToObject<GroupAddEvent>());
                }
                else
                    _unknownMessageReceived.OnNext(data);
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
        public LoginInfo LoginInfo => Api.GetLoginInfo().Result ?? new();

        /// <summary>
        /// 群列表
        /// </summary>
        public IEnumerable<Group> Groups => Api.GetGroups().Result ?? Enumerable.Empty<Group>();

        // <summary>
        /// 好友列表
        /// </summary>
        public IEnumerable<Friend> Friends => Api.GetFriends().Result ?? Enumerable.Empty<Friend>();

        /// <summary>
        /// 手机电池信息
        /// </summary>
        public BatteryInfo Battery => Api.GetDeviceBattery().Result ?? new();

        /// <summary>
        /// shamrock启动时间
        /// </summary>
        public long StartTime => Api.GetStartTime().Result;

        /// <summary>
        /// 获取好友系统消息(未能正确获取到数据)
        /// </summary>
        /// <returns></returns>
        public List<FriendSysMsg>? FriendSysMsg => Api.GetFriendSysMsg().Result;

        // <summary>
        /// 是否在黑名单中
        /// </summary>
        /// <returns></returns>
        public async Task<IsInBack?> InBlack(long qq) => await Api.IsBlacklistUin(qq);

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="fileMd5">文件 MD5</param>
        /// <returns></returns>
        public async Task<Data.Model.FileInfo?> GetImage(string fileMd5) => await Api.GetImage(fileMd5);

        /// <summary>
        /// 获取语音(要使用此接口, 通常需要安装 ffmpeg, 请参考 OneBot 实现的相关说明)
        /// </summary>
        /// <param name="fileMd5">文件 MD5</param>
        /// <param name="OutFormat">输出格式(mp3、amr、wma、m4a、spx、ogg、wav、flac)</param>
        /// <returns></returns>
        public async Task<RecordInfo?> GetRecord(string fileMd5, string OutFormat = "mp3") => await Api.GetRecord(fileMd5, OutFormat);

        // <summary>
        /// 获取消息
        /// </summary>
        /// <returns></returns>
        public async Task<MsgInfo?> GetMsg(long messageId) => await Api.GetMsg(messageId);

        /// <summary>
        /// 获取历史消息
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="qq"></param>
        /// <param name="group"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public async Task<List<MsgInfo>?> GetHistoryMsg(MessageType msgType, long qq = 0, long group = 0, int count = 10, int start = 0) => await Api.GetHistoryMsg(msgType, qq, group, count, start);

        // <summary>
        /// 设置 QQ 个人资料
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SetQQProfile(Profile profile) => await Api.SetQQProfile(profile);

        /// <summary>
        /// 清除本地缓存消息
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ClearMsgs(MessageType msgType, long qq = 0, long group = 0) => await Api.ClearMsgs(msgType, qq, group);

        /// <summary>
        /// 获取陌生人资料
        /// </summary>
        /// <returns></returns>
        public async Task<Stranger?> StrangerInfo(long qq = 0) => await Api.GetStrangerInfo(qq);

        /// <summary>
        /// 日志
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetLog(int start = 0, bool recent = false) => await Api.GetLog(start, recent);
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
