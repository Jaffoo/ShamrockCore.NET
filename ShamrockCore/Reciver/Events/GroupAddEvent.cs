using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Reciver.Events
{
    /// <summary>
    /// 加群请求／邀请事件
    /// </summary>
    public class GroupAddEvent : EventBase
    {
        /// <summary>
        /// 请求者 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 验证信息
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; } = "";

        /// <summary>
        /// 事件标识
        /// </summary>
        public string Flag { get; set; } = "";

        /// <summary>
        /// 子类型(add/invite)
        /// </summary>
        [JsonProperty("sub_type")]
        public string SubType { get; set; } = "";

        #region 扩展方法/属性
        /// <summary>
        /// 同意加群请求
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Agree() => await Api.SetGroupAddRequest(Flag, SubType, true);

        /// <summary>
        /// 拒绝加群请求
        /// </summary>
        /// <param name="remark">拒绝理由</param>
        /// <returns></returns>
        public async Task<bool> Reject(string remark = "") => await Api.SetGroupAddRequest(Flag, SubType, false, remark);
        #endregion
    }
}
