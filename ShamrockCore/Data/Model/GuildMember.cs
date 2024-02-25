
using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 成员信息
    /// </summary>
    public record GuildMember
    {
        /// <summary>
        /// 成员信息
        /// </summary>
        public List<GuildMemeberInfo> Members { get; set; } = new();

        /// <summary>
        /// 下一页token
        /// </summary>
        public string NextToken { get; set; } = "";

        /// <summary>
        /// 最后一页
        /// </summary>
        public bool Finished { get; set; }
    }

    /// <summary>
    /// 成员信息
    /// </summary>
    public record GuildMemeberInfo
    {
        /// <summary>
        /// id
        /// </summary>
        [JsonProperty("tiny_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; } = string.Empty;

        /// <summary>
        /// 角色id
        /// </summary>
        [JsonProperty("role_id")]
        public int RoleId { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [JsonProperty("role_name")]
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// 角色颜色
        /// </summary>
        [JsonProperty("role_color")]
        public long RoleColor { get; set; }

        /// <summary>
        /// 加入时间
        /// </summary>
        [JsonProperty("join_time")]
        public long JoinTime { get; set; }

        /// <summary>
        /// 机器人类型
        /// </summary>
        [JsonProperty("robot_type")]
        public int RobotType { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 是否在黑名单
        /// </summary>
        [JsonProperty("in_black")]
        public bool InBlack { get; set; }

        /// <summary>
        /// 平台
        /// </summary>
        public int Platform { get; set; }

        #region 扩展方法/属性
        /// <summary>
        /// 频道id
        /// </summary>
        [JsonIgnore]
        public long GuildId { get; set; }

        private Lazy<GuildMemeberProfile?>? _moreInfo;
        /// <summary>
        /// 更多信息
        /// </summary>
        public GuildMemeberProfile? MoreInfo
        {
            get
            {
                _moreInfo ??= new(() => Api.GetGuildMemberProfile(GuildId, UserId).Result);
                return _moreInfo.Value;
            }
        }

        /// <summary>
        /// 设置角色
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SetRole(int roleId)
        {
            var res = await Api.SetGuildMemberRole(GuildId, roleId, true, UserId.ToString());
            return res;
        }

        /// <summary>
        /// 移除角色
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RemoveRole(int roleId)
        {
            var res = await Api.SetGuildMemberRole(GuildId, roleId, false, UserId.ToString());
            return res;
        }
        #endregion
    }
}
