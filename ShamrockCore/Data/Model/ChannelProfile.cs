using Newtonsoft.Json;

namespace ShamrockCore.Data.Model
{
    internal record ChannelListModel
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("channel_list")]
        internal List<ChannelProfile> ChannelList { get; set; } = new List<ChannelProfile>();
    }

    /// <summary>
    /// 子频道信息
    /// </summary>
    public record ChannelProfile
    {
        /// <summary>
        /// 所属频道id
        /// </summary>
        [JsonProperty("owner_guild_id")]
        public long OwerGuildId { get; set; }

        /// <summary>
        /// 频道id
        /// </summary>
        [JsonProperty("guild_id")]
        public long GuildId { get; set; }

        /// <summary>
        /// 子频道id
        /// </summary>
        [JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        /// <summary>
        /// 子频道uid
        /// </summary>
        [JsonProperty("channel_uin")]
        public long ChannelUin { get; set; }

        /// <summary>
        /// 频道类型
        /// </summary>
        [JsonProperty("channel_type")]
        public ChannelType ChannelType { get; set; }

        /// <summary>
        /// 子频道名
        /// </summary>
        public string ChannelName { get; set; } = string.Empty;

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("create_time")]
        public long CreateTime { get; set; }

        /// <summary>
        /// 最大成员
        /// </summary>
        [JsonProperty("max_member_count")]
        public int MaxMemberCount { get; set; }

        /// <summary>
        /// 创建人id
        /// </summary>
        [JsonProperty("creator_tiny_id")]
        public long CreateTinyId { get; set; }

        /// <summary>
        /// 发言权限
        /// </summary>
        [JsonProperty("talk_permission")]
        public int TalkPermission { get; set; }

        /// <summary>
        /// 可见类型
        /// </summary>
        [JsonProperty("visible_type")]
        public int VisibleType { get; set; }

        /// <summary>
        /// 当前慢速模式
        /// </summary>
        [JsonProperty("current_slow_mode")]
        public int CurrentSlowMode { get; set; }

        /// <summary>
        /// 慢速模式
        /// </summary>
        [JsonProperty("slow_modes")]
        public List<SlowMode> SlowModes { get; set; } = new();

        /// <summary>
        /// 图标
        /// </summary>
        [JsonProperty("icon_url")]
        public string IconUrl { get; set; } = string.Empty;

        /// <summary>
        /// 跳转开关
        /// </summary>
        [JsonProperty("jump_switch")]
        public int JumpSwitch { get; set; }

        /// <summary>
        /// 跳转类型
        /// </summary>
        [JsonProperty("jump_type")]
        public int JumpType { get; set; }

        /// <summary>
        /// 跳转URL
        /// </summary>
        [JsonProperty("jump_url")]
        public string JumpUrl { get; set; } = string.Empty;

        /// <summary>
        /// 分类id
        /// </summary>
        [JsonProperty("category_id")]
        public int CategoryId { get; set; }

        /// <summary>
        /// 我的发言权限
        /// </summary>
        [JsonProperty("my_talk_permission")]
        public int MyTalkPermisson { get; set; }

        #region 扩展方法/属性
        #endregion
    }

    /// <summary>
    /// 慢速模式
    /// </summary>
    public record SlowMode
    {
        /// <summary>
        /// 慢速模式标识key
        /// </summary>
        [JsonProperty("slow_mode_key")]
        public int SlowModeKey { get; set; }

        /// <summary>
        /// 慢速模式文本描述
        /// </summary>
        [JsonProperty("slow_mode_text")]
        public string SlowModeText { get; set; } = string.Empty;

        /// <summary>
        /// 语速
        /// </summary>
        [JsonProperty("speak_frequency")]
        public int SpeakFrequency { get; set; }

        /// <summary>
        /// 慢速模式循环
        /// </summary>
        [JsonProperty("slow_mode_circle")]
        public int SlowModeCircle { get; set; }
    }
}
