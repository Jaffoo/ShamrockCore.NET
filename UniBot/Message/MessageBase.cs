using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using UniBot.Model;

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
        /// 配置信息
        /// </summary>
        [JsonIgnore]
        public Connect Connect { get; set; } = new("", 0, 0);
    }
}
