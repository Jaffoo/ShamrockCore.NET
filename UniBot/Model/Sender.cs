using Newtonsoft.Json;
using static UniBot.Tools.JsonConvertTool;

namespace UniBot.Model
{
    /// <summary>
    /// 信息发送人
    /// </summary>
    public class Sender
    {
        /// <summary>
        /// 发送者qq
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

    public class GroupSender
    {
        /// <summary>
        /// 群名片／备注
        /// </summary>
        public string Card { get; set; } = "";

        /// <summary>
        /// 地区
        /// </summary>
        public string Area { get; set; } = "";

        /// <summary>
        /// 成员等级
        /// </summary>
        public string Level { get; set; } = "";

        /// <summary>
        /// 专属头衔
        /// </summary>
        public string Title { get; set; } = "";

        /// <summary>
        /// 专属头衔
        /// </summary>
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public Permissions Role { get; set; }
    }
}
