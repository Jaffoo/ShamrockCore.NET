using Newtonsoft.Json;
using UniBot.Message.Chain;
using static UniBot.Tools.JsonConvertTool;

namespace UniBot.Model
{
    /// <summary>
    /// 陌生人信息
    /// </summary>
    public class StrangerInfo
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
