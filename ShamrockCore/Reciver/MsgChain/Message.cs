using ShamrockCore.Data.Model;

namespace ShamrockCore.Reciver.MsgChain
{
    public class Message
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageType Type { get; set; }

        /// <summary>
        /// 消息体
        /// </summary>
        public MsgBody Data { get; set; } = new();
    }

    public class MsgBody
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// 文件名
        /// </summary>
        public string File { get; set; } = "";

        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; } = "";
    }
}
