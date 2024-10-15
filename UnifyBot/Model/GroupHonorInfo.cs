using Newtonsoft.Json;
using System.Collections.Generic;

namespace UnifyBot.Model
{
    /// <summary>
    /// 群荣誉信息
    /// </summary>
    public class GroupHonorInfo
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
        public DragonKing CurentDragon { get; set; } = new DragonKing();

        /// <summary>
        /// 历史龙王
        /// </summary>
        [JsonProperty("talkative_list")]
        public List<DragonKing> OldDragon { get; set; } = new List<DragonKing>();

        /// <summary>
        /// 群聊之火
        /// </summary>
        [JsonProperty("performer_list")]
        public List<ActiveInfo> PerformerList { get; set; } = new List<ActiveInfo>();

        /// <summary>
        /// 群聊炽焰
        /// </summary>
        [JsonProperty("legend_list")]
        public List<ActiveInfo> LegendList { get; set; } = new List<ActiveInfo>();

        /// <summary>
        /// 冒尖小春笋
        /// </summary>
        [JsonProperty("strong_newbie_list")]
        public List<ActiveInfo> StrongNewbieLIst { get; set; } = new List<ActiveInfo>();

        /// <summary>
        /// 快乐之源
        /// </summary>
        [JsonProperty("emotion_list")]
        public List<ActiveInfo> EmotionList { get; set; } = new List<ActiveInfo>();
    }

    /// <summary>
    /// 基础信息
    /// </summary>
    public class BaseInfo
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
        /// 头像
        /// </summary>
        public string Avatar { get; set; } = "";
    }

    /// <summary>
    /// 龙王
    /// </summary>
    public class DragonKing : BaseInfo
    {
        /// <summary>
        /// 持续天数
        /// </summary>
        [JsonProperty("day_count")]
        public int Day { get; set; }
    }

    /// <summary>
    /// 活跃状态信息
    /// </summary>
    public class ActiveInfo : BaseInfo
    {
        /// <summary>
        /// 荣誉描述
        /// </summary>
        public string Description { get; set; } = "";
    }
}
