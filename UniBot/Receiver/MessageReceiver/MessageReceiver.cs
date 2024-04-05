using UniBot.Message.Chain;

namespace UniBot.Receiver.MessageReceiver
{
    public class MessageReceiver : MessageReceiverBase
    {
        /// <summary>
        /// 消息
        /// </summary>
        public virtual MessageChain? Message { get; set; }
    }
}
