﻿using Newtonsoft.Json;
using UniBot.Message;
using UniBot.Model;
using static UniBot.Tools.JsonConvert;

namespace UniBot.Receiver
{
    public class PrivateReceiver : MsgReceiverBase
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("message_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public MessageType MessageType { get; set; }

        /// <summary>
        /// 消息子类型
        /// </summary>
        [JsonProperty("sub_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public MessageSubType MessageSubType { get; set; }

        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("message_id")]
        public long MessageId { get; set; }

        /// <summary>
        /// 发送人qq
        /// </summary>
        [JsonProperty("user_id")]
        public long SenderQQ { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public MessageChain Message { get; set; } = new();

        /// <summary>
        /// 原始CQ消息码
        /// </summary>
        [JsonProperty("raw_message")]
        public string RawMessage { get; set; } = "";

        /// <summary>
        /// 字体
        /// </summary>
        public int Font {  get; set; }

        /// <summary>
        /// 发送人
        /// </summary>
        public Sender Sender { get; set; } = new();
    }
}
