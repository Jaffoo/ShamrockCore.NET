using Newtonsoft.Json;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 频道元数据
    /// </summary>
    public record GuildMeta
    {
        /// <summary>
        /// 频道id
        /// </summary>
        [JsonProperty("guild_id")]
        public long GuildId { get; set; }

        /// <summary>
        /// 频道名
        /// </summary>
        [JsonProperty("guild_name")]
        public string GuildName { get; set; } = "";

        /// <summary>
        /// 频道显示id
        /// </summary>
        [JsonProperty("guild_display_id")]
        public string GuildDisplayId { get; set; } = "";

        /// <summary>
        /// 频道描述
        /// </summary>
        [JsonProperty("guild_profile")]
        public string GuildProfile { get; set; } = "";

        /// <summary>
        /// 拥有者
        /// </summary>
        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("create_time")]
        public long CreateTime { get; set; }

        /// <summary>
        /// 最大人数
        /// </summary>
        [JsonProperty("max_member_count")]
        public int MaxMemberCount { get; set; }

        /// <summary>
        /// 最大机器人数
        /// </summary>
        [JsonProperty("max_robot_count")]
        public int MaxRobotCount { get; set; }

        /// <summary>
        /// 最大管理人数
        /// </summary>
        [JsonProperty("max_admin_count")]
        public int MaxAdminCount { get; set; }

        /// <summary>
        /// 人数
        /// </summary>
        [JsonProperty("member_count")]
        public int MemberCount { get; set; }
    }
}
