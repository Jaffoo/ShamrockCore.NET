using Newtonsoft.Json;
using ShamrockCore.Data.Model;
using ShamrockCore.Reciver.MsgChain;

namespace ShamrockCore.Reciver.Receivers
{
    /// <summary>
    /// 群接收器
    /// </summary>
    public class GroupReceiver : MessageReceiverBase
    {
        /// <summary>
        /// 群id
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

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
    public class Sender
    {
        /// <summary>
        /// 发送者 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// 发送者昵称
        /// </summary>
        public string Nickname { get; set; } = "";

        /// <summary>
        /// 发送者群名片
        /// </summary>
        public string Card { get; set; } = "";

        /// <summary>
        /// 发送者群内权限
        /// </summary>
        public Permissions Role { get; set; }

        /// <summary>
        /// 发送者头衔
        /// </summary>
        public string Title { get; set; } = "";

        /// <summary>
        /// 发送者等级
        /// </summary>
        public string Level { get; set; } = "";
    }
}
