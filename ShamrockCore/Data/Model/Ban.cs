using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 群禁言人
    /// </summary>
    public record Ban
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
        /// 取消禁言
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Cancel() => await Api.SetGroupBan(GroupQQ, QQ, 0);

        /// <summary>
        /// 再次禁言
        /// </summary>
        /// <param name="time">禁言时长</param>
        /// <returns></returns>
        public async Task<bool> BanLonger(long time) => await Api.SetGroupBan(GroupQQ, QQ, time);
    }
}
