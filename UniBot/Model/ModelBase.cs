using Newtonsoft.Json;

namespace UnifyBot.Model
{
    public class ModelBase
    {
        /// <summary>
        /// 连接配置信息
        /// </summary>
        [JsonIgnore]
        public Connect Connect { get; set; } = new("", 0, 0);
    }
}
