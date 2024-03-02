using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Data.Model;
using ShamrockCore.Receiver.MsgChain;

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

        /// <summary>
        /// 字体
        /// </summary>
        public int Font { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public MessageChain Message { get; set; } = new();

        /// <summary>
        /// 发送人
        /// </summary>
        public GuildSender Sender { get; set; } = new();

        #region 扩展方法/属性
        private Lazy<GuildProfile?>? _guild;
        /// <summary>
        /// 频道信息
        /// </summary>
        public GuildProfile? Guild
        {
            get
            {
                _guild ??= new(() =>
                {
                    var list = Api.GetGuildList().Result;
                    return list?.FirstOrDefault(t => t.GuildId == GuildId);
                });
                return _guild.Value;
            }
        }

        private Lazy<ChannelProfile?>? _channel;
        /// <summary>
        /// 子频道信息
        /// </summary>
        public ChannelProfile? Channel
        {
            get
            {
                _channel ??= new(() =>
                {
                    var list = Api.GetGuildChannelList(GuildId).Result;
                    return list?.FirstOrDefault(t => t.ChannelId == ChannelId);
                });
                return _channel.Value;
            }
        }

        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <returns></returns>
        public override async Task<bool> Recall()
        {
            await Task.Delay(1);
            throw new NotSupportedException("此功能不支持使用");
        }

        /// <summary>
        /// 设置精华消息
        /// </summary>
        /// <returns></returns>
        public override async Task<bool> SetEssenceMsg()
        {
            await Task.Delay(1);
            throw new NotSupportedException("此功能不支持使用");
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonIgnore]
        public override PostMessageType Type { get; set; } = PostMessageType.Guild;
        #endregion
    }
}
