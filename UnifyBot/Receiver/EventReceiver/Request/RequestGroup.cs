using Newtonsoft.Json;
using UnifyBot.Api;
using UnifyBot.Model;
using static UnifyBot.Utils.JsonConvertTool;

namespace UnifyBot.Receiver.EventReceiver.Request
{
    /// <summary>
    /// 加群请求／邀请
    /// </summary>
    public class RequestGroup : EventReceiver
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        public override RequestType RequestEventType => RequestType.Group;

        /// <summary>
        /// 请求子类型
        /// </summary>
        [JsonProperty("sub_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public RequestSubType RequestSubType { get; set; }

        /// <summary>
        /// 新添加好友 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public string QQ { get; set; } = "";

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 验证信息
        /// </summary>
        public string Common { get; set; } = "";

        /// <summary>
        /// 请求 flag，在调用处理请求的 API 时需要传入
        /// </summary>
        public string Flag { get; set; } = "";

        #region 扩展属性/方法
        /// <summary>
        /// 群信息
        /// </summary>
        [JsonIgnore]
        public GroupInfo Group => Connect.GetGroupInfo(GroupQQ).Result;
        
        /// <summary>
        /// 同意
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Agree() => await Connect.SetGroupAddRequest(Flag, RequestSubType);

        /// <summary>
        /// 拒绝
        /// </summary>
        /// <param name="reson">拒绝理由</param>
        /// <returns></returns>
        public async Task<bool> Reject(string reson = "") => await Connect.SetGroupAddRequest(Flag, RequestSubType, false, reson);
        #endregion
    }
}
