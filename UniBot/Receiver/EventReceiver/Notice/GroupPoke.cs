using Newtonsoft.Json;
using UniBot.Api;
using UniBot.Model;
using static UniBot.Utils.JsonConvertTool;

namespace UniBot.Receiver.EventReceiver.Notice
{
    /// <summary>
    /// 群戳一戳
    /// </summary>
    public class GroupPoke : EventReceiver
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        public override NoticeType NoticeEventType => NoticeType.Notify;

        /// <summary>
        /// 通知子类型
        /// </summary>
        [JsonProperty("sub_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public NoticeSubType NoticeSubType { get; set; }

        /// <summary>
        /// 发送者 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public long PokeQQ { get; set; }

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 被戳者 QQ 号
        /// </summary>
        [JsonProperty("target_id")]
        public long PokedQQ { get; set; }

        #region 扩展属性/方法
        /// <summary>
        /// 戳一戳人信息
        /// </summary>
        [JsonIgnore]
        public GroupMemberInfo Poke => Connect.GetGroupMemberInfo(GroupQQ, PokeQQ).Result;

        /// <summary>
        /// 被戳人信息
        /// </summary>
        [JsonIgnore]
        public GroupMemberInfo Poked => Connect.GetGroupMemberInfo(GroupQQ, PokedQQ).Result;
        #endregion
    }
}
