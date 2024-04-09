using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using UnifyBot.Model;
using static UniBot.Tools.JsonConvertTool;

namespace UnifyBot.Receiver.EventReceiver.Notice
{
    public class FriendAdd : EventReceiver
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        [JsonProperty("notice_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public NoticeType NoticeType { get; set; }

        /// <summary>
        /// 新添加好友 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        #region 扩展属性/方法
        /// <summary>
        /// 好友信息
        /// </summary>
        [JsonIgnore]
        public Lazy<FriendInfo?> Friend
        {
            get
            {
                var lazyFriend = new Lazy<FriendInfo?>(() => Connect.GetFriendList().Result.FirstOrDefault(x => x.QQ == QQ));
                return lazyFriend;
            }
        }
        #endregion
    }
}
