using Newtonsoft.Json;

namespace UniBot.Model
{
    /// <summary>
    /// 好友信息
    /// </summary>
    public class FriendInfo
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
    }
}
