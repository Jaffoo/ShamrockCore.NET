using Newtonsoft.Json;
using UniBot.Api;
using UniBot.Message.Chain;

namespace UniBot.Model
{
    /// <summary>
    /// 群信息
    /// </summary>
    public class GroupInfo : ModelBase
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 群名
        /// </summary>
        [JsonProperty("group_name")]
        public string GroupName { get; set; } = "";

        /// <summary>
        /// 成员数
        /// </summary>
        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        /// <summary>
        /// 最大成员数
        /// </summary>
        [JsonProperty("max_memeber_count")]
        public int MaxCount { get; set; }

        #region 扩展方法/属性

        /// <summary>
        /// 群成员列表
        /// </summary>
        [JsonIgnore]
        public List<GroupMemberInfo> Members => Connect.GetGroupMemberList(GroupQQ).Result;

        /// <summary>
        /// 群荣誉
        /// </summary>
        [JsonIgnore]
        public GroupHonorInfo Honor => Connect.GetGroupHonorInfo(GroupQQ).Result;

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendMessage(MessageChain msg) => await Connect.SendGroupMsg(GroupQQ, msg);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendMessage(string msg) => await Connect.SendGroupMsg(GroupQQ, msg);

        /// <summary>
        /// 全体禁言
        /// </summary>
        /// <returns></returns>
        public async Task<bool> EnableGroupBan() => await Connect.SetGroupWholeBan(GroupQQ);

        /// <summary>
        /// 取消全体禁言
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DisableGroupBan() => await Connect.SetGroupWholeBan(GroupQQ, false);

        /// <summary>
        /// 允许匿名聊天
        /// </summary>
        /// <returns></returns>
        public async Task<bool> EnableAnonymous() => await Connect.SetGroupAnonymous(GroupQQ);

        /// <summary>
        /// 不允许匿名聊天
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DisableAnonymous() => await Connect.SetGroupAnonymous(GroupQQ, false);

        /// <summary>
        /// 设置群名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<bool> SetGroupName(string name) => await Connect.SetGroupName(GroupQQ, name);

        /// <summary>
        /// 退出群聊
        /// </summary>
        /// <param name="dissolve">是否解散，如果登录号是群主，则仅在此项为 true 时能够解散</param>
        /// <returns></returns>
        public async Task<bool> LeaveGroup(bool dissolve = false) => await Connect.SetGroupLeave(GroupQQ, dissolve);
        #endregion
    }
}
