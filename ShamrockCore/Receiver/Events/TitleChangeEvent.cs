using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Receiver.Events
{
    /// <summary>
    /// 群头衔变更
    /// </summary>
    public class TitleChangeEvent : EventBase
    {
        /// <summary>
        /// 操作者QQ
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 群号(仅群聊)
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 获得头衔
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; } = "";

        #region 扩展方法/属性
        /// <summary>
        /// 成员
        /// </summary>
        [JsonIgnore]
        public Member? Member
        {
            get
            {
                _member ??= new(() => Api.GetGroupMemberInfo(QQ, GroupQQ).Result);
                return _member.Value;
            }
        }
        private Lazy<Member?>? _member;

        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonIgnore]
        public override PostEventType EventType { get; set; } = PostEventType.Title;
        #endregion
    }
}
