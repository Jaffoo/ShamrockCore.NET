using Newtonsoft.Json;
using UnifyBot.Api;
using UnifyBot.Model;
using static UnifyBot.Utils.JsonConvertTool;

namespace UnifyBot.Receiver.EventReceiver.Notice
{
    /// <summary>
    /// 群成员减少
    /// </summary>
    public class GroupMemberDecrease : EventReceiver
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        public override NoticeType NoticeEventType => NoticeType.GroupDecrease;

        /// <summary>
        /// 通知子类型
        /// </summary>
        [JsonProperty("sub_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public LeaveSubType NoticeSubType { get; set; }

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
        /// 操作者 QQ 号（如果是主动退群，则和 qq 相同）
        /// </summary>
        [JsonProperty("operator_id")]
        public virtual long OperatorQQ { get; set; }
    }
}
