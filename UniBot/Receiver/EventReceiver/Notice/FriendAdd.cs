﻿using Newtonsoft.Json;
using UniBot.Api;
using UniBot.Model;

namespace UniBot.Receiver.EventReceiver.Notice
{
    public class FriendAdd : EventReceiver
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        public override NoticeType NoticeEventType { get; set; }= NoticeType.FriendAdd;

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
        public FriendInfo? Friend => Connect.GetFriendList().Result.FirstOrDefault(x => x.QQ == QQ);
        #endregion
    }
}
