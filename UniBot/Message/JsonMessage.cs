using UniBot.Model;

namespace UniBot.Message
{
    /// <summary>
    /// Xml
    /// </summary>
    public class JsonMessage : MessageBase
    {
        public override Messages Type => Messages.Json;
        public JsonMessage(string json)
        {
            Data = new Body()
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
