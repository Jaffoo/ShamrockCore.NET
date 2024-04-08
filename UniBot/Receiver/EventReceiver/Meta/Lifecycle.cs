﻿using Newtonsoft.Json;
using UniBot.Model;
using static UniBot.Utils.JsonConvertTool;

namespace UniBot.Receiver.EventReceiver
{
    /// <summary>
    /// 生命周期
    /// </summary>
    public class Lifecycle : EventReceiver
    {
        /// <summary>
        /// 元事件类型
        /// </summary>
        [JsonProperty("meta_event_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public MetaType MetaType { get; set; }

        /// <summary>
        /// 元事件子类型
        /// </summary>
        [JsonProperty("sub_type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public MetaSubType MetaSubType { get; set; }
        public object? Status { get; set; }
    }
}