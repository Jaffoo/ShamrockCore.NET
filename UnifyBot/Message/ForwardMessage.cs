﻿using Newtonsoft.Json;
using UnifyBot.Utils;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 合并转发
    /// </summary>
    public class ForwardMessage : MessageBase
    {
        public override Messages Type => Messages.Forward;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        public ForwardMessage() { }
        public ForwardMessage(long forwardMsgId)
        {
            base.Data = new Body() { Id = forwardMsgId };
        }

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
            /// <summary>
            /// 合并转发 ID，需通过 get_forward_msg API 获取具体内容
            /// </summary>
            public long Id { get; set; }
        }
    }
}
