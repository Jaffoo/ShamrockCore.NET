using Newtonsoft.Json;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Receiver.Events
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
        public AdminType SubType { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonIgnore]
        public override PostEventType EventType { get; set; } = PostEventType.GroupAdmin;
    }
}
