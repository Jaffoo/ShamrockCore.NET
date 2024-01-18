using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Data.Model;
using ShamrockCore.Receiver.MsgChain;

namespace ShamrockCore.Receiver.Receivers
{
    /// <summary>
    /// 好友接收器
    /// </summary>
    public class FriendReceiver : MessageReceiverBase
    {
        /// <summary>
        /// 私聊者qq
        /// </summary>
        [JsonProperty("target_id")]
        public long TargetQQ { get; set; }

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
        /// 消息内容
        /// </summary>
        [JsonProperty("message")]
        public MessageChain? Message { get; set; } = null;

        #region 扩展方法/属性
        /// <summary>
        /// 好友信息
        /// </summary>
        [JsonIgnore]
        public Friend? Sender
        {
            get
            {
                _sender ??= new(() => Api.GetFriends().Result?.FirstOrDefault(t => t.QQ == QQ));
                return _sender.Value;
            }
        }
        [JsonIgnore] private Lazy<Friend?>? _sender;

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonIgnore]
        public override PostMessageType Type { get; set; } = PostMessageType.Friend;
        #endregion
    }
}
