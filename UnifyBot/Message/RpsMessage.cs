using Newtonsoft.Json;
using UnifyBot.Utils;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 猜拳魔法表情
    /// </summary>
    public class RpsMessage : MessageBase
    {
        public override Messages Type => Messages.Rps;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();
        
        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
        }
    }
}
