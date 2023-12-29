using Newtonsoft.Json;

namespace ShamrockCore.Reciver.Events
{
    /// <summary>
    /// 群头衔变更
    /// </summary>
    public class TitleChangeEvent : EventBase
    {
        /// <summary>
        /// 操作者QQ
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 群号(仅群聊)
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 获得头衔
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; } = "";
    }
}
