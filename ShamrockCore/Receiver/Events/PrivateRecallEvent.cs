﻿using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Receiver.Events
{
    /// <summary>
    /// 私聊撤回
    /// </summary>
    public class PrivateRecallEvent : EventBase
    {
        /// <summary>
        /// 好友 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 操作者 QQ 号
        /// </summary>
        [JsonProperty("operator_id")]
        public long OperatorQQ { get; set; }

        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        #region 扩展方法/属性
        /// <summary>
        /// 撤回消息对象
        /// </summary>
        [JsonIgnore]
        public MsgInfo? Message
        {
            get
            {
                _message ??= new(() => Api.GetMsg(MessageId).Result);
                return _message.Value;
            }
        }
        [JsonIgnore] private Lazy<MsgInfo?>? _message;

        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonIgnore]
        public override PostEventType EventType { get; set; } = PostEventType.FriendRecall;
        #endregion
    }
}
