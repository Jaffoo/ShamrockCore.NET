using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 陌生人信息
    /// </summary>
    public record Stranger
    {
        /// <summary>
        ///     QQ号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        ///     昵称
        /// </summary>
        public string Nickname { get; set; } = "";

        /// <summary>
        ///         年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        ///     性别
        /// </summary>
        public string Sex { get; set; } = "";

        /// <summary>
        ///     等级
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     登录天数
        /// </summary>
        [JsonProperty("login_days")]
        public int LoginDays { get; set; }

        #region 扩展方法/属性
        /// <summary>
        /// 资料卡点赞
        /// </summary>
        /// <param name="times">次数</param>
        /// <returns></returns>
        public async Task<bool?> Like(int times = 20)
        {
            var b = await Api.SendLike(QQ, times);
            return b;
        }
        #endregion
    }
}