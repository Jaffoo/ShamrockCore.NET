using Newtonsoft.Json;
using UnifyBot.Api;
using UnifyBot.Model;
using static UniBot.Tools.JsonConvertTool;

namespace UnifyBot.Receiver.EventReceiver.Notice
{
    /// <summary>
    /// 群消息撤回
    /// </summary>
    public class GroupMsgRecall : EventReceiver
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        [JsonProperty("notice_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public NoticeType NoticeType { get; set; }

        /// <summary>
        /// 消息发送者 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 操作人qq
        /// </summary>
        [JsonProperty("operator_id")]
        public long OperatorQQ { get; set; }

        /// <summary>
        /// 被撤回的消息 ID
        /// </summary>
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        #region 扩展属性/方法
        /// <summary>
        /// 消息
        /// </summary>
        [JsonIgnore]
        public Lazy<MessageInfo> Message => new(() => Connect.GetMsg(MessageId).Result);
        #endregion
    }
}
