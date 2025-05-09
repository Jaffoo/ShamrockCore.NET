﻿using Newtonsoft.Json;
using UnifyBot.Model;
using static UnifyBot.Utils.JsonConvertTool;

namespace UnifyBot.Message
{
    public class MessageBase
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public virtual Messages Type { get; set; }

        /// <summary>
        /// 消息体
        /// </summary>
        [JsonProperty("data")]
        public virtual dynamic? Data { get; set; }

        /// <summary>
        /// 配置信息
        /// </summary>
        [JsonIgnore]
        internal Connect Connect { get; set; } = new Connect("", 0, 0);
    }
}
