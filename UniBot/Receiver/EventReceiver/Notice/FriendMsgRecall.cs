﻿using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using UniBot.Message.Chain;
using UniBot.Model;
using static UniBot.Tools.JsonConvertTool;

namespace UniBot.Receiver.EventReceiver
{
    /// <summary>
    /// 好友消息撤回
    /// </summary>
    public class FriendMsgRecall : EventReceiver
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
        /// 被撤回的消息 ID
        /// </summary>
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        #region 扩展方法/属性
        /// <summary>
        /// 被撤回的消息
        /// </summary>
        [JsonIgnore]
        public MessageInfo Message => Connect.GetMsg(MessageId).Result;
        #endregion
    }
}
