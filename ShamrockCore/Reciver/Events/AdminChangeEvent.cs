using Newtonsoft.Json;

namespace ShamrockCore.Reciver.Events
{
    public class AdminChangeEvent : EventBase
    {
        /// <summary>
        /// 变动成员 QQ
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 群qq
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 子类型(set,任命/unset,卸任)
        /// </summary>
        [JsonProperty("sub_type")]
        public string SubType { get; set; } = "";
    }
}
