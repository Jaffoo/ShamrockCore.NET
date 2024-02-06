using Newtonsoft.Json;

namespace ShamrockCore.Data.Model
{
    public record GuildMemeberProfile
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
        /// 加入时间
        /// </summary>
        [JsonProperty("join_time")]
        public long JoinTime { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; } = string.Empty;

        /// <summary>
        /// 角色
        /// </summary>
        public Role Roles { get; set; } = new();
    }

    /// <summary>
    /// 角色
    /// </summary>
    public record Role
    {
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
        /// 显示名称
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// 颜色
        /// </summary>
        public long Color { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public List<Permission> Permission { get; set; } = new();
    }

    /// <summary>
    /// 权限
    /// </summary>
    public record Permission
    {
        /// <summary>
        /// 基础权限id
        /// </summary>
        [JsonProperty("root_id")]
        public int RootId { get; set; }

        /// <summary>
        /// 子权限ids
        /// </summary>
        [JsonProperty("child_ids")]
        public List<int> ChildrenIds { get; set; } = new();
    }
}
