﻿using Newtonsoft.Json;
using UnifyBot.Api;
using UnifyBot.Model;
using static UnifyBot.Utils.JsonConvertTool;

namespace UnifyBot.Receiver.EventReceiver.Notice
{
    /// <summary>
    /// 群成员增加
    /// </summary>
    public class GroupMemberIncrease : EventReceiver
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        public override NoticeType NoticeEventType => NoticeType.GroupIncrease;

        /// <summary>
        /// 通知子类型
        /// </summary>
        [JsonProperty("sub_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public RequestSubType NoticeSubType { get; set; }

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
        /// 操作人qq
        /// </summary>
        [JsonProperty("operator_id")]
        public long OperatorQQ { get; set; }

        #region 扩展属性/方法
        /// <summary>
        /// 加群人信息
        /// </summary>
        [JsonIgnore]
        public GroupMemberInfo User => Connect.GetGroupMemberInfo(GroupQQ, QQ).Result;
        #endregion
    }
}
