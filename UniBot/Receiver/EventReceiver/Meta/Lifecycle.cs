using Newtonsoft.Json;
using UnifyBot.Model;
using static UnifyBot.Utils.JsonConvertTool;

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
        public override MetaType MetaEventType => MetaType.LifeCycle;

        /// <summary>
        /// 元事件子类型
        /// </summary>
        [JsonProperty("sub_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public MetaSubType MetaSubType { get; set; }
        public object? Status { get; set; }
    }
}
