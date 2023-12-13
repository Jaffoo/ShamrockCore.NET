using Newtonsoft.Json;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Reciver.MsgChain
{
    public record Message
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

    public record MsgBody
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; } = "";

        /// <summary>
        /// Type为json
        /// </summary>
        public JsonData? Data { get; set; } = null;

        /// <summary>
        /// 文件名
        /// </summary>
        public string File { get; set; } = "";

        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; } = "";
    }

    public record JsonData
    {
        public string App { get; set; } = "";
        public Config? Config { get; set; } = null;
        public string Desc { get; set; } = "";
        public Extra? Extra { get; set; } = null;
        public Meta? Meta { get; set; } = null;
        public string Prompt { get; set; } = "";
        public string Ver { get; set; } = "";
        public string View { get; set; } = "";
    }
    public class Config
    {
        public long Ctime { get; set; }
        public int Forward { get; set; }
        public string Token { get; set; } = "";
    }
    public class Extra
    {
        [JsonProperty("app_type")]
        public int AppType { get; set; }
        public long Appid { get; set; }
        public long Uin { get; set; }
    }
    public class Meta
    {
        public Mannounce? Mannounce { get; set; } = null;
    }
    public class Mannounce
    {
        public int Cr { get; set; }
        public int Encode { get; set; }
        public int Tw { get; set; }
        public string Fid { get; set; } = "";
        public string Gc { get; set; } = "";
        public string Sign { get; set; } = "";
        public string Text { get; set; } = "";
        public string Title { get; set; } = "";
        public string Uin { get; set; } = "";

    }
}
