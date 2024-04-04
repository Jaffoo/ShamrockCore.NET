using Newtonsoft.Json;

namespace UniBot.Model
{
    /// <summary>
    /// 群信息
    /// </summary>
    public class GroupInfo
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 群名
        /// </summary>
        [JsonProperty("group_name")]
        public string GroupName { get; set; } = "";

        /// <summary>
        /// 成员数
        /// </summary>
        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        /// <summary>
        /// 最大成员数
        /// </summary>
        [JsonProperty("max_memeber_count")]
        public int MaxCount { get; set; }
    }
}
