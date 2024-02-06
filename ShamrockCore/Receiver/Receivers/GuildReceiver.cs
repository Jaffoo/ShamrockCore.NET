using Newtonsoft.Json;

namespace ShamrockCore.Receiver.Receivers
{
    /// <summary>
    /// 频道消息
    /// </summary>
    public class GuildReceiver : MessageReceiverBase
    {
        /// <summary>
        /// 频道id
        /// </summary>
        [JsonProperty("guild_id")]
        public long GuildId { get; set; }

        /// <summary>
        /// 子频道id
        /// </summary>
        [JsonProperty("channel_id")]
        public long ChannelId { get; set; }
    }
}
