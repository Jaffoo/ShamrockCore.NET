using Newtonsoft.Json;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 登录者信息
    /// </summary>
    public record LoginInfo
    {
        /// <summary>
        /// qq
        /// </summary>
        [JsonProperty("user_id")]
        public long Id { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [JsonProperty("nickname")]
        public string Name { get; set; }
    }
}