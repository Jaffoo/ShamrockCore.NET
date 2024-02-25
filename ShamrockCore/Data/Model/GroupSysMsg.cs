﻿using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 群系统消息
    /// </summary>
    public record GroupSysMsg
    {
        /// <summary>
        /// 邀请消息列表
        /// </summary>
        [JsonProperty("invited_requests")]
        public List<InvitedRequest>? InvitedRequest { get; set; } = null;

        /// <summary>
        /// 进群消息列表
        /// </summary>
        [JsonProperty("join_requests")]
        public List<JoinRequest>? JoinRequest { get; set; } = null;
    }

    /// <summary>
    /// 邀请消息列表
    /// </summary>
    public record InvitedRequest
    {
        /// <summary>
        /// 请求ID
        /// </summary>
        [JsonProperty("request_id")]
        public long RequestId { get; set; }

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 群名
        /// </summary>
        [JsonProperty("group_name")]
        public long GroupName { get; set; }

        /// <summary>
        /// 邀请者
        /// </summary>
        [JsonProperty("invitor_uin")]
        public long InvitorUin { get; set; }

        /// <summary>
        /// 邀请者昵称
        /// </summary>
        [JsonProperty("invitor_nick")]
        public long InvitorNick { get; set; }

        /// <summary>
        /// 是否已被处理
        /// </summary>
        [JsonProperty("checked")]
        public bool Checked { get; set; }

        /// <summary>
        /// 处理者, 未处理为0
        /// </summary>
        [JsonProperty("actor")]
        public long Actor { get; set; }

        /// <summary>
        /// 被邀请者ID
        /// </summary>
        [JsonProperty("requester_uin")]
        public long RequesterUin { get; set; }

        /// <summary>
        /// flag,用于处理请求
        /// </summary>
        public string Flag { get; set; } = "";

        #region 扩展方法/属性
        /// <summary>
        /// 同意邀请进群
        /// </summary>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public async Task<bool> Agree(string remark = "") => await Api.SetGroupAddRequest(Flag, "invite", true, remark);

        /// <summary>
        /// 拒绝邀请进群
        /// </summary>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public async Task<bool> Reject(string remark = "") => await Api.SetGroupAddRequest(Flag, "invite", false, remark);
        #endregion
    }

    /// <summary>
    /// 进群消息列表
    /// </summary>
    public record JoinRequest
    {
        /// <summary>
        /// 请求ID
        /// </summary>
        [JsonProperty("request_id")]
        public long RequestId { get; set; }

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 群名
        /// </summary>
        [JsonProperty("group_name")]
        public long GroupName { get; set; }

        /// <summary>
        /// 请求者ID
        /// </summary>
        [JsonProperty("requester_uin")]
        public long RequesterUin { get; set; }

        /// <summary>
        /// 请求者昵称
        /// </summary>
        [JsonProperty("requester_nick")]
        public long RequesterNick { get; set; }

        /// <summary>
        /// 是否已被处理
        /// </summary>
        [JsonProperty("checked")]
        public bool Checked { get; set; }

        /// <summary>
        /// 处理者, 未处理为0
        /// </summary>
        [JsonProperty("actor")]
        public long Actor { get; set; }

        /// <summary>
        /// flag,用于处理请求
        /// </summary>
        public string Flag { get; set; } = "";

        /// <summary>
        /// 验证消息
        /// </summary>
        public string Message { get; set; } = "";

        #region 扩展方法/属性
        /// <summary>
        /// 同意邀请进群
        /// </summary>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public async Task<bool> Agree() => await Api.SetGroupAddRequest(Flag, "add", true);

        /// <summary>
        /// 拒绝邀请进群
        /// </summary>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public async Task<bool> Reject(string remark = "") => await Api.SetGroupAddRequest(Flag, "add", false, remark);
        #endregion
    }
}