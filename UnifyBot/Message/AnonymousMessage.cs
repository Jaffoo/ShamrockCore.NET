using Newtonsoft.Json;
using UnifyBot.Utils;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 匿名消息
    /// </summary>
    public class AnonymousMessage : MessageBase
    {
        public override Messages Type => Messages.Anonymous;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
        }
    }
}
