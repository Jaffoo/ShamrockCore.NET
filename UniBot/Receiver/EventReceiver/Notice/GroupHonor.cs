using Newtonsoft.Json;
using UniBot.Api;
using UniBot.Model;
using static UniBot.Utils.JsonConvertTool;

namespace UniBot.Receiver.EventReceiver.Notice
{
    /// <summary>
    /// 群成员荣誉变更
    /// </summary>
    public class GroupHonor : EventReceiver
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        public override NoticeType NoticeEventType => NoticeType.Notify;

        /// <summary>
        /// 通知子类型
        /// </summary>
        [JsonProperty("sub_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public NoticeSubType NoticeSubType { get; set; }

        /// <summary>
        /// 成员 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 荣誉类型
        /// </summary>
        [JsonProperty("honor_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public HonorType HonorType { get; set; }

        #region 扩展属性/方法
        /// <summary>
        /// 荣誉人信息
        /// </summary>
        [JsonIgnore]
        public GroupMemberInfo User => Connect.GetGroupMemberInfo(GroupQQ, QQ).Result;
        #endregion
    }
}
