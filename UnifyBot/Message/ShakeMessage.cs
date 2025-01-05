using Newtonsoft.Json;
using UnifyBot.Utils;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 窗口抖动（戳一戳）
    /// </summary>
    public class ShakeMessage : MessageBase
    {
        public override Messages Type => Messages.Shake;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
        }
    }
}
