using Newtonsoft.Json;

namespace ShamrockCore.Reciver.Events
{
    /// <summary>
    /// 好友添加申请事件
    /// </summary>
    public class FriendAddEvent : EventBase
    {
        /// <summary>
        /// 申请人
        /// </summary>
        [JsonProperty("operator_id")]
        public long OperatorId { get; set; }

        /// <summary>
        /// 验证信息
        /// </summary>
        [JsonProperty("tip_text")]
        public string TipText { get; set; } = "";

        /// <summary>
        /// 事件标识
        /// </summary>
        public string Flag { get; set; } = "";
    }
}
