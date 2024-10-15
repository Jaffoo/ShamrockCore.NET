using Newtonsoft.Json;
using System.Threading.Tasks;
using UnifyBot.Api;
using UnifyBot.Message.Chain;
using UnifyBot.Model;
using static UnifyBot.Utils.JsonConvertTool;

namespace UnifyBot.Receiver.MessageReceiver
{
    public class MessageReceiver : MessageReceiverBase
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("message_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public virtual MessageType MessageType { get; set; }

        /// <summary>
        /// 消息子类型
        /// </summary>
        [JsonProperty("sub_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public MessageSubType MessageSubType { get; set; }

        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        /// <summary>
        /// 发送人qq
        /// </summary>
        [JsonProperty("user_id")]
        public long SenderQQ { get; set; }

        /// <summary>
        /// 原始CQ消息码
        /// </summary>
        [JsonProperty("raw_message")]
        public string RawMessage { get; set; } = "";

        /// <summary>
        /// 字体
        /// </summary>
        public int Font { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public virtual MessageChain Message { get; set; } = new MessageChain();

        #region 扩展方法/属性
        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Recall() => await Connect!.MessageRecal(MessageId);
        #endregion
    }
}
