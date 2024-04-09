using Newtonsoft.Json;
using UnifyBot.Model;
using static UnifyBot.Utils.JsonConvertTool;

namespace UnifyBot.Receiver.EventReceiver
{
    public class EventReceiver : MessageReceiverBase
    {
        /// <summary>
        /// 元事件类型
        /// </summary>
        [JsonIgnore]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public virtual MetaType MetaEventType { get; set; }
        /// <summary>
        /// 元事件类型
        /// </summary>
        [JsonProperty("notice_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public virtual NoticeType NoticeEventType { get; set; }
        /// <summary>
        /// 元事件类型
        /// </summary>
        [JsonIgnore]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public virtual RequestType RequestEventType { get; set; }
    }
}
