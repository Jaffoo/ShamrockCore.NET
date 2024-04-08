using Newtonsoft.Json;
using UniBot.Api;
using UniBot.Model;
using static UniBot.Utils.JsonConvertTool;

namespace UniBot.Receiver.EventReceiver
{
    /// <summary>
    /// 好友添加请求
    /// </summary>
    public class RequestFriend : EventReceiver
    {
        /// <summary>
        /// 请求类型
        /// </summary>
        [JsonProperty("request_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public RequestType RequestType { get; set; }

        /// <summary>
        /// 新添加好友 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public string QQ { get; set; } = "";

        /// <summary>
        /// 验证信息
        /// </summary>
        public string Common { get; set; } = "";

        /// <summary>
        /// 请求 flag，在调用处理请求的 API 时需要传入
        /// </summary>
        public string Flag { get; set; } = "";

        #region 扩展方法/属性
        /// <summary>
        /// 同意
        /// </summary>
        /// <param name="remark">好友备注</param>
        /// <returns></returns>
        public async Task<bool> Agree(string remark = "") => await Connect.SetFriendAddRequest(QQ, true, remark);

        /// <summary>
        /// 拒绝
        /// </summary>
        /// <param name="remark">好友备注</param>
        /// <returns></returns>
        public async Task<bool> Reject() => await Connect.SetFriendAddRequest(QQ, false);
        #endregion
    }
}
