using Newtonsoft.Json;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Reciver.MsgChain
{
    public record Message
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public MessageType Type { get; set; }

        /// <summary>
        /// 消息体
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; } = new();

    }

    /// <summary>
    /// 文本
    /// </summary>
    public record TextMessage
    {
        /// <summary>
        /// 文本
        /// </summary>
        [JsonProperty("text")] public string Text { get; set; } = "";
    }

    /// <summary>
    /// at
    /// </summary>
    public record AtMessage
    {
        /// <summary>
        /// atQQ号，"0"或"all"时,表示 AT 全体成员
        /// </summary>
        [JsonProperty("qq")] public long QQ { get; set; }
    }

    /// <summary>
    /// 表情
    /// </summary>
    public record FaceMessage
    {
        /// <summary>
        /// 表情id
        /// </summary>
        [JsonProperty("id")] public int Id { get; set; }
    }

    /// <summary>
    /// 回复
    /// </summary>
    public record ReplyMessage
    {
        /// <summary>
        /// 回复消息id
        /// </summary>
        [JsonProperty("id")] public int Id { get; set; }
    }

    /// <summary>
    /// 图片
    /// </summary>
    public record ImageMessage
    {
        /// <summary>
        /// 文件名
        /// </summary>
        [JsonProperty("file")] public string File { get; set; } = "";
    }

    /// <summary>
    /// 语音
    /// </summary>
    public record RecordMessage
    {
        /// <summary>
        /// 文件名
        /// </summary>
        [JsonProperty("file")] public string File { get; set; } = "";
    }

    /// <summary>
    /// 视频
    /// </summary>
    public record VideoMessage
    {
        /// <summary>
        /// 文件名
        /// </summary>
        [JsonProperty("file")] public string File { get; set; } = "";
    }

    /// <summary>
    /// 篮球表情
    /// </summary>
    public record BallMessage
    {
        /// <summary>
        /// 5 没中, 4 擦边没中, 3 卡框, 2 擦边中, 1 正中
        /// </summary>
        [JsonProperty("id")] public int Id { get; set; }
    }

    /// <summary>
    /// 猜拳表情
    /// </summary>
    public record RpsMessage
    {
        /// <summary>
        /// 5 没中, 4 擦边没中, 3 卡框, 2 擦边中, 1 正中
        /// </summary>
        [JsonProperty("id")] public int Id { get; set; }
    }

    /// <summary>
    /// 骰子表情
    /// </summary>
    public record DiceMessage
    {
        /// <summary>
        /// 点数 ID
        /// </summary>
        [JsonProperty("id")] public int Id { get; set; }
    }

    /// <summary>
    /// 戳一戳表情
    /// </summary>
    public record PokeMessage
    {
        /// <summary>
        /// 戳一戳 ID
        /// </summary>
        [JsonProperty("id")] public int Id { get; set; }

        /// <summary>
        /// 戳一戳类型
        /// </summary>
        [JsonProperty("type")] public int Type { get; set; }

        /// <summary>
        /// 戳一戳强度(1-5 默认1)
        /// </summary>
        [JsonProperty("strength")] public int Strength { get; set; }
    }

    /// <summary>
    /// 戳一戳(双击头像)
    /// </summary>
    public record TouchMessage
    {
        /// <summary>
        /// QQ号
        /// </summary>
        [JsonProperty("id")] public int Id { get; set; }
    }

    /// <summary>
    /// 音乐
    /// </summary>
    public record MusicMessage
    {
        /// <summary>
        /// 音乐 ID
        /// </summary>
        [JsonProperty("id")] public int Id { get; set; }

        /// <summary>
        /// 音乐类型(qq/163)
        /// </summary>
        [JsonProperty("type")] public string Type { get; set; } = "qq";
    }

    /// <summary>
    /// 音乐
    /// </summary>
    public record MusicCustomMessage
    {
        /// <summary>
        /// 音乐类型
        /// </summary>
        [JsonProperty("type")] public string Type { get; set; } = "qq";

        /// <summary>
        /// 跳转链接
        /// </summary>
        [JsonProperty("url")] public string Url { get; set; } = "";

        /// <summary>
        /// 音乐音频链接
        /// </summary>
        [JsonProperty("audio")] public string Audio { get; set; } = "";

        /// <summary>
        /// 标题
        /// </summary>
        [JsonProperty("title")] public string Title { get; set; } = "";

        /// <summary>
        /// 歌手
        /// </summary>
        [JsonProperty("singer")] public string Singer { get; set; } = "";

        /// <summary>
        /// 封面图片链接
        /// </summary>
        [JsonProperty("image")] public string Image { get; set; } = "";
    }

    /// <summary>
    /// 天气
    /// </summary>
    public record WeatherMessage
    {
        /// <summary>
        /// 城市名称
        /// </summary>
        [JsonProperty("city")] public string City { get; set; } = "";

        /// <summary>
        /// 城市代码
        /// </summary>
        [JsonProperty("code")] public string Code { get; set; } = "";
    }

    /// <summary>
    /// 位置
    /// </summary>
    public record LocationMessage
    {
        /// <summary>
        /// 纬度
        /// </summary>
        [JsonProperty("lat")] public string Lat { get; set; } = "";

        /// <summary>
        /// 经度
        /// </summary>
        [JsonProperty("lon")] public string Lon { get; set; } = "";

        /// <summary>
        /// 标题
        /// </summary>
        [JsonProperty("title")] public string Title { get; set; } = "";

        /// <summary>
        /// 内容
        /// </summary>
        [JsonProperty("content")] public string Content { get; set; } = "";
    }

    /// <summary>
    /// 链接分享
    /// </summary>
    public record ShareMessage
    {
        /// <summary>
        /// 链接地址
        /// </summary>
        [JsonProperty("url")] public string Url { get; set; } = "";

        /// <summary>
        /// 图片链接
        /// </summary>
        [JsonProperty("image")] public string Image { get; set; } = "";

        /// <summary>
        /// 文件链接
        /// </summary>
        [JsonProperty("file")] public string File { get; set; } = "";

        /// <summary>
        /// 标题
        /// </summary>
        [JsonProperty("title")] public string Title { get; set; } = "";

        /// <summary>
        /// 内容
        /// </summary>
        [JsonProperty("content")] public string Content { get; set; } = "";
    }

    /// <summary>
    /// 礼物消息
    /// </summary>
    public record GiftMessage
    {
        /// <summary>
        /// qq
        /// </summary>
        [JsonProperty("qq")] public long QQ { get; set; }

        /// <summary>
        /// 礼物id
        /// </summary>
        [JsonProperty("id")] public int Id { get; set; }
    }

    /// <summary>
    /// JSON 消息
    /// </summary>
    public record JsonMessage
    {
        /// <summary>
        /// json数据
        /// </summary>
        [JsonProperty("data")] public JsonData Data { get; set; } = new();
    }

    public record JsonData
    {
        [JsonProperty("app")] public string App { get; set; } = "";
        [JsonProperty("config")] public Config? Config { get; set; } = null;
        [JsonProperty("desc")] public string Desc { get; set; } = "";
        [JsonProperty("extra")] public Extra? Extra { get; set; } = null;
        [JsonProperty("meta")] public Meta? Meta { get; set; } = null;
        [JsonProperty("prompt")] public string Prompt { get; set; } = "";
        [JsonProperty("ver")] public string Ver { get; set; } = "";
        [JsonProperty("view")] public string View { get; set; } = "";
    }
    public class Config
    {
        [JsonProperty("ctime")] public long Ctime { get; set; }
        [JsonProperty("forward")] public int Forward { get; set; }
        [JsonProperty("token")] public string Token { get; set; } = "";
    }
    public class Extra
    {
        [JsonProperty("app_type")] public int AppType { get; set; }
        [JsonProperty("appid")] public long Appid { get; set; }
        [JsonProperty("uin")] public long Uin { get; set; }
    }
    public class Meta
    {
        [JsonProperty("mannounce")] public Mannounce? Mannounce { get; set; } = null;
    }
    public class Mannounce
    {
        [JsonProperty("cr")] public int Cr { get; set; }
        [JsonProperty("enocde")] public int Encode { get; set; }
        [JsonProperty("tw")] public int Tw { get; set; }
        [JsonProperty("fid")] public string Fid { get; set; } = "";
        [JsonProperty("gc")] public string Gc { get; set; } = "";
        [JsonProperty("sign")] public string Sign { get; set; } = "";
        [JsonProperty("text")] public string Text { get; set; } = "";
        [JsonProperty("title")] public string Title { get; set; } = "";
        [JsonProperty("uin")] public string Uin { get; set; } = "";
    }
}
