using Newtonsoft.Json;
using static UniBot.Tools.JsonConvertTool;

namespace UniBot.Model
{
    /// <summary>
    /// 群成员信息
    /// </summary>
    public class GroupMemberInfo
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// qq
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [JsonProperty("nickname")]
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

        /// <summary>
        /// 加入时间
        /// </summary>
        [JsonProperty("join_tile")]
        public long JoinTime { get; set; }

        /// <summary>
        /// 最后发言时间
        /// </summary>
        [JsonProperty("last_send_time")]
        public long LastActive { get; set; }

        /// <summary>
        /// 头衔过期时间
        /// </summary>
        [JsonProperty("title_expire_time")]
        public long TitleExpire {  get; set; }

        /// <summary>
        /// 是否允许修改群名片
        /// </summary>
        [JsonProperty("card_changeable")]
        public bool CardChangeable { get; set; }
    }
}
