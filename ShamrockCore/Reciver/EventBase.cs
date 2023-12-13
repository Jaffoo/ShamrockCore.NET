using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShamrockCore.Reciver
{
    /// <summary>
    /// 事件基类
    /// </summary>
    public class EventBase : MessageReceiverBase
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonProperty("notice_type")]
        public string NoticeType { get; set; } = "";
    }
}
