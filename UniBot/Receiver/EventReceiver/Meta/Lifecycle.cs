using Newtonsoft.Json;
using UniBot.Model;
using static UniBot.Utils.JsonConvertTool;

namespace UniBot.Receiver.EventReceiver.Meta
{
    /// <summary>
    /// 生命周期
    /// </summary>
    public class Lifecycle : EventReceiver
    {
        /// <summary>
        /// 元事件类型
        /// </summary>
        public override MetaType MetaEventType { get; set; } = MetaType.LifeCycle;

        /// <summary>
        /// 元事件子类型
        /// </summary>
        [JsonProperty("sub_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public MetaSubType MetaSubType { get; set; }
        public object? Status { get; set; }
    }
}
