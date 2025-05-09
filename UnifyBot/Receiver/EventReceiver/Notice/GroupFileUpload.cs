﻿using Newtonsoft.Json;
using UnifyBot.Model;

namespace UnifyBot.Receiver.EventReceiver.Notice
{
    /// <summary>
    /// 群文件上传
    /// </summary>
    public class GroupFileUpload : EventReceiver
    {
        /// <summary>
        /// 通知类型
        /// </summary>
        public override NoticeType NoticeEventType => NoticeType.GroupUpload;

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 上传 QQ 号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 文件
        /// </summary>
        public Model.FileInfo File { get; set; } = new FileInfo();
    }
}
