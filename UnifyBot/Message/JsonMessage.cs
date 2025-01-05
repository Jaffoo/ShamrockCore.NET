using Newtonsoft.Json;
using UnifyBot.Utils;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// Xml
    /// </summary>
    public class JsonMessage : MessageBase
    {
        public override Messages Type => Messages.Json;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        public JsonMessage() { }
        public JsonMessage(string json)
        {
            base.Data = new Body()
            {
                Data = json
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
