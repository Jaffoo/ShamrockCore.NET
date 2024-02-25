using Newtonsoft.Json;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 频道系统内BOT的资料
    /// </summary>
    public record GuildBotProfile
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; } = "";

        /// <summary>
        /// 机器人频道id
        /// </summary>
        [JsonProperty("tiny_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; } = "";
    }
}
