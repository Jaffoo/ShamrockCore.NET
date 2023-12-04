using Newtonsoft.Json;
using System.Collections.Generic;

namespace Shamrock.Net.Data.Shared
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
        public List<InvitedRequest> InvitedRequest { get; set; }

        /// <summary>
        /// 进群消息列表
        /// </summary>
        [JsonProperty("join_requests")]
        public List<JoinRequest> JoinRequest { get; set; }
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
        public long GroupId { get; set; }

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
        [JsonProperty("flag")]
        public string Flag { get; set; }

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
        public long GroupId { get; set; }

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
        [JsonProperty("flag")]
        public string Flag { get; set; }

        /// <summary>
        /// 验证消息
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}