using Newtonsoft.Json;

namespace ShamrockCore.Reciver.Events
{
    /// <summary>
    /// 群禁言
    /// </summary>
    public class GroupBanEvent : EventBase
    {
        /// <summary>
        /// 被禁言成员 QQ
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 群qq
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 操作者 QQ
        /// </summary>
        [JsonProperty("operator_id")]
        public long OperatorQQ { get; set; }

        /// <summary>
        /// 禁言时长(秒)
        /// </summary>
        [JsonProperty("duration")]
        public long BanTime { get; set; }

        /// <summary>
        /// 子类型(ban/lift_ban)
        /// </summary>
        [JsonProperty("sub_type")]
        public string SubType { get; set; } = "";
    }
}
