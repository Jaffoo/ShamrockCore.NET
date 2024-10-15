using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnifyBot.Model;
using static UnifyBot.Utils.JsonConvertTool;

namespace UnifyBot.Receiver
{
    public class MessageReceiverBase
    {
        /// <summary>
        /// 事件发生的时间戳
        /// </summary>
        public long Time { get; set; }

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

        /// <summary>
        /// 连接配置信息
        /// </summary>
        [JsonIgnore]
        public Connect Connect { get; set; } = new Connect("", 0, 0);
    }
}
