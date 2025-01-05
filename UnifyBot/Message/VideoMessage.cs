using Newtonsoft.Json;
using UnifyBot.Utils;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 语音消息
    /// </summary>
    public class VideoMessage : MessageBase
    {
        public override Messages Type => Messages.Video;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        public VideoMessage() { }
        /// <summary>
        /// 语音消息
        /// 发送方式三选一
        /// 都传入优先级 file>base64>url
        /// </summary>
        public VideoMessage(string file = "", string base64 = "", string url = "", bool cache = true, bool proxy = true)
        {
            base.Data = new Body()
            {
                Proxy = proxy,
                Cache = cache,
            };
            if (!string.IsNullOrWhiteSpace(file))
            {
                Data.File = file;
            }
            else if (!string.IsNullOrWhiteSpace(base64))
            {
                if (!file.Contains("base64://")) base64 = "base64://" + base64;
                Data.File = base64;
            }
            else if (!string.IsNullOrWhiteSpace(url))
                Data.File = url;
        }

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
            /// <summary>
            /// 图片路径
            /// 绝对路径，例如 /home/1.mp4,C:\\1.mp4
            /// 网络 URL，例如 http://xxx.xxx.com/1.mp4
            /// Base64 编码，例如 base64://xxxxxx=
            /// </summary>
            public string File { get; set; } = "";

            /// <summary>
            /// 图片 URL
            /// </summary>
            public string Url { get; set; } = "";

            /// <summary>
            /// 只在通过网络 URL 发送时有效，表示是否使用已缓存的文件，默认true
            /// </summary>
            public bool Cache { get; set; } = true;

            /// <summary>
            /// 只在通过网络 URL 发送时有效，表示是否通过代理下载文件（需通过环境变量或配置文件配置代理），默认 1
            /// </summary>
            public bool Proxy { get; set; } = true;

            /// <summary>
            /// 只在通过网络 URL 发送时有效，单位秒，表示下载网络文件的超时时间，默认不超时
            /// </summary>
            public int Timeout { get; set; }
        }
    }

    // <summary>
    /// 通过url发送图片
    /// </summary>
    public class VideoByUrl : MessageBase
    {
        public override Messages Type => Messages.Video;
        public new VideoMessage.Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<VideoMessage.Body>();
        public VideoByUrl() { }
        public VideoByUrl(string url, bool cache = true, bool proxy = true)
        {
            base.Data = new VideoMessage.Body()
            {
                File = url,
                Cache = cache,
                Proxy = proxy
            };
        }
    }
    /// <summary>
    /// 通过文件路径发送图片
    /// </summary>
    public class VideoByPath : MessageBase
    {
        public override Messages Type => Messages.Video;
        public new VideoMessage.Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<VideoMessage.Body>();
        public VideoByPath() { }
        public VideoByPath(string path)
        {
            base.Data = new VideoMessage.Body()
            {
                File = path
            };
        }
    }
    /// <summary>
    /// 通过Base64发送图片
    /// </summary>
    public class VideoByBase64 : MessageBase
    {
        public override Messages Type => Messages.Video;
        public new VideoMessage.Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<VideoMessage.Body>();
        public VideoByBase64() { }
        public VideoByBase64(string base64)
        {
            base.Data = new VideoMessage.Body()
            {
                File = base64
            };
        }
    }
}
