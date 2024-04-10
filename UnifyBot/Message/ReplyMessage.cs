using Newtonsoft.Json;
using TBC.CommonLib;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 回复消息
    /// </summary>
    public class ReplyMessage : MessageBase
    {
        public override Messages Type => Messages.Reply;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        public ReplyMessage() { }
        public ReplyMessage(long msgId)
        {
            base.Data = new Body() { Id = msgId };
        }

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
            /// <summary>
            /// 消息id
            /// </summary>
            public long Id { get; set; }
        }
    }
}
