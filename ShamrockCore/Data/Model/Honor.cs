using Newtonsoft.Json;
using System.Collections.Generic;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 群荣誉信息
    /// </summary>
    public record Honor
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 当前龙王
        /// </summary>
        [JsonProperty("current_talkative")]
        public List<HonorInfo>? CurrentTalkative { get; set; } = null;

        /// <summary>
        /// 历史龙王
        /// </summary>
        [JsonProperty("talkative_list")]
        public List<HonorInfo>? TalkativeList { get; set; } = null;

        /// <summary>
        /// 群聊之火
        /// </summary>
        [JsonProperty("performer_list")]
        public List<HonorInfo>? PerformerList { get; set; } = null;

        /// <summary>
        /// 群聊炽焰
        /// </summary>
        [JsonProperty("legend_list")]
        public List<HonorInfo>? LegendList { get; set; } = null;

        /// <summary>
        /// 冒尖小春笋
        /// </summary>
        [JsonProperty("strong_newbie_list")]
        public List<HonorInfo>? StrongNewbieList { get; set; } = null;

        /// <summary>
        /// 快乐之源
        /// </summary>
        [JsonProperty("emotion_list")]
        public List<HonorInfo>? EmotionList { get; set; } = null;

        /// <summary>
        /// 全部荣誉
        /// </summary>
        [JsonProperty("all")]
        public List<HonorInfo>? All { get; set; } = null;

    }

    /// <summary>
    /// 详情
    /// </summary>
    public record HonorInfo
    {
        /// <summary>
        /// QQ
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; } = "";

        /// <summary>
        /// 头像链接
        /// </summary>
        public string Avatar { get; set; } = "";

        /// <summary>
        /// 持续天数
        /// </summary>
        [JsonProperty("day_count")]
        public int DayCount { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        [JsonProperty("id")]
        public string HonorId { get; set; } = "";

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; } = "";
    }
}