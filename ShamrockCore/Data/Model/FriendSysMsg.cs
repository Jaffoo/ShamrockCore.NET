using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShamrockCore.Data.Model
{
    public class FriendSysMsg
    {
        /// <summary>
        /// 请求id
        /// </summary>
        [JsonProperty("request_id")]
        public long RequestId { get; set; }

        /// <summary>
        /// 请求qq
        /// </summary>
        [JsonProperty("requester_uin")]
        public long QQ { get; set; }

        /// <summary>
        /// 请求昵称
        /// </summary>
        [JsonProperty("requester_nick")]
        public string Nickname { get; set; } = "";

        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; } = "";

        /// <summary>
        /// 附加消息
        /// </summary>
        public string Message { get; set; } = "";

        /// <summary>
        /// 来源群名称，仅当从群添加好友时存在
        /// </summary>
        [JsonProperty("source_group_name")]
        public string GroupName { get; set; } = "";

        /// <summary>
        /// 来源群号，仅当从群添加好友时存在
        /// </summary>
        [JsonProperty("source_group_id")]
        public long GroupId { get; set; }

        /// <summary>
        /// 处理结果
        /// </summary>
        [JsonProperty("msg_detail")]
        public string MsgDetail { get; set; } = "";

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; } = "";

        /// <summary>
        /// 已同意、已拒绝，为空则表示尚未处理
        /// </summary>
        public string Status { get; set; } = "";

        /// <summary>
        /// 用于处理请求
        /// </summary>
        public string Flag { get; set; } = "";
    }
}
