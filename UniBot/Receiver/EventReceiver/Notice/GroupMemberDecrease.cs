using Newtonsoft.Json;
using UniBot.Api;
using UniBot.Model;
using static UniBot.Utils.JsonConvertTool;

namespace UniBot.Receiver.EventReceiver.Notice
{
    /// <summary>
    /// 群成员减少
    /// </summary>
    public class GroupMemberDecrease : EventReceiver
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        public override NoticeType NoticeEventType { get; set; } = NoticeType.GroupDecrease;

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
