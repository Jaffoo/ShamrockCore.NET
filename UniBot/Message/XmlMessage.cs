using UniBot.Message;
using UniBot.Model;

namespace UniBot.Xml
{
    /// <summary>
    /// Xml
    /// </summary>
    public class XmlMessage : MessageBase
    {
        public override Messages Type => Messages.Xml;
        public XmlMessage(string xml)
        {
            Data = new Body()
            {
                Data = xml
            };
        }
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
