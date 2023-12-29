using Newtonsoft.Json;

namespace ShamrockCore.Reciver.Events
{
    public class EssenceEvent : EventBase
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 发送者 QQ
        /// </summary>
        [JsonProperty("sender_id")]
        public long SenderQQ { get; set; }

        /// <summary>
        /// 操作者 QQ
        /// </summary>
        [JsonProperty("operator_id")]
        public long OperatorQQ { get; set; }

        /// <summary>
        /// 消息 ID
        /// </summary>
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        /// <summary>
        /// 子类型(add/delete)
        /// </summary>
        [JsonProperty("sub_type")]
        public string SubType { get; set; } = "";
    }
}
