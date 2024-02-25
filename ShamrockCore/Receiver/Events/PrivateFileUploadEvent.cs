﻿using Newtonsoft.Json;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Receiver.Events
{
    /// <summary>
    /// 私聊文件上传
    /// </summary>
    public class PrivateFileUploadEvent : EventBase
    {
        /// <summary>
        /// 上传者 QQ
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 上传者 QQ
        /// </summary>
        [JsonProperty("sender")]
        public long SenderQQ { get; set; }

        /// <summary>
        /// 文件信息
        /// </summary>
        [JsonProperty("private_file")]
        public PrivateFileUpload File { get; set; } = new();

        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonIgnore]
        public override PostEventType EventType { get; set; } = PostEventType.PrivateUpload;
    }

    /// <summary>
    /// 私聊文件上传事件用
    /// </summary>
    public record PrivateFileUpload : FileUpload
    {
        /// <summary>
        /// 子文件ID
        /// </summary>
        [JsonProperty("sub_id")] public string SubId { get; set; } = "";

        /// <summary>
        /// 文件过期时间
        /// </summary>
        [JsonProperty("exppire")] public long Exppire { get; set; }
    }
}
