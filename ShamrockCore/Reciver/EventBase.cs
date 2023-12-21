using Newtonsoft.Json;

namespace ShamrockCore.Reciver
{
    /// <summary>
    /// 事件基类
    /// </summary>
    public class EventBase
    {
        /// <summary>
        /// 发送时间
        /// </summary>
        [JsonProperty("time")]
        public long Time { get; set; }

        /// <summary>
        /// 机器人qq
        /// </summary>
        [JsonProperty("self_id")]
        public long BotQQ { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("post_type")]
        public string PostType { get; set; } = "";
    }
}
