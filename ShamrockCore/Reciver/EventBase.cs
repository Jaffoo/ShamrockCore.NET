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
        public long SelfId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("post_type")]
        public string PostType { get; set; } = "";

        /// <summary>
        /// 消息制造者/事件被动者
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonProperty("notice_type")]
        public string NoticeType { get; set; } = "";
    }
}
