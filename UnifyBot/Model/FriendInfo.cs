using Newtonsoft.Json;
using UnifyBot.Api;
using UnifyBot.Message.Chain;
using static UnifyBot.Utils.JsonConvertTool;

namespace UnifyBot.Model
{
    /// <summary>
    /// 好友信息
    /// </summary>
    public class FriendInfo : ModelBase
    {
        /// <summary>
        /// qq
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; } = "";

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = "";

        /// <summary>
        /// 年龄
        /// </summary>
        [JsonProperty("age")]
        public string Age { get; set; } = "";

        /// <summary>
        /// 等级
        /// </summary>
        [JsonProperty("level")]
        public string Level { get; set; } = "";

        /// <summary>
        /// 性别
        /// </summary>
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        [JsonProperty("sex")]
        public Genders Sex { get; set; }

        #region 扩展方法/属性
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendMessage(MessageChain msg) => await Connect.SendPrivateMsg(QQ, msg);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendMessage(string msg) => await Connect.SendPrivateMsg(QQ, msg);

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="times">次数</param>
        /// <returns></returns>
        public async Task<bool> Like(int times = 10) => await Connect.SendLike(times);
        #endregion
    }
}
