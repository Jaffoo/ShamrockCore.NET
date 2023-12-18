using Newtonsoft.Json;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 群禁言人
    /// </summary>
    public record Ban
    {
        /// <summary>
        /// 被禁言的人
        /// </summary>
        [JsonProperty("user_id")]
        public long Id { get; set; }

        /// <summary>
        /// 禁言结束时间
        /// </summary>
        public long Time { get; set; }
    }
}
