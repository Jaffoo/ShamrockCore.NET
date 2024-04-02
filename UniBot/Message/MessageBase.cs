using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using UniBot.Model;
using Newtonsoft.Json.Linq;

namespace UniBot.Message
{
    public class MessageBase
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Messages Type { get; set; }

        /// <summary>
        /// 消息体
        /// </summary>
        [JsonProperty("data")]
        public virtual dynamic? Data { get; set; }

        /// <summary>
        /// 原始数据
        /// </summary>
        [JsonIgnore]
        public JObject? OriginalData { get; set; }
    }
}
