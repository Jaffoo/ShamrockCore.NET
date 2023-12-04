using Newtonsoft.Json;

namespace Shamrock.Net.Data.Shared
{
    /// <summary>
    /// QQ 个人资料
    /// </summary>
    public record QQProfile
    {
        /// <summary>
        /// 昵称
        /// </summary>
        [JsonProperty("nickname")]
        public string Name { get; set; }

        /// <summary>
        /// 公司
        /// </summary>
        [JsonProperty("company")]
        public string Company { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// 大学
        /// </summary>
        [JsonProperty("college")]
        public string College { get; set; }

        /// <summary>
        /// 个人备注
        /// </summary>
        [JsonProperty("personal_note")]
        public string Note { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [JsonProperty("age")]
        public int Age { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [JsonProperty("birthday")]
        public string Birthday { get; set; }
    }
}