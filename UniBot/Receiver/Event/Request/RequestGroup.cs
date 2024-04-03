using Newtonsoft.Json;
using UniBot.Model;
using static UniBot.Tools.JsonConvertTool;

namespace UniBot.Receiver.Event.Request
{
    /// <summary>
    /// 加群请求／邀请
    /// </summary>
    public class RequestGroup : MsgReceiverBase
    {
        /// <summary>
        /// 请求类型
        /// </summary>
        [JsonProperty("request_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public RequestType RequestType { get; set; }

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
    }
}
