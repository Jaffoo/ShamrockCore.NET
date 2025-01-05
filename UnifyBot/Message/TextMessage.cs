using UnifyBot.Model;
using UnifyBot.Utils;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace UnifyBot.Message
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class TextMessage : MessageBase
    {
        public override Messages Type => Messages.Text;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        public TextMessage() { }
        public TextMessage(string content)
        {
            base.Data = new Body()
            {
                Text = content
            };
        }

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
            /// <summary>
            /// 消息文本内容
            /// </summary>
            public string Text { get; set; } = "";
        }
    }
}
