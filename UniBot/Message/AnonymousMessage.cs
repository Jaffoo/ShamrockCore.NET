using UniBot.Model;

namespace UniBot.Message
{
    /// <summary>
    /// 掷骰子魔法表情
    /// </summary>
    public class AnonymousMessage : MessageBase
    {
        public override Messages Type => Messages.Anonymous;

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
        }
    }
}
