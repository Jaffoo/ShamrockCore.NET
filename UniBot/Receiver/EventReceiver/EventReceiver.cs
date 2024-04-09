using Newtonsoft.Json;
using UniBot.Model;
using UnifyBot.Receiver;
using static UniBot.Tools.JsonConvertTool;

namespace UnifyBot.Receiver.EventReceiver
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
