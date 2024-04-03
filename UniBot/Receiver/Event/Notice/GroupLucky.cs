using Newtonsoft.Json;
using UniBot.Model;
using static UniBot.Tools.JsonConvertTool;

namespace UniBot.Receiver.Event.Notice
{
    /// <summary>
    /// 红包运气王
    /// </summary>
    public class GroupLucky : MsgReceiverBase
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        [JsonProperty("notice_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public NoticeType NoticeType { get; set; }

        /// <summary>
        /// 通知子类型
        /// </summary>
        [JsonProperty("sub_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public NoticeSubType NoticeSubType { get; set; }

        /// <summary>
        /// 红包发送者 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 运气王 QQ 号
        /// </summary>
        [JsonProperty("target_id")]
        public long LuckyQQ { get; set; }
    }
}
