using UniBot.Model;

namespace UniBot.Message
{
    /// <summary>
    /// 回复消息
    /// </summary>
    public class ReplyMessage : MessageBase
    {
        public override Messages Type => Messages.Reply;
        public ReplyMessage(long msgId)
        {
            Data = new Body() { Id = msgId };
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
