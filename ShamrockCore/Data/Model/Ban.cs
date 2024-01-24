using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 群禁言人
    /// </summary>
    public record Banner
    {
        /// <summary>
        /// 被禁言的人
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 禁言结束时间
        /// </summary>
        public long Time { get; set; }

        /// <summary>
        /// 群
        /// </summary>
        public long GroupQQ { get; set; }

        /// <summary>
        /// 禁言
        /// </summary>
        /// <param name="time">禁言时长</param>
        /// <returns></returns>
        public async Task<bool> Ban(long time) => await Api.SetGroupBan(GroupQQ, QQ, time);

        /// <summary>
        /// 解除禁言
        /// </summary>
        /// <param name="time">禁言时长</param>
        /// <returns></returns>
        public async Task<bool> NoBan() => await Api.SetGroupBan(GroupQQ, QQ, 0);
    }
}
