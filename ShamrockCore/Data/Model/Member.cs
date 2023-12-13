using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    ///     群成员
    /// </summary>
    public record Member
    {
        /// <summary>
        /// 群员资料
        /// </summary>
        //[JsonIgnore] public Profile MemberProfile => this.GetMemberProfileAsync().GetAwaiter().GetResult();

        /// <summary>
        ///     群员的QQ号
        /// </summary>
        [JsonProperty("user_id")]
        public long Id { get; set; }

        /// <summary>
        ///     群QQ号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        ///     群员的群名片
        /// </summary>
        [JsonProperty("user_name")]
        public string Name { get; set; } = "";

        /// <summary>
        ///     性别
        /// </summary>
        [JsonProperty("sex")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Genders Sex { get; set; }

        /// <summary>
        ///     操作者在群中的权限
        /// </summary>
        [JsonProperty("role")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions Role { get; set; }

        /// <summary>
        ///     操作者的群头衔
        /// </summary>
        [JsonProperty("title")]
        public string SpecialTitle { get; set; } = "";

        /// <summary>
        ///     专属头衔过期时间戳
        /// </summary>
        [JsonProperty("title_expire_time")]
        public long TitleExpireTime { get; set; }

        /// <summary>
        ///     加入时间戳
        /// </summary>
        [JsonProperty("join_time")]
        public string JoinTime { get; set; } = "";

        /// <summary>
        ///     最后发言时间戳
        /// </summary>
        [JsonProperty("last_sent_time")]
        public string LastSpeakTime { get; set; } = "";

        /// <summary>
        ///     最后活跃时间戳
        /// </summary>
        [JsonProperty("last_active_time")]
        public string LastActiveTime { get; set; } = "";

        /// <summary>
        ///     群头衔
        /// </summary>
        [JsonProperty("unique_name")]
        public string UniqueName { get; set; } = "";

        /// <summary>
        ///     群昵称
        /// </summary>
        [JsonProperty("nickname")]
        public string GroupName { get; set; } = "";

        /// <summary>
        ///     显示名
        /// </summary>
        [JsonProperty("user_displayname")]
        public string DisplayName { get; set; } = "";

        /// <summary>
        ///     距离
        /// </summary>
        [JsonProperty("distance")]
        public int Distance { get; set; }

        /// <summary>
        ///     地区
        /// </summary>
        [JsonProperty("area")]
        public int Area { get; set; }

        /// <summary>
        ///     等级
        /// </summary>
        [JsonProperty("level")]
        public int Level { get; set; }

        /// <summary>
        ///     是否不良记录成员
        /// </summary>
        [JsonProperty("unfriendly")]
        public bool Unfriendly { get; set; }

        /// <summary>
        ///     是否允许修改群名片
        /// </summary>
        [JsonProperty("card_changeable")]
        public bool CanChangeCard { get; set; }

        /// <summary>
        ///     群荣誉
        /// </summary>
        [JsonProperty("honor")]
        public List<int> Honor { get; set; } = [];
    }
}
