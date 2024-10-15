using Newtonsoft.Json;
using UnifyBot.Message.Chain;
using static UnifyBot.Utils.JsonConvertTool;

namespace UnifyBot.Model
{
    public class MessageInfoBase
    {
        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("message_id")]
        public long MessageId { get; set; }
    }
    public class ForardMessageInfo
    {
        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("forward_id")]
        public long ForwardId { get; set; }
    }
    /// <summary>
    /// 消息信息
    /// </summary>
    public class MessageInfo: MessageInfoBase
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("message_type	")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public MessageType MessageType { get; set; }

        /// <summary>
        /// 消息真实id
        /// </summary>
        [JsonProperty("real_id")]
        public long RealId { get; set; }

        /// <summary>
        /// 发送人信息
        /// </summary>
        public Sender Sender { get; set; } = new Sender();

        /// <summary>
        /// 消息内容
        /// </summary>
        public MessageChain? Message { get; set; }
    }
}
