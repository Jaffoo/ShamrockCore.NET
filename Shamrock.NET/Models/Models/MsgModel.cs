using System.Text.Json.Serialization;

namespace Shamrock.NET
{
    public class MsgBase
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("data")]
        public Body? Data { get; set; }

        public class Body
        {
            /// <summary>
            /// 文本
            /// </summary>
            [JsonPropertyName("text")]
            public string? Text { get; set; }

            /// <summary>
            /// JSON数据
            /// </summary>
            [JsonPropertyName("data")]
            public string? Data { get; set; }

            /// <summary>
            /// 文件路径
            /// </summary>
            [JsonPropertyName("file")]
            public string? File { get; set; }

            /// <summary>
            /// 戳一戳类型
            /// </summary>
            [JsonPropertyName("type")]
            public object? Type { get; set; }

            /// <summary>
            /// QQ
            /// </summary>
            [JsonPropertyName("id")]
            public long Id { get; set; }

            /// <summary>
            /// 戳一戳强度(1-5 默认1)
            /// </summary>
            [JsonPropertyName("strength")]
            public int Strength { get; set; }

            /// <summary>
            /// 跳转链接-发送音乐
            /// </summary>
            [JsonPropertyName("url")]
            public string? Url { get; set; }

            /// <summary>
            /// 音乐链接-发送音乐
            /// </summary>
            [JsonPropertyName("audio")]
            public string? Audio { get; set; }

            /// <summary>
            /// 标题-发送音乐
            /// </summary>
            [JsonPropertyName("title")]
            public string? Title { get; set; }

            /// <summary>
            /// 封面-发送音乐
            /// </summary>
            [JsonPropertyName("image")]
            public string? Image { get; set; }

            /// <summary>
            /// 歌手-发送音乐
            /// </summary>
            [JsonPropertyName("singer")]
            public string? Singer { get; set; }

            /// <summary>
            /// qq
            /// </summary>
            [JsonPropertyName("qq")]
            public object? QQ { get; set; }

            /// <summary>
            /// 城市名称
            /// </summary>
            [JsonPropertyName("city")]
            public string? City { get; set; }

            /// <summary>
            /// 城市代码
            /// </summary>
            [JsonPropertyName("code")]
            public string? Code { get; set; }

            /// <summary>
            /// 经度
            /// </summary>
            [JsonPropertyName("lon")]
            public string? Lon { get; set; }

            /// <summary>
            /// 纬度
            /// </summary>
            [JsonPropertyName("lat")]
            public string? Lat { get; set; }

            /// <summary>
            /// 内容
            /// </summary>
            [JsonPropertyName("content")]
            public string? Content { get; set; }
        }
    }
}
