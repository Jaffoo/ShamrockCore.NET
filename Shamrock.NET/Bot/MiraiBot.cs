using Flurl;
using Manganese.Text;
using Mirai.Net.Bot.Managers;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Concretes.Message;
using Mirai.Net.Data.Exceptions;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Websocket.Client;

namespace Mirai.Net;

/// <summary>
///     mirai-api-http机器人描述
/// </summary>
public class MiraiBot : IDisposable
{
    /// <summary>
    /// 销毁当前对象
    /// </summary>
    public void Dispose()
    {
        _client.Dispose();
    }

    #region Exposed

    /// <summary>
    /// 启动bot
    /// </summary>
    public async Task LaunchAsync()
    {
        Instance = this;
        await StartWebsocketListenerAsync();
    }

    #endregion

    #region Properties

    /// <summary>
    ///     最后一个启动的MiraiBot实例
    /// </summary>
    [JsonIgnore]
    public static MiraiBot Instance { get; set; }

    [JsonIgnore]
    private string _qq;
    [JsonIgnore]
    private WebsocketClient _client;

    /// <summary>
    ///     mirai-api-http本地服务器地址，比如：localhost:114514，或者构造一个ConnectConfig对象
    ///     <exception cref="InvalidAddressException">传入错误的地址将会抛出异常</exception>
    /// </summary>
    public ConnectConfig Address { get; set; }

    /// <summary>
    ///     建立连接的QQ账号
    /// </summary>
    public string QQ
    {
        get => _qq;
        set => _qq = value.ThrowIfNotInt64("错误的QQ号").ToString();
    }

    /// <summary>
    /// 群列表
    /// </summary>
    [JsonIgnore]
    public Lazy<IEnumerable<Group>> Groups =>
        new(() => AccountManager.GetGroupsAsync().GetAwaiter().GetResult());

    /// <summary>
    /// 好友列表
    /// </summary>
    [JsonIgnore]
    public Lazy<IEnumerable<Friend>> Friends =>
        new(() => AccountManager.GetFriendsAsync().GetAwaiter().GetResult());

    #endregion

    #region Handlers

    /// <summary>
    /// 接收到事件
    /// </summary>
    [JsonIgnore] public IObservable<EventBase> EventReceived => _eventReceivedSubject.AsObservable();

    private readonly Subject<EventBase> _eventReceivedSubject = new();

    /// <summary>
    /// 收到消息
    /// </summary>
    [JsonIgnore] public IObservable<MessageReceiverBase> MessageReceived => _messageReceivedSubject.AsObservable();

    private readonly Subject<MessageReceiverBase> _messageReceivedSubject = new();

    /// <summary>
    /// 接收到未知类型的Websocket消息
    /// </summary>
    [JsonIgnore] public IObservable<string> UnknownMessageReceived => _unknownMessageReceived.AsObservable();

    private readonly Subject<string> _unknownMessageReceived = new();

    /// <summary>
    /// Websocket断开连接
    /// </summary>
    [JsonIgnore]
    public IObservable<WebSocketCloseStatus> DisconnectionHappened => _disconnectionHappened.AsObservable();

    private readonly Subject<WebSocketCloseStatus> _disconnectionHappened = new();

    #endregion

    #region Websocket adapter private helpers

    /// <summary>
    ///     启动websocket监听
    /// </summary>
    private async Task StartWebsocketListenerAsync()
    {
        var url = new Url($"ws://{Address.WebsocketAddress}/").ToUri();

        _client = new WebsocketClient(url)
        {
            IsReconnectionEnabled = false
        };

        await _client.StartOrFail();

        _client.DisconnectionHappened
            .Subscribe(x => { _disconnectionHappened.OnNext(x.CloseStatus ?? WebSocketCloseStatus.Empty); });

        _client.MessageReceived
            .Where(message => message.MessageType == WebSocketMessageType.Text)
            .Subscribe(message =>
            {
                var data = message.Text.Fetch("data");
                if (data == null || data.IsNullOrEmpty())
                {
                    throw new InvalidWebsocketReponseException("Websocket传回错误响应");
                }

                ProcessWebSocketData(data);
            });
    }

    private void ProcessWebSocketData(string data)
    {
        var dataType = data.Fetch("type");
        if (dataType == null || dataType.IsNullOrEmpty())
        {
            throw new InvalidWebsocketReponseException("Websocket传回错误的响应");
        }

        if (dataType.Contains("Message"))
        {
            var receiver = ReflectionUtils.GetMessageReceiverBase(data);

            var rawChain = data.Fetch("messageChain");
            if (rawChain == null || rawChain.IsNullOrEmpty())
            {
                throw new InvalidResponseException("Websocket传回错误的响应");
            }

            receiver.MessageChain = rawChain.DeserializeMessageChain();

            if (receiver.MessageChain.OfType<AtMessage>().Any(x => x.Target == Instance.QQ))
            {
                _eventReceivedSubject.OnNext(new AtEvent
                {
                    Receiver = (receiver as GroupMessageReceiver)!
                });
            }

            _messageReceivedSubject.OnNext(receiver);
        }
        else if (dataType.Contains("Event"))
        {
            _eventReceivedSubject.OnNext(ReflectionUtils.GetEventBase(data));
        }
        else
        {
            _unknownMessageReceived.OnNext(data);
        }
    }

    #endregion
}