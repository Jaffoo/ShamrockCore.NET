using Newtonsoft.Json;
using UnifyBot.Utils;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// Xml
    /// </summary>
    public class XmlMessage : MessageBase
    {
        public override Messages Type => Messages.Xml;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        public XmlMessage() { }
        public XmlMessage(string xml)
        {
            base.Data = new Body()
            {
                Data = xml
            };
        }

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
            /// <summary>
            /// XML 内容
            /// </summary>
            public string Data { get; set; } = "";
        }
    }
}
