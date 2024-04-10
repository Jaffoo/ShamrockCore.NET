using Newtonsoft.Json;
using TBC.CommonLib;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 掷骰子魔法表情
    /// </summary>
    public class DiceMessage : MessageBase
    {
        public override Messages Type => Messages.Dice;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
        }
    }
}
