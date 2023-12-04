using Newtonsoft.Json;

namespace Shamrock.Net.Data.Shared
{
    /// <summary>
    /// 好友
    /// </summary>
    public record Friend
    {
        /// <summary>
        /// 好友的资料
        /// </summary>
        [JsonIgnore] public Profile FriendProfile => this.GetFriendProfileAsync().GetAwaiter().GetResult();

        /// <summary>
        ///     好友的QQ号
        /// </summary>
        [JsonProperty("user_id")]
        public long Id { get; set; }

        /// <summary>
        ///     好友的备注
        /// </summary>
        [JsonProperty("user_remark")]
        public string RemarkName { get; set; }

        /// <summary>
        ///     好友的昵称
        /// </summary>
        [JsonProperty("user_displayname")]
        public string NickName { get; set; }

        /// <summary>
        ///     好友的年龄
        /// </summary>
        [JsonProperty("age")]
        public string Age { get; set; }

        /// <summary>
        ///     好友的性别
        /// </summary>
        [JsonProperty("gender")]
        public int Gender { get; set; }

        /// <summary>
        ///     分组 ID
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        ///     平台
        /// </summary>
        [JsonProperty("platform")]
        public object Platform { get; set; }

        /// <summary>
        ///     终端类型
        /// </summary>
        [JsonProperty("term_type")]
        public string TermType { get; set; }
    }
}