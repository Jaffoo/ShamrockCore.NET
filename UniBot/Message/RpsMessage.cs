using UniBot.Model;

namespace UniBot.Message
{
    /// <summary>
    /// 猜拳魔法表情
    /// </summary>
    public class RpsMessage : MessageBase
    {
        public override Messages Type => Messages.Rps;

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
        }
    }
}
