using Newtonsoft.Json;

namespace ShamrockCore.Reciver.Events
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
    }
}
