using Newtonsoft.Json;
using UnifyBot.Utils;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 连接分享
    /// </summary>
    public class ShareMessage : MessageBase
    {
        public override Messages Type => Messages.Share;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        public ShareMessage() { }
        public ShareMessage(string url, string title, string content = "", string image="")
        {
            base.Data = new Body()
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
