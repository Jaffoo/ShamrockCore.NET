using UniBot.Model;

namespace UniBot.Message
{
    /// <summary>
    /// 窗口抖动（戳一戳）
    /// </summary>
    public class ShakeMessage : MessageBase
    {
        public override Messages Type => Messages.Shake;

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
        }
    }
}
