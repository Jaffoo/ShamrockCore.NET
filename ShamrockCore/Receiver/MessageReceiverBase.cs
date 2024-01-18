using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Receiver
{
    public class MessageReceiverBase
    {
        /// <summary>
        /// 发送时间
        /// </summary>
        [JsonProperty("time")]
        public long Time { get; set; }

        /// <summary>
        /// 机器人qq
        /// </summary>
        [JsonProperty("self_id")]
        public long SelfId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("post_type")]
        public string PostType { get; set; } = "";

        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        /// <summary>
        /// 消息制造者/事件被动者
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        #region 扩展方法/属性
        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <returns></returns>
        public async Task Recall() => await Api.DeleteMsg(MessageId);

        /// <summary>
        /// 设置精华消息
        /// </summary>
        /// <returns></returns>
        public async Task SetEssenceMsg() => await Api.SetEssenceMsg(MessageId);

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonIgnore]
        public virtual PostMessageType Type { get; set; }
        #endregion
    }
}
