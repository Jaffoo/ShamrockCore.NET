using Newtonsoft.Json;

namespace ShamrockCore.Reciver.Events
{
    /// <summary>
    /// 群组成员增加事件
    /// </summary>
    public class GroupIncreaseEvent
    {
        /// <summary>
        /// 子类型(leave/kick/kick_me)
        /// </summary>
        [JsonProperty("sub_type")]
        public string SubType { get; set; } = "";

        /// <summary>
        /// 群
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// 操作目标id
        /// </summary>
        [JsonProperty("target_id")]
        public long TargetId { get; set; }

        /// <summary>
        /// 操作人
        /// </summary>
        [JsonProperty("operator_id")]
        public long OperatorId { get; set; }

        /// <summary>
        /// 发送人id
        /// </summary>
        [JsonProperty("sender_id")]
        public long SenderId { get; set; }
    }
}
