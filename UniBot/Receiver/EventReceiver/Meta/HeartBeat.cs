using UnifyBot.Model;

namespace UnifyBot.Receiver.EventReceiver.Meta
{
    /// <summary>
    /// 生命周期
    /// </summary>
    public class HeartBeat : EventReceiver
    {
        /// <summary>
        /// 元事件类型
        /// </summary>
        public override MetaType MetaEventType => MetaType.HeartBeat;

        /// <summary>
        /// 状态信息
        /// </summary>
        public object? Status { get; set; }

        /// <summary>
        /// 到下次心跳的间隔，单位毫秒
        /// </summary>
        public long Interval { get; set; }
    }
}
