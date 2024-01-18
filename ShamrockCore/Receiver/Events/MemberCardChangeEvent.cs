using Newtonsoft.Json;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Receiver.Events
{
    public class MemberCardChangeEvent : EventBase
    {
        /// <summary>
        /// 变动成员 QQ
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 新名片
        /// </summary>
        [JsonProperty("card_new")]
        public string CardNew { get; set; } = "";

        /// <summary>
        /// 旧名片
        /// </summary>
        [JsonProperty("card_old")]
        public string CardOld { get; set; } = "";

        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonIgnore]
        public override PostEventType EventType { get; set; } = PostEventType.GroupCard;
    }
}
