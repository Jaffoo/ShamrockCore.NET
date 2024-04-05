using Newtonsoft.Json;
using UniBot.Model;
using static UniBot.Tools.JsonConvertTool;

namespace UniBot.Receiver.Event
{
    /// <summary>
    /// 生命周期
    /// </summary>
    public class HeartBeat : MessageReceiverBase
    {
        /// <summary>
        /// 元事件类型
        /// </summary>
        [JsonProperty("meta_event_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public MetaType MetaType { get; set; }

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
