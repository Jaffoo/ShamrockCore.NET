using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Data.Model
{
    public record GuildRole
    {
        /// <summary>
        /// 角色id
        /// </summary>
        [JsonProperty("role_id")]
        public long RoleId { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        [JsonProperty("role_name")]
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// 颜色
        /// </summary>
        [JsonProperty("argb_color")]
        public long Color { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 是否独立
        /// </summary>
        public bool Independent { get; set; }

        /// <summary>
        /// 可拥有最大成员数量
        /// </summary>
        [JsonProperty("max_count")]
        public int MaxCount { get; set; }

        /// <summary>
        /// 拥有成员数量
        /// </summary>
        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        /// <summary>
        /// 自己是否拥有
        /// </summary>
        public bool Owned { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public Permission Permission = new();

        #region 扩展属性/方法
        /// <summary>
        /// 频道id
        /// </summary>
        [JsonIgnore]
        public long GuildId { get; set; }

        /// <summary>
        /// 设置角色
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SetRole(long userId)
        {
            var res = await Api.SetGuildMemberRole(GuildId, RoleId, true, userId.ToString());
            return res;
        }

        /// <summary>
        /// 设置角色
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SetRole(List<long> userIds)
        {
            var res = await Api.SetGuildMemberRole(GuildId, RoleId, true, userIds);
            return res;
        }

        /// <summary>
        /// 移除角色
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RemoveRole(long userId)
        {
            var res = await Api.SetGuildMemberRole(GuildId, RoleId, false, userId.ToString());
            return res;
        }

        /// <summary>
        /// 移除角色
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RemoveRole(List<long> userIds)
        {
            var res = await Api.SetGuildMemberRole(GuildId, RoleId, false, userIds);
            return res;
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DeleteRole()
        {
            var res = await Api.DeleteGuildRole(GuildId, RoleId);
            return res;
        }
        #endregion
    }
}
