using Newtonsoft.Json;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 好友
    /// </summary>
    public record Stranger
    {
        /// <summary>
        /// 好友的资料
        /// </summary>
        //[JsonIgnore] public Profile FriendProfile => this.GetFriendProfileAsync().GetAwaiter().GetResult();

        /// <summary>
        ///     QQ号
        /// </summary>
        [JsonProperty("user_id")]
        public long Id { get; set; }

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
    }
}