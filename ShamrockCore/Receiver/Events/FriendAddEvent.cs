﻿using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Receiver.Events
{
    /// <summary>
    /// 好友添加申请事件
    /// </summary>
    public class FriendAddEvent : EventBase
    {
        /// <summary>
        /// 请求者 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 验证信息
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; } = "";

        /// <summary>
        /// 事件标识
        /// </summary>
        public string Flag { get; set; } = "";


        #region 扩展方法/属性
        /// <summary>
        /// 同意好友请求
        /// </summary>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public async Task<bool> Agree(string remark = "") => await Api.SetFriendAddRequest(Flag, true, remark);

        /// <summary>
        /// 拒绝好友请求
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Reject() => await Api.SetFriendAddRequest(Flag, false);

        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonIgnore]
        public override PostEventType EventType { get; set; } = PostEventType.Friend;
        #endregion
    }
}
