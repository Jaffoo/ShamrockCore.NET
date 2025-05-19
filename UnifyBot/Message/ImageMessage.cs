using Newtonsoft.Json;
using UnifyBot.Utils;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 图片消息
    /// </summary>
    public class ImageMessage : MessageBase
    {
        public override Messages Type => Messages.Image;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        public ImageMessage() { }
        /// <summary>
        /// 图片消息
        /// 发送方式三选一
        /// 都传入优先级 file>base64>url
        /// </summary>
        public ImageMessage(string file = "", string base64 = "", string url = "", ImageType type = 0, bool cache = true, bool proxy = true)
        {
            base.Data = new Body()
            {
                Proxy = proxy,
                Cache = cache,
                Type = type.GetDescription(),
            };
            if (!string.IsNullOrWhiteSpace(file))
                base.Data.File = file;
            else if (!string.IsNullOrWhiteSpace(base64))
            {
                if (!base64.Contains("base64://")) base64 = "base64://" + base64;
                base.Data.File = base64;
            }
            else if (!string.IsNullOrWhiteSpace(url))
                base.Data.File = url;
        }

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
            /// <summary>
            /// 图片路径
            /// 绝对路径，/home/1.png,C:\\1.png
            /// 网络 URL，例如 https://www.baidu.com/img/flexible/logo/pc/result.png
            /// Base64 编码，例如 base64://xxxxxx=
            /// </summary>
            public string File { get; set; } = "";

            /// <summary>
            /// 图片类型，flash 表示闪照，无此参数表示普通图片
            /// </summary>
            public string Type { get; set; } = "";

            /// <summary>
            /// 图片 URL
            /// </summary>
            public string? Url { get; set; } 

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

    /// <summary>
    /// 通过url发送图片
    /// </summary>
    public class ImageByUrl : MessageBase
    {
        public override Messages Type => Messages.Image;
        public new ImageMessage.Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<ImageMessage.Body>();

        public ImageByUrl() { }
        public ImageByUrl(string url, ImageType type = 0, bool cache = true, bool proxy = true)
        {
            base.Data = new ImageMessage.Body()
            {
                File = url,
                Cache = cache,
                Proxy = proxy,
                Type = type.GetDescription()
            };
        }
    }
    /// <summary>
    /// 通过文件路径发送图片
    /// </summary>
    public class ImageByPath : MessageBase
    {
        public override Messages Type => Messages.Image;
        public new ImageMessage.Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<ImageMessage.Body>();

        public ImageByPath() { }
        public ImageByPath(string path, ImageType type = 0)
        {
            base.Data = new ImageMessage.Body()
            {
                File = path,
                Type = type.GetDescription()
            };
        }
    }
    /// <summary>
    /// 通过Base64发送图片
    /// </summary>
    public class ImageByBase64 : MessageBase
    {
        public override Messages Type => Messages.Image;
        public new ImageMessage.Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<ImageMessage.Body>();

        public ImageByBase64() { }
        public ImageByBase64(string base64, ImageType type = 0)
        {
            if (!base64.Contains("base64://")) base64 = "base64://" + base64;
            base.Data = new ImageMessage.Body()
            {
                File = base64,
                Type = type.GetDescription()
            };
        }
    }
}
