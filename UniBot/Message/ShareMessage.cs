using UniBot.Model;

namespace UniBot.Message
{
    /// <summary>
    /// 掷骰子魔法表情
    /// </summary>
    public class ShareMessage : MessageBase
    {
        public override Messages Type => Messages.Share;

        public ShareMessage() { }
        public ShareMessage(string url, string title, string content = "", string image="")
        {
            Data = new Body()
            {
                Url = url,
                Title = title,
                Content = content,
                Image = image
            };
        }

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
            /// <summary>
            /// URL
            /// </summary>
            public string Url { get; set; } = "";

            /// <summary>
            /// 标题
            /// </summary>
            public string Title { get; set; } = "";

            /// <summary>
            /// 发送时可选，内容描述
            /// </summary>
            public string Content { get; set; } = "";

            /// <summary>
            /// 发送时可选，图片 URL
            /// </summary>
            public string Image { get; set; } = "";
        }
    }
}
