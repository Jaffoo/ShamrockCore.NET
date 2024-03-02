using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Data.Model
{
    internal record GuildListModel
    {
        [JsonProperty("guild_list")]
        internal List<GuildProfile> GuildList { get; set; } = new();
    }
    /// <summary>
    /// 频道信息
    /// </summary>
    public record GuildProfile
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
        [JsonProperty("profile")]
        public string Profile { get; set; } = "";

        /// <summary>
        /// 拥有者
        /// </summary>
        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        /// <summary>
        /// 关闭到期时间
        /// </summary>
        [JsonProperty("shutup_expire_time")]
        public long ShutupTime { get; set; }

        /// <summary>
        /// 允许搜索
        /// </summary>
        [JsonProperty("allow_search")]
        public bool AllowSearch { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public StatusInfo Status { get; set; } = new();

        #region 扩展属性/方法
        private Lazy<GuildMeta?>? _guildMeta;
        /// <summary>
        /// 频道元数据
        /// </summary>
        public GuildMeta? GuildMeta
        {
            get
            {
                _guildMeta ??= new(() => Api.GetGuildMetaById(GuildId).Result);
                return _guildMeta.Value;
            }
        }

        private Lazy<List<GuildRole>?>? _roles;
        /// <summary>
        /// 角色列表
        /// </summary>
        public List<GuildRole>? Roles
        {
            get
            {
                _roles ??= new(() => Api.GetGuildRoles(GuildId).Result);
                _roles.Value?.ToList()?.ForEach(item => item.GuildId = GuildId);
                return _roles.Value;
            }
        }

        /// <summary>
        /// 获取频道成员列表
        /// </summary>
        /// <param name="nextToken">下一页token,不提供则从首页开始获取</param>
        /// <param name="all">是否一次性获取完所有成员</param>
        /// <param name="refresh">是否刷新数据，默认false</param>
        /// <returns></returns>
        public async Task<GuildMember?> GuildMember(string nextToken, bool all = false, bool refresh = false)
        {
            var res = await Api.GetGuildMemberList(GuildId, nextToken, all, refresh);
            res?.Members.ForEach(item => item.GuildId = GuildId);
            return res;
        }

        /// <summary>
        /// 获取子频道列表
        /// </summary>
        /// <param name="refresh">是否刷新数据，默认false</param>
        /// <returns></returns>
        public async Task<List<ChannelProfile>?> Channels(bool refresh = false)
        {
            var res = await Api.GetGuildChannelList(GuildId, refresh);
            return res;
        }

        /// <summary>
        /// 获取频道帖子广场帖子
        /// </summary>
        /// <param name="from">开始获取的位置</param>
        /// <returns></returns>
        public async Task<object?> GuildFeeds(int from)
        {
            var res = await Api.GetGuildFeeds(GuildId, from);
            return res;
        }
        #endregion
    }

    /// <summary>
    /// 状态详情
    /// </summary>
    public record StatusInfo
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        [JsonProperty("is_enable")] public bool IsEnable { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        [JsonProperty("is_banned")] public bool IsBanned { get; set; }

        /// <summary>
        /// 是否冻结
        /// </summary>
        [JsonProperty("is_frozen")] public bool IsFrozen { get; set; }
    }
}
