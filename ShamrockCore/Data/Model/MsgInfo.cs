using Newtonsoft.Json;
using ShamrockCore.Reciver.MsgChain;

namespace ShamrockCore.Data.Model
{
    public record MsgInfo
    {
        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        /// <summary>
        /// 发送时间
        /// </summary>
        [JsonProperty("time")]
        public long Time { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("message_type")]
        public string MessageType { get; set; } = "";

        /// <summary>
        /// 消息接收者，群聊是群号，私聊时是目标QQ
        /// </summary>
        [JsonProperty("peer_id")]
        public long PeerId { get; set; }

        /// <summary>
        /// 真实 ID
        /// </summary>
        [JsonProperty("real_id")]
        public long RealId { get; set; }


        /// <summary>
        /// 发送人信息
        /// </summary>
        public SenderInfo? Sender { get; set; } = null;

        /// <summary>
        /// 消息内容
        /// </summary>
        public MessageChain Message { get; set; } = new();

        /// <summary>
        /// 群id
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// 消息目标（私聊）
        /// </summary>
        [JsonProperty("target_id")]
        public long TargetId { get; set; }
    }

    public class SenderInfo
    {
        /// <summary>
        /// QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        ///  性别
        /// </summary>
        public string Sex { get; set; } = "";

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; } = "";

        /// <summary>
        /// UID
        /// </summary>
        public string Uid { get; set; } = "";
    }
}
