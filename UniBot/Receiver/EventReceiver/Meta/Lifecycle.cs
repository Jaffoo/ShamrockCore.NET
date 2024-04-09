using Newtonsoft.Json;
using UnifyBot.Model;
using static UniBot.Tools.JsonConvertTool;

namespace UnifyBot.Receiver.EventReceiver.Meta
{
    /// <summary>
    /// 生命周期
    /// </summary>
    public class Lifecycle : EventReceiver
    {
        /// <summary>
        /// 元事件类型
        /// </summary>
        [JsonProperty("meta_event_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public MetaType MetaType { get; set; }

        /// <summary>
        /// 元事件子类型
        /// </summary>
        [JsonProperty("sub_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public MetaSubType MetaSubType { get; set; }
        public object? Status { get; set; }
    }
}
