using Shamrock.Net.Data.Messages.Receivers;

namespace Shamrock.Net.Data.Events.Concretes.Message;

/// <summary>
/// Bot被人at
/// </summary>
public record AtEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.At;

    /// <summary>
    /// 被at的那条消息容器
    /// </summary>
    public GroupMessageReceiver Receiver { get; set; }
}