using Newtonsoft.Json;
using UniBot.Model;
using static UniBot.Utils.JsonConvertTool;

namespace UniBot.Receiver.EventReceiver
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
