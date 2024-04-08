using Newtonsoft.Json;
using UniBot.Api;
using UniBot.Model;
using static UniBot.Utils.JsonConvertTool;

namespace UniBot.Receiver.EventReceiver
{
    /// <summary>
    /// 群管理员变动
    /// </summary>
    public class GroupAdminChange : EventReceiver
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// qq号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 通知子类型
        /// </summary>
        [JsonProperty("sub_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public NoticeSubType NoticeSubType { get; set; }

        #region 扩展属性/方法
        /// <summary>
        /// 管理员信息
        /// </summary>
        [JsonIgnore]
        public GroupMemberInfo Admin => Connect.GetGroupMemberInfo(GroupQQ, QQ).Result;
        #endregion
    }
}
