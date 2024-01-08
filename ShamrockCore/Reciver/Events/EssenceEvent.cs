using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Reciver.Events
{
    /// <summary>
    /// 精华消息
    /// </summary>
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
        /// 子类型
        /// </summary>
        [JsonProperty("sub_type")]
        public EssenceType SubType { get; set; }

        #region 扩展方法/属性
        /// <summary>
        /// 精华消息对象
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
        private Lazy<MsgInfo?>? _message;

        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonIgnore]
        public override PostEventType EventType { get; set; } = PostEventType.Essence;
        #endregion
    }
}
