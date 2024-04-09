using Newtonsoft.Json;
using UniBot.Api;
using UniBot.Model;
using static UniBot.Utils.JsonConvertTool;

namespace UniBot.Receiver.EventReceiver.Notice
{
    /// <summary>
    /// 红包运气王
    /// </summary>
    public class GroupLucky : EventReceiver
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
        /// 红包发送者 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 运气王 QQ 号
        /// </summary>
        [JsonProperty("target_id")]
        public long LuckyQQ { get; set; }

        #region 扩展属性/方法
        /// <summary>
        /// 运气王信息
        /// </summary>
        [JsonIgnore]
        public GroupMemberInfo User => Connect.GetGroupMemberInfo(GroupQQ, QQ).Result;
        #endregion
    }
}
