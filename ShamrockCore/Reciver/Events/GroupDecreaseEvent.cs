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
        /// 子类型(leave/kick/kick_me)
        /// </summary>
        [JsonProperty("sub_type")]
        public Type SubType { get; set; }

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
        public Member? Member => Api.GetGroupMemberInfo(QQ, GroupQQ).Result;
        #endregion

        public enum Type
        {
            /// <summary>
            /// 退群
            /// </summary>
            leave,
            /// <summary>
            /// 踢人
            /// </summary>
            kick,
            /// <summary>
            /// 自己被踢
            /// </summary>
            kick_me,
        }
    }
}
