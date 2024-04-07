using Newtonsoft.Json;
using UniBot.Model;
using static UniBot.Tools.JsonConvertTool;

namespace UniBot.Receiver.EventReceiver
{
    public class EventReceiver : MessageReceiverBase
    {
        /// <summary>
        /// 元事件类型
        /// </summary>
        [CustomJsonProperty("meta_event_type", "notice_type", "request_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public EventType EventType { get; set; }
    }
}
