using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UniBot.Model;
using static UniBot.Tools.JsonConvertTool;

namespace UniBot.Receiver
{
    public class MsgReceiverBase
    {
        /// <summary>
        /// 事件发生的时间戳
        /// </summary>
        public long Time {  get; set; }

        /// <summary>
        /// 收到事件的机器人 QQ
        /// </summary>
        [JsonProperty("self_id")]
        public long BotQQ { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonProperty("post_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public PostType PostType { get; set; }

        /// <summary>
        /// 消息源数据
        /// </summary>
        [JsonIgnore]
        public JObject? OriginalData { get; set; }
    }
}
