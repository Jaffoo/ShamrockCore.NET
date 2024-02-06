using Newtonsoft.Json;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 频道消息
    /// </summary>
    public record GuildMsg
    {
        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        public long Time { get; set; }
    }
}
