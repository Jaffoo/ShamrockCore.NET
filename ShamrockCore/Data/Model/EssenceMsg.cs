using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 精华消息
    /// </summary>
    public record EssenceMsg
    {
        /// <summary>
        /// 发送者QQ
        /// </summary>
        [JsonProperty("sender_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 发送者昵称
        /// </summary>
        [JsonProperty("sender_nick")]
        public string Name { get; set; } = "";

        /// <summary>
        /// 消息发送时间
        /// </summary>
        [JsonProperty("sender_time")]
        public long Time { get; set; }

        /// <summary>
        /// 操作者QQ
        /// </summary>
        [JsonProperty("operator_id")]
        public string OperatorQQ { get; set; } = "";

        /// <summary>
        /// 操作者
        /// </summary>
        [JsonProperty("operator_nick")]
        public string OperatorNick { get; set; } = "";

        /// <summary>
        /// 操作时间
        /// </summary>
        [JsonProperty("operator_time")]
        public string OperatorTime { get; set; } = "";

        /// <summary>
        /// 消息ID，可能为0表示找不到消息映射
        /// </summary>
        [JsonProperty("message_id")]
        public long MsgId { get; set; }

        /// <summary>
        /// 消息seq
        /// </summary>
        [JsonProperty("message_seq")]
        public long MsgSeq { get; set; }

        #region 扩展属性/方法
        /// <summary>
        /// 移除精华消息
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Remove() => await Api.DeleteEssenceMsg(MsgId);
        #endregion
    }
}