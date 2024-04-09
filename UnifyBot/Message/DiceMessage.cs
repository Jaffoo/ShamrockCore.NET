using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 掷骰子魔法表情
    /// </summary>
    public class DiceMessage : MessageBase
    {
        public override Messages Type => Messages.Dice;

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
        }
    }
}
