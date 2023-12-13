﻿using Newtonsoft.Json;

namespace ShamrockCore.Reciver
{
    public class MessageReceiverBase
    {
        /// <summary>
        /// 发送时间
        /// </summary>
        [JsonProperty("time")]
        public long Time { get; set; }

        /// <summary>
        /// 机器人qq
        /// </summary>
        [JsonProperty("self_id")]
        public long SelfId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("post_type")]
        public string PostType { get; set; } = "";

        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        /// <summary>
        /// 消息制造者/事件被动者
        /// </summary>
        [JsonProperty("user_id")]
        public long UserId { get; set; }
    }
}