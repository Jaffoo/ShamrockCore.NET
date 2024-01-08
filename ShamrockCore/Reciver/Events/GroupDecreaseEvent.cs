using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Reciver.Events
{
    /// <summary>
    /// 群组成员减少事件
    /// </summary>
    public class GroupDecreaseEvent : EventBase
    {
        /// <summary>
        /// 减少成员 QQ
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 子类型(leave/kick/self)
        /// </summary>
        [JsonProperty("sub_type")]
        public LeaveType SubType { get; set; }

        /// <summary>
        /// 群
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 操作者qq
        /// </summary>
        [JsonProperty("target_id")]
        public long TargetQQ { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [JsonProperty("operator_id")]
        public long OperatorQQ { get; set; }

        /// <summary>
        /// 发送人qq
        /// </summary>
        [JsonProperty("sender_id")]
        public long SenderQQ { get; set; }

        #region 扩展方法/属性
        /// <summary>
        /// 成员
        /// </summary>
        [JsonIgnore]
        public Member? Member
        {
            get
            {
                _member ??= new(() => Api.GetGroupMemberInfo(QQ, GroupQQ).Result);
                return _member.Value;
            }
        }
        [JsonIgnore] private Lazy<Member?>? _member;

        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonIgnore]
        public override PostEventType EventType { get; set; } = PostEventType.GroupDecrease;
        #endregion
    }
}
