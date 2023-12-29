using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
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
        /// 消息内容
        /// </summary>
        [JsonProperty("message")]
        public MessageChain Message { get; set; } = new();

        #region 扩展方法/属性
        /// <summary>
        /// 群信息
        /// </summary>
        /// <returns></returns>
        public Group Group => Api.GetGroupInfo(GroupId).Result!;

        /// <summary>
        /// 发送者成员信息
        /// </summary>
        public Member Sender => Api.GetGroupMemberInfo(GroupId, QQ).Result!;
        #endregion
    }
}
