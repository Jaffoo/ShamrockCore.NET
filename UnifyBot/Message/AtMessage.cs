﻿using Newtonsoft.Json;
using UnifyBot.Model;
using UnifyBot.Utils;

namespace UnifyBot.Message
{
    /// <summary>
    /// @消息
    /// </summary>
    public class AtMessage : MessageBase
    {
        public override Messages Type => Messages.At;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        public AtMessage() { }

        /// <summary>
        /// @某个人，all则是@全体成员
        /// </summary>
        /// <param name="qq"></param>
        public AtMessage(long qq)
        {
            base.Data = new Body()
            {
                QQ = qq.ToString()
            };
        }

        /// <summary>
        /// @某个人，all则是@全体成员
        /// </summary>
        /// <param name="qq"></param>
        public AtMessage(string qq)
        {
            base.Data = new Body()
            {
                QQ = qq
            };
        }

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
            /// <summary>
            /// qq
            /// </summary>
            public string QQ { get; set; } = "";
        }
    }
}
