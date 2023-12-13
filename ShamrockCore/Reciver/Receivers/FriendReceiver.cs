using Newtonsoft.Json;
using ShamrockCore.Reciver.MsgChain;

namespace ShamrockCore.Reciver.Receivers
{
    /// <summary>
    /// 好友接收器
    /// </summary>
    public class FriendReceiver : MessageReceiverBase
    {
        /// <summary>
        /// 私聊者id
        /// </summary>
        [JsonProperty("target_id")]
        public long TargetId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("message_type")]
        public string MessageType { get; set; } = "";

        /// <summary>
        /// 消息子类型
        /// </summary>
        [JsonProperty("sub_type")]
        public string SubType { get; set; } = "";

        /// <summary>
        /// 消息接收者，群聊是群号，私聊时是目标QQ
        /// </summary>
        [JsonProperty("peer_id")]
        public long PeerId { get; set; }

        /// <summary>
        /// CQ 码格式消息
        /// </summary>
        [JsonProperty("raw_message")]
        public string RawMessage { get; set; } = "";

        /// <summary>
        /// 字体
        /// </summary>
        [JsonProperty("font")]
        public int Font { get; set; }

        /// <summary>
        /// 发送人信息
        /// </summary>
        [JsonProperty("sender")]
        public Sender Sender { get; set; } = new();

        /// <summary>
        /// 消息内容
        /// </summary>
        [JsonProperty("message")]
        public MessageChain Message { get; set; } = new();
    }
}
