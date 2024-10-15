using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using UnifyBot.Model;
using Websocket.Client;
using Fleck;
using UnifyBot.Utils;
using UnifyBot.Api;
using Newtonsoft.Json.Linq;
using UnifyBot.Message.Chain;
using TBC.CommonLib;
using UnifyBot.Receiver.EventReceiver;
using UnifyBot.Receiver.MessageReceiver;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace UnifyBot
{
    /// <summary>
    /// 主函数
    /// </summary>
    public class Bot : IDisposable
    {
        #region 全局变量/构造函数
        private WebsocketClient? _client;
        private WebSocketServer? _server;
        public Connect Conn { get; set; }
        private bool disposedValue;

        /// <summary>
        /// 收到事件
        /// </summary>
        public IObservable<EventReceiver> EventReceived { get; }
        private readonly Subject<EventReceiver> _eventReceivedSubject = new Subject<EventReceiver>();

        /// <summary>
        /// 收到消息
        /// </summary>
        public IObservable<MessageReceiver> MessageReceived { get; }
        private readonly Subject<MessageReceiver> _messageReceivedSubject = new Subject<MessageReceiver>();

        /// <summary>
        /// 接收到未知类型的Websocket消息
        /// </summary>
        public IObservable<string> UnknownMessageReceived { get; }
        private readonly Subject<string> _unknownMessageReceived = new Subject<string>();

        /// <summary>
        /// Websocket断开连接
        /// </summary>
        public IObservable<WebSocketCloseStatus> DisconnectionHappened { get; }
        private readonly Subject<WebSocketCloseStatus> _disconnectionHappened = new Subject<WebSocketCloseStatus>();
        public Bot(Connect conf)
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
            if (Conn.CanConnetBot) await Init();
            else throw new Exception("QQ连接测试失败，请检查连接配置！");
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
                    // 创建一个新的WebSocket服务器实例，使用Conn.ReverseWsUrl作为监听地址
                    _server = new WebSocketServer(Conn.ReverseWsUrl);

                    // 启动WebSocket服务器，并设置客户端消息处理回调函数
                    _server.Start(socket =>
                    {
                        socket.OnError = error =>
                        {
                            socket.Send(error.Message);
                        };

                        // 定义客户端发送消息时的处理逻辑
                        socket.OnMessage = message =>
                        {
                            // 如果服务器端存在非空且非仅包含空白字符的Conn.Token
                            if (!string.IsNullOrWhiteSpace(Conn.Token))
                            {
                                // 获取客户端连接的头部信息
                                var headers = socket.ConnectionInfo.Headers;

                                // 从头部信息中提取客户端提供的Token
                                var clientToken = headers["Authorization"].ToString();

                                // 检查客户端提供的Token与服务器端预期Token是否匹配
                                if (clientToken != Conn.Token)
                                {
                                    // 若Token不匹配，发送错误消息给客户端，并停止进一步处理本次消息
                                    var error = new
                                    {
                                        status = "error",
                                        code = 401,
                                        msg = "未授权",
                                    };
                                    socket.Send(error.ToJsonStr());
                                    return;
                                }
                            }

                            // 若Token验证通过（或无需验证），调用HandleData函数处理接收到的消息
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
                var postType = data.Fetch("post_type").Replace("_", "");
                if (postType == PostType.Message.ToString().ToLower())
                {
                    var msg = JsonConvertTool.MessageReceiverHandel(data, Conn) ?? throw new InvalidDataException("数据无效！");
                    _messageReceivedSubject.OnNext(msg);
                }
                else if (postType == PostType.MetaEvent.GetDescription().ToLower())
                {
                    var msg = JsonConvertTool.MetaEventReceiverHandel(data, Conn) ?? throw new InvalidDataException("数据无效！");
                    _eventReceivedSubject.OnNext(msg);
                }
                else if (postType == PostType.Notice.ToString().ToLower())
                {
                    var msg = JsonConvertTool.NoticeEventReceiverHandel(data, Conn) ?? throw new InvalidDataException("数据无效！");
                    _eventReceivedSubject.OnNext(msg);
                }
                else if (PostType.Request.ToString().ToLower() == postType)
                {
                    var msg = JsonConvertTool.RequestEventReceiverHandel(data, Conn) ?? throw new InvalidDataException("数据无效！");
                    _eventReceivedSubject.OnNext(msg);
                }
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
        public List<FriendInfo> Friends => Conn.GetFriendList().Result;


        /// <summary>
        /// 群列表
        /// </summary>
        public List<GroupInfo> Groups => Conn.GetGroupList().Result;

        /// <summary>
        /// onebot实现版本信息
        /// </summary>
        public JObject Version => Conn.GetVersion().Result;

        /// <summary>
        /// onebot实现状态信息
        /// </summary>
        public JObject Status => Conn.GetStatus().Result;

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
        /// <param name="group"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendGroupMessage(GroupInfo group, MessageChain msg) => await Conn.SendGroupMsg(group.GroupQQ, msg);

        /// <summary>
        /// 发送群聊消息
        /// </summary>
        /// <param name="group"></param>
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
        /// get请求
        /// </summary>
        /// <param name="apiEndpoint">请求端点</param>
        /// <param name="paramStr">请求参数字符串（url格式拼接好）</param>
        /// <returns>json格式字符串</returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<T> GetAsync<T>(string apiEndpoint, string paramStr = "") where T : class
        {
            try
            {
                var url = Conn.HttpUrl + apiEndpoint + paramStr;
                var res = await Tools.GetAsync<ApiResult<T>>(url, Conn.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空！");
                return res.Data;
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

        /// <summary>
        /// post请求
        /// </summary>d
        /// <param name="apiEndpoint">请求端点</param>
        /// <param name="data">请求body数据(json字符串)</param>
        /// <returns>json格式字符串</returns>
        /// <exception cref="InvalidDataException"></exception>
        public async Task<T> PostAsync<T>(string apiEndpoint, string data) where T : class
        {
            try
            {
                var url = Conn.HttpUrl + apiEndpoint;
                var res = await Tools.PostAsync<ApiResult<T>>(url, data, Conn.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空！");
                return res.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 资源释放
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)
                    _client?.Dispose();
                    _server?.Dispose();
                    Conn = new Connect("", 0, 0);
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
        #endregion
        #endregion
    }
}
