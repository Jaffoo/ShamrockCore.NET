using Newtonsoft.Json;

namespace UniBot.Model
{
    public class ModelBase
    {
        /// <summary>
        /// 连接配置信息
        /// </summary>
        [JsonIgnore]
        public ConnectConf ConnectConf { get; set; } = new();
    }
}
