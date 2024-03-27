using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Receiver.MsgChain
{
    public record Message
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public virtual MessageType Type { get; set; }

        /// <summary>
        /// 消息体
        /// </summary>
        [JsonProperty("data")]
        public virtual MsgBody Data { get; set; } = new();
    }

    public record MsgBody()
    {
        [JsonProperty("text")] public string Text { get; set; } = "";
        [JsonProperty("qq")] public long QQ { get; set; }
        [JsonProperty("id")] public long Id { get; set; }
        [JsonProperty("file")] public string File { get; set; } = "";
        [JsonProperty("magic")] public bool Magic { get; set; }
        [JsonProperty("type")] public string Type { get; set; } = "";
        [JsonProperty("strength")] public int Strength { get; set; }
        [JsonProperty("url")] public string Url { get; set; } = "";
        [JsonProperty("audio")] public string Audio { get; set; } = "";
        [JsonProperty("title")] public string Title { get; set; } = "";
        [JsonProperty("singer")] public string Singer { get; set; } = "";
        [JsonProperty("image")] public string Image { get; set; } = "";
        [JsonProperty("city")] public string City { get; set; } = "";
        [JsonProperty("code")] public string Code { get; set; } = "";
        [JsonProperty("lat")] public float Lat { get; set; }
        [JsonProperty("lon")] public float Lon { get; set; }
        [JsonProperty("content")] public string Content { get; set; } = "";
        [JsonProperty("data")] public JsonData Data { get; set; } = new();
    }

    /// <summary>
    /// 文本
    /// </summary>
    public record TextMessage : Message
    {
        public TextMessage() { }

        /// <summary>
        /// 文本
        /// </summary>
        /// <param name="text">消息</param>
        public TextMessage(string text) => Data.Text = text;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Text;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 消息
            /// </summary>
            [JsonProperty("text")] public string Text { get; set; } = "";
        }
    }

    /// <summary>
    /// at
    /// </summary>
    public record AtMessage : Message
    {
        /// <summary>
        /// at
        /// </summary>
        /// <param name="qq">qq号</param>
        public AtMessage(long qq = 0) => Data.QQ = qq;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.At;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// atQQ号，"0"或"all"时,表示 AT 全体成员
            /// </summary>
            [JsonProperty("qq")] public long QQ { get; set; }
        }
    }

    /// <summary>
    /// 表情
    /// </summary>
    public record FaceMessage : Message
    {
        public FaceMessage() { }

        /// <summary>
        /// 表情
        /// </summary>
        /// <param name="id">表情id</param>
        public FaceMessage(int id) => Data.Id = id;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Face;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 表情id
            /// </summary>
            [JsonProperty("id")] public long Id { get; set; }
        }
    }

    /// <summary>
    /// 回复
    /// </summary>
    public record ReplyMessage : Message
    {
        public ReplyMessage() { }

        /// <summary>
        /// 回复
        /// </summary>
        /// <param name="msgId">消息id</param>
        public ReplyMessage(long msgId) => Data.Id = msgId;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Reply;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 回复消息id
            /// </summary>
            [JsonProperty("id")] public long Id { get; set; }

            /// <summary>
            /// 被回复的消息
            /// </summary>
            [JsonIgnore] public MessageChain? Message => Api.GetMsg(Id).Result?.Message;
        }
    }

    /// <summary>
    /// 图片
    /// </summary>
    public record ImageMessage : Message
    {
        public ImageMessage() { }

        /// <summary>
        /// 图片(参数三选一，优先本地文件)
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <param name="url">文件链接</param>
        /// <param name="base64">文件base64</param>
        /// <param name="imgType">消息类型</param>
        /// <param name="imgSubType">消息子类型</param>
        public ImageMessage(string file = "", string url = "", string base64 = "", ImgType? imgType = null, ImgSubType? imgSubType = null)
        {
            if (!string.IsNullOrWhiteSpace(file))
            {
                if (!file.Contains("file://")) file = "file://" + file;
                Data.File = file;
            }
            else if (!string.IsNullOrWhiteSpace(url))
                Data.File = url;
            else if (!string.IsNullOrWhiteSpace(base64))
            {
                string pattern = @"data:[a-zA-Z0-9]+/[a-zA-Z0-9]+;base64,";
                string result = Regex.Replace(base64, pattern, "");
                if (!result.Contains("base64://")) result = "base64://" + result;
                Data.File = result;
            }
            if (imgType != null) Data.Type = imgType.Value;
            if (imgSubType != null) Data.SubType = imgSubType.Value;
        }
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Image;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 文件名
            /// </summary>
            [JsonProperty("file")] public string File { get; set; } = "";

            /// <summary>
            /// 链接
            /// </summary>
            [JsonProperty("url")] public string Url { get; set; } = "";

            /// <summary>
            /// 图片类型
            /// </summary>
            [JsonProperty("type")]
            [JsonConverter(typeof(LowercaseStringEnumConverter))]
            public ImgType Type { get; set; }

            /// <summary>
            /// 图片子类型
            /// </summary>
            [JsonProperty("subType")] public ImgSubType SubType { get; set; }
        }
    }

    /// <summary>
    /// 语音
    /// </summary>
    public record RecordMessage : Message
    {
        public RecordMessage() { }

        /// <summary>
        /// 语音(file和url二选一，file优先)
        /// </summary>
        /// <param name="file">文件路径</param>
        /// <param name="url">文件链接</param>
        /// <param name="magic">是否为魔法语音</param>
        public RecordMessage(string file = "", string url = "", bool magic = false)
        {
            if (string.IsNullOrWhiteSpace(file))
            {
                if (!file.Contains("file://")) file = "file://" + file;
                Data.File = file;
            }
            else if (!string.IsNullOrWhiteSpace(url))
                Data.File = url;
            Data.Magic = magic;
        }
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Record;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 文件地址
            /// </summary>
            [JsonProperty("file")] public string File { get; set; } = "";

            /// <summary>
            /// 文件链接
            /// </summary>
            [JsonProperty("url")] public string Url { get; set; } = "";

            /// <summary>
            /// 是否为魔法语音
            /// </summary>
            [JsonProperty("magic")] public bool Magic { get; set; }
        }
    }

    /// <summary>
    /// 视频
    /// </summary>
    public record VideoMessage : Message
    {
        public VideoMessage() { }

        /// <summary>
        /// 视频
        /// </summary>
        /// <param name="file">文件路径</param>
        public VideoMessage(string file = "", string url = "")
        {
            if (!string.IsNullOrWhiteSpace(file))
            {
                if (!file.Contains("file://")) file = "file://" + file;
                Data.File = file;
            }
            else if (!string.IsNullOrWhiteSpace(url))
            {
                var filePath = Api.DownloadFile(url).Result?.File;
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    if (!filePath.Contains("file://")) filePath = "file://" + filePath;
                    Data.File = filePath;
                }
            }
        }
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Video;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 文件名
            /// </summary>
            [JsonProperty("file")] public string File { get; set; } = "";
        }
    }

    /// <summary>
    /// 篮球表情
    /// </summary>
    public record BallMessage : Message
    {
        public BallMessage() { }

        /// <summary>
        /// 5 没中, 4 擦边没中, 3 卡框, 2 擦边中, 1 正中
        /// </summary>
        /// <param name="id"></param>
        public BallMessage(Ball id) => Data.Id = id;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Basketball;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 5 没中, 4 擦边没中, 3 卡框, 2 擦边中, 1 正中
            /// </summary>
            [JsonProperty("id")] public Ball Id { get; set; }
        }
    }

    /// <summary>
    /// 猜拳表情
    /// </summary>
    public record RpsMessage : Message
    {
        public RpsMessage() { }

        /// <summary>
        /// 猜拳表情
        /// </summary>
        /// <param name="id">锤 3 剪 2 布 1</param>
        public RpsMessage(Rps id) => Data.Id = id;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.New_rps;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 锤 3 剪 2 布 1
            /// </summary>
            [JsonProperty("id")] public Rps Id { get; set; }
        }
    }

    /// <summary>
    /// 骰子表情
    /// </summary>
    public record DiceMessage : Message
    {
        public DiceMessage() { }

        /// <summary>
        /// 骰子表情
        /// </summary>
        /// <param name="id">点数(1-6)</param>
        public DiceMessage(int id) => Data.Id = id;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.New_dice;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 点数(1-6)
            /// </summary>
            [JsonProperty("id")] public long Id { get; set; }
        }
    }

    /// <summary>
    /// 戳一戳表情
    /// </summary>
    public record PokeMessage : Message
    {
        public PokeMessage() { }
        public PokeMessage(Body data) => Data = data;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Poke;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 戳一戳ID
            /// </summary>
            [JsonProperty("id")] public long Id { get; set; } = 10000;

            /// <summary>
            /// 戳一戳类型
            /// </summary>
            [JsonProperty("type")] public int Type { get; set; } = 1;

            /// <summary>
            /// 戳一戳强度(1-5 默认1)
            /// </summary>
            [JsonProperty("strength")] public int Strength { get; set; } = 1;
        }
    }

    /// <summary>
    /// 戳一戳(双击头像)
    /// </summary>
    public record TouchMessage : Message
    {
        public TouchMessage() { }

        /// <summary>
        /// 戳一戳(双击头像)
        /// </summary>
        /// <param name="id">QQ号</param>
        public TouchMessage(long id) => Data.Id = id;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Touch;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// QQ号
            /// </summary>
            [JsonProperty("id")] public long Id { get; set; }
        }
    }

    /// <summary>
    /// 音乐
    /// </summary>
    public record MusicMessage : Message
    {
        public MusicMessage() { }

        /// <summary>
        /// 音乐
        /// </summary>
        /// <param name="id">音乐id</param>
        /// <param name="type">音乐类型(qq/163)</param>
        public MusicMessage(long id, string type = "qq")
        {
            Data.Id = id;
            Data.Type = type;
        }
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Music;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 音乐 ID
            /// </summary>
            [JsonProperty("id")] public long Id { get; set; }

            /// <summary>
            /// 音乐类型(qq/163)
            /// </summary>
            [JsonProperty("type")] public string Type { get; set; } = "qq";
        }
    }

    /// <summary>
    /// 音乐
    /// </summary>
    public record MusicCustomMessage : Message
    {
        public MusicCustomMessage() { }
        public MusicCustomMessage(Body data) => Data = data;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Music;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
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
    }

    /// <summary>
    /// 天气
    /// </summary>
    public record WeatherMessage : Message
    {
        public WeatherMessage() { }
        public WeatherMessage(Body data) => Data = data;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Weather;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
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
    }

    /// <summary>
    /// 位置
    /// </summary>
    public record LocationMessage : Message
    {
        public LocationMessage() { }
        public LocationMessage(Body data) => Data = data;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Location;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 纬度
            /// </summary>
            [JsonProperty("lat")] public float Lat { get; set; }

            /// <summary>
            /// 经度
            /// </summary>
            [JsonProperty("lon")] public float Lon { get; set; }

            /// <summary>
            /// 标题
            /// </summary>
            [JsonProperty("title")] public string Title { get; set; } = "";

            /// <summary>
            /// 内容
            /// </summary>
            [JsonProperty("content")] public string Content { get; set; } = "";
        }
    }

    /// <summary>
    /// 链接分享
    /// </summary>
    public record ShareMessage : Message
    {
        public ShareMessage() { }
        public ShareMessage(Body data) => Data = data;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Share;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
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
    }

    /// <summary>
    /// 礼物消息
    /// </summary>
    public record GiftMessage : Message
    {
        public GiftMessage() { }

        /// <summary>
        /// 礼物消息
        /// </summary>
        /// <param name="qq">qq</param>
        /// <param name="giftId">礼物id</param>
        public GiftMessage(long qq, int giftId) { Data.QQ = qq; Data.Id = giftId; }
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Gift;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// qq
            /// </summary>
            [JsonProperty("qq")] public long QQ { get; set; }

            /// <summary>
            /// 礼物id
            /// </summary>
            [JsonProperty("id")] public long Id { get; set; }
        }
    }

    /// <summary>
    /// 合并转发
    /// </summary>
    public record MergeMessage : Message
    {
        public MergeMessage() { }

        public MergeMessage(long id) => Data.Id = id;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 合并转发resid
            /// </summary>
            [JsonProperty("id")] public long Id { get; set; }
        }
    }

    /// <summary>
    /// 合并转发节点
    /// </summary>
    public record MergeNodeMessage : Message
    {
        public MergeNodeMessage() { }

        public MergeNodeMessage(long id) => Data.Id = id;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 消息ID
            /// </summary>
            [JsonProperty("id")] public long Id { get; set; }
        }
    }

    /// <summary>
    /// JSON 消息
    /// </summary>
    public record JsonMessage : Message
    {
        public JsonMessage() { }
        public JsonMessage(Body data) => Data = data;
        [JsonProperty("type")]
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public new MessageType Type { get; set; } = MessageType.Json;
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// json数据
            /// </summary>
            [JsonProperty("data")] public JsonData Data { get; set; } = new();
        }
    }

    /// <summary>
    /// 弹射表情
    /// </summary>
    public record BubbleFaceMessage : Message
    {
        public BubbleFaceMessage() { }

        public BubbleFaceMessage(int id, int count)
        {
            Data.Id = id;
            Data.Count = count;
        }
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 表情ID
            /// </summary>
            [JsonProperty("id")] public int Id { get; set; }

            /// <summary>
            /// 数量
            /// </summary>
            [JsonProperty("id")] public int Count { get; set; }
        }
    }

    /// <summary>
    /// 频道事件
    /// 1:频道专属，勿用于qq发送消息
    /// 2:不知是否可用与频道发送消息
    /// 3:且字段过多，需要自行解析
    /// </summary>
    public record ButtonMessage : Message
    {
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 表情ID
            /// </summary>
            [JsonProperty("appid")] public long AppId { get; set; }

            /// <summary>
            /// 数量
            /// </summary>
            [JsonProperty("rows")] public List<object> Rows { get; set; } = new();
        }
    }

    /// <summary>
    /// 频道markdwon文本
    /// 1:频道专属，勿用于qq发送消息
    /// 2:不知是否可用与频道发送消息
    /// 3:且字段过多，需要自行解析
    /// </summary>
    public record MarkdownMessage : Message
    {
        [JsonProperty("data")] public new Body Data { get; set; } = new();
        public record Body
        {
            /// <summary>
            /// 数量
            /// </summary>
            [JsonProperty("content")] public string Content { get; set; } = "";
        }
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
        [JsonProperty("encode")] public int Encode { get; set; }
        [JsonProperty("tw")] public int Tw { get; set; }
        [JsonProperty("fid")] public string Fid { get; set; } = "";
        [JsonProperty("gc")] public string Gc { get; set; } = "";
        [JsonProperty("sign")] public string Sign { get; set; } = "";
        [JsonProperty("text")] public string Text { get; set; } = "";
        [JsonProperty("title")] public string Title { get; set; } = "";
        [JsonProperty("uin")] public string Uin { get; set; } = "";
    }
}
