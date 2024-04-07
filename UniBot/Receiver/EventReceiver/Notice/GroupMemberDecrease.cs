﻿using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using UniBot.Model;
using static UniBot.Tools.JsonConvertTool;

namespace UniBot.Receiver.EventReceiver
{
    /// <summary>
    /// 群成员减少
    /// </summary>
    public class GroupMemberDecrease : EventReceiver
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
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// qq号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 操作者 QQ 号（如果是主动退群，则和 qq 相同）
        /// </summary>
        [JsonProperty("operator_id")]
        public virtual long OperatorQQ { get; set; }

        #region 扩展属性/方法
        /// <summary>
        /// 退群人信息
        /// </summary>
        [JsonIgnore]
        public Lazy<GroupMemberInfo> User => new(() => Connect.GetGroupMemberInfo(GroupQQ, QQ).Result);
        #endregion
    }
}
