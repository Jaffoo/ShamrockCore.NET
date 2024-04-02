using Newtonsoft.Json;
using UniBot.Model;
using static UniBot.Tools.JsonConvert;

namespace UniBot.Event
{
    public class EventBase
    {
        /// <summary>
        /// 收到事件的机器人 QQ 号
        /// </summary>
        public long BotQQ { get; set; }

        /// <summary>
        /// 事件发生的时间戳
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonProperty("post_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public virtual PostType PostType { get; set; }
    }
}
