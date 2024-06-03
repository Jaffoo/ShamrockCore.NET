using Newtonsoft.Json;
using TBC.CommonLib;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 音乐分享
    /// </summary>
    public class MusicMessage : MessageBase
    {
        public override Messages Type => Messages.Music;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        public MusicMessage() { }
        /// <summary>
        /// 音乐分享
        /// </summary>
        public MusicMessage(string musicId, string type = "qq")
        {
            base.Data = new Body()
            {
                Id = musicId,
                Type = type
            };
        }

        /// <summary>
        /// 自定义音乐分享
        /// </summary>
        public MusicMessage(string url, string audio, string title, string content = "", string image = "")
        {
            base.Data = new Body()
            {
                Type = "custom",
                Url = url,
                Audio = audio,
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
            /// 分别表示使用QQ音乐(qq)、网易云音乐(163)、虾米音乐(xm)，自定义(custom)
            /// </summary>
            public string Type { get; set; } = "qq";

            /// <summary>
            /// 歌曲 ID
            /// </summary>
            public string Id { get; set; } = "";

            /// <summary>
            /// 点击后跳转目标 URL
            /// </summary>
            public string Url { get; set; } = "";

            /// <summary>
            /// 音乐 URL
            /// </summary>
            public string Audio { get; set; } = "";

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
