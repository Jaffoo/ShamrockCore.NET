using Newtonsoft.Json;

namespace ShamrockCore.Reciver.Events
{
    public class PokeEvent : EventBase
    {
        /// <summary>
        /// 发送者 QQ
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 群号(仅群聊)
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 好友 QQ (仅私聊)
        /// </summary>
        [JsonProperty("sender_id")]
        public long SenderQQ { get; set; }

        /// <summary>
        /// 被戳者 QQ
        /// </summary>
        [JsonProperty("target_id")]
        public long TargetQQ { get; set; }

        /// <summary>
        /// 戳一戳的详细信息
        /// </summary>
        [JsonProperty("poke_detail")]
        public PokeDetail PokeDetail { get; set; } = new();
    }

    /// <summary>
    /// 戳一戳的详细信息
    /// </summary>
    public class PokeDetail
    {
        /// <summary>
        /// 操作名称，如“戳了戳”
        /// </summary>
        public string Action { get; set; } = "";

        /// <summary>
        /// 后缀，未设置则未空
        /// </summary>
        public string Suffix { get; set; } = "";

        /// <summary>
        /// 操作图标
        /// </summary>
        [JsonProperty("action_img_url")]
        public string Icon { get; set; } = "";
    }
}
