using ShamrockCore.Data.HttpAPI;
using System.Text.Json.Serialization;

namespace UniBot.Model
{
    /// <summary>
    /// 匿名信息
    /// </summary>
    public class Anonymous : ModelBase
    {
        /// <summary>
        /// 匿名用户 ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 匿名用户名称
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 匿名用户 flag，在调用禁言 API 时需要传入
        /// </summary>
        public string Flag { get; set; } = "";

        #region 扩展方法/属性
        /// <summary>
        /// 群qq
        /// </summary>
        [JsonIgnore]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 禁言
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task<bool> Ban(int time = 30 * 60) => await Connect.SetGroupAnonymousBan(flag: Flag, groupQQ: GroupQQ, duration: time);
        #endregion
    }
}
