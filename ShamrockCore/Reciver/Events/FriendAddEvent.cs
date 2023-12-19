using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Reciver.Events
{
    /// <summary>
    /// 好友添加申请事件
    /// </summary>
    public class FriendAddEvent : EventBase
    {
        /// <summary>
        /// 申请人
        /// </summary>
        [JsonProperty("operator_id")]
        public long OperatorId { get; set; }

        /// <summary>
        /// 验证信息
        /// </summary>
        [JsonProperty("tip_text")]
        public string TipText { get; set; } = "";

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
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public async Task<bool> Reject(string remark = "") => await Api.SetFriendAddRequest(Flag, false, remark);
        #endregion
    }
}
