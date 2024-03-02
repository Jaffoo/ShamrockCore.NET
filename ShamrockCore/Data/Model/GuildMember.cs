
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 频道信息发送成员
    /// </summary>
    public record GuildSender
    {
        /// <summary>
        /// id
        /// </summary>
        [JsonProperty("tiny_id")]
        public long UserId { get; set; }


        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; } = string.Empty;

        /// <summary>
        /// 角色id
        /// </summary>
        [JsonProperty("role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions Role { get; set; }

        /// <summary>
        /// 头衔
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;


        /// <summary>
        /// 名片
        /// </summary>
        public string Card { get; set; } = string.Empty;
    }
}
