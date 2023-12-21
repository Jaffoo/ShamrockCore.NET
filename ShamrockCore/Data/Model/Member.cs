using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    ///     群成员
    /// </summary>
    public record Member
    {
        /// <summary>
        ///     群员的QQ号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        ///     群QQ号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        ///     群员的群名片
        /// </summary>
        [JsonProperty("user_name")]
        public string Name { get; set; } = "";

        /// <summary>
        ///     性别
        /// </summary>
        [JsonProperty("sex")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Genders Sex { get; set; }

        /// <summary>
        ///     操作者在群中的权限
        /// </summary>
        [JsonProperty("role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions Role { get; set; }

        /// <summary>
        ///     操作者的群头衔
        /// </summary>
        [JsonProperty("title")]
        public string SpecialTitle { get; set; } = "";

        /// <summary>
        ///     专属头衔过期时间戳
        /// </summary>
        [JsonProperty("title_expire_time")]
        public long TitleExpireTime { get; set; }

        /// <summary>
        ///     加入时间戳
        /// </summary>
        [JsonProperty("join_time")]
        public string JoinTime { get; set; } = "";

        /// <summary>
        ///     最后发言时间戳
        /// </summary>
        [JsonProperty("last_sent_time")]
        public string LastSpeakTime { get; set; } = "";

        /// <summary>
        ///     最后活跃时间戳
        /// </summary>
        [JsonProperty("last_active_time")]
        public string LastActiveTime { get; set; } = "";

        /// <summary>
        ///     群头衔
        /// </summary>
        [JsonProperty("unique_name")]
        public string UniqueName { get; set; } = "";

        /// <summary>
        ///     群昵称
        /// </summary>
        [JsonProperty("nickname")]
        public string GroupName { get; set; } = "";

        /// <summary>
        ///     显示名
        /// </summary>
        [JsonProperty("user_displayname")]
        public string DisplayName { get; set; } = "";

        /// <summary>
        ///     距离
        /// </summary>
        [JsonProperty("distance")]
        public int Distance { get; set; }

        /// <summary>
        ///     地区
        /// </summary>
        [JsonProperty("area")]
        public string Area { get; set; } = "";

        /// <summary>
        ///     等级
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        ///     是否不良记录成员
        /// </summary>
        [JsonProperty("unfriendly")]
        public bool Unfriendly { get; set; }

        /// <summary>
        ///     是否允许修改群名片
        /// </summary>
        [JsonProperty("card_changeable")]
        public bool CanChangeCard { get; set; }

        /// <summary>
        ///     在群荣誉
        /// </summary>
        [JsonProperty("honor")]
        public List<int>? Honor { get; set; } = null;

        #region 扩展方法/属性
        /// <summary>
        /// 禁言
        /// </summary>
        /// <param name="time">禁言时长（为0时解除禁言）</param>
        /// <returns></returns>
        public async Task<bool> Ban(long time) => await Api.SetGroupBan(GroupQQ, QQ, time);

        /// <summary>
        /// 戳一下
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Touch() => await Api.GroupTouch(GroupQQ, QQ);

        /// <summary>
        /// 踢出群聊
        /// </summary>
        /// <param name="rejectAddAgain">拒绝再次加入申请</param>
        /// <returns></returns>
        public async Task<bool> Kick(bool rejectAddAgain = false) => await Api.SetGroupKick(GroupQQ, QQ, rejectAddAgain);

        /// <summary>
        /// 设置头衔
        /// </summary>
        /// <param name="title">头衔</param>
        /// <returns></returns>
        public async Task<bool> SetSpecialTitle(string title) => await Api.SetGroupSpecialTitle(GroupQQ, QQ, title);

        /// <summary>
        /// 设置为管理员
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SetAdmin() => await Api.SetGroupAdmin(GroupQQ, QQ);

        /// <summary>
        /// 移除管理员
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RemoveAdmin() => await Api.SetGroupAdmin(GroupQQ, QQ, false);
        #endregion
    }
}
