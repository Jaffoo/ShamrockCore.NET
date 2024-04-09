using Newtonsoft.Json;
using static UnifyBot.Utils.JsonConvertTool;

namespace UnifyBot.Model
{
    /// <summary>
    /// 基础信息
    /// </summary>
    public class UserBaseInfo
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
    }

    /// <summary>
    /// 陌生人信息
    /// </summary>
    public class StrangerInfo : UserBaseInfo
    {
        /// <summary>
        /// 性别
        /// </summary>
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public Genders Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
    }
}
