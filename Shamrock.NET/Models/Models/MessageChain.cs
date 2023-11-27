using System;

namespace Shamrock.NET.Models
{
    public class MessageChainBuilder
    {
        private readonly List<MsgBase> List = [];

        /// <summary>
        /// 添加文本消息
        /// </summary>
        /// <param name="text">消息内容</param>
        /// <returns></returns>
        public MessageChainBuilder Text(string text)
        {
            MsgBase model = new()
            {
                Type = "text",
                Data = new()
                {
                    Text = text
                }
            };
            List.Add(model);
            return this;
        }
        /// <summary>
        /// 添加图片消息
        /// </summary>
        /// <param name="path">图片路径</param>
        /// <returns></returns>
        public MessageChainBuilder ImageByPath(string path)
        {
            MsgBase model = new()
            {
                Type = "image",
                Data = new()
                {
                    File = path.Contains("file://") ? path : "file://" + path,
                }
            };
            List.Add(model);
            return this;
        }
        /// <summary>
        /// 添加图片消息
        /// </summary>
        /// <param name="url">图片链接</param>
        /// <returns></returns>
        public MessageChainBuilder ImageByUrl(string url)
        {
            MsgBase model = new()
            {
                Type = "image",
                Data = new()
                {
                    Url = url,
                }
            };
            List.Add(model);
            return this;
        }
        /// <summary>
        /// 添加图片消息
        /// </summary>
        /// <param name="url">图片base64</param>
        /// <returns></returns>
        public MessageChainBuilder ImageByBase64(string base64)
        {
            MsgBase model = new()
            {
                Type = "image",
                Data = new()
                {
                    File = base64.Contains("base64://") ? base64 : "base64://" + base64,
                }
            };
            List.Add(model);
            return this;
        }
        /// <summary>
        /// 发送语音
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public MessageChainBuilder VoiceByPath(string path)
        {
            MsgBase model = new()
            {
                Type = "record",
                Data = new()
                {
                    File = path.Contains("file://") ? path : "file://" + path,
                }
            };
            List.Add(model);
            return this;
        }
        /// <summary>
        /// 发送语音
        /// </summary>
        /// <param name="url">url</param>
        /// <returns></returns>
        public MessageChainBuilder VoiceByUrl(string url)
        {
            MsgBase model = new()
            {
                Type = "record",
                Data = new()
                {
                    Url = url,
                }
            };
            List.Add(model);
            return this;
        }
        /// <summary>
        /// 发送视频
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public MessageChainBuilder VideoByPath(string path)
        {
            MsgBase model = new()
            {
                Type = "video",
                Data = new()
                {
                    File = path.Contains("file://") ? path : "file://" + path,
                }
            };
            List.Add(model);
            return this;
        }
        /// <summary>
        /// 发送视频
        /// </summary>
        /// <param name="url">链接</param>
        /// <returns></returns>
        public MessageChainBuilder VideoByUrl(string url)
        {
            //先调用Shamrock下载文件到缓存目录，然后发送path
            var path = url.Contains("file://") ? url : "file://" + url;
            MsgBase model = new()
            {
                Type = "video",
                Data = new()
                {
                    File = path,
                }
            };
            List.Add(model);
            return this;
        }
        /// <summary>
        /// at
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public MessageChainBuilder At(long qq)
        {
            MsgBase model = new()
            {
                Type = "at",
                Data = new()
                {
                    QQ = qq.ToString(),
                }
            };
            List.Add(model);
            return this;
        }
        /// <summary>
        /// at所有成员
        /// </summary>
        /// <returns></returns>
        public MessageChainBuilder AtAll()
        {
            MsgBase model = new()
            {
                Type = "at",
                Data = new()
                {
                    QQ = "all",
                }
            };
            List.Add(model);
            return this;
        }

        /// <summary>
        /// 戳一戳
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="type">类型</param>
        /// <param name="level">戳一戳强度(1-5 默认1)</param>
        /// <returns></returns>
        public MessageChainBuilder Poke(long qq, int type = 1, int level = 1)
        {
            MsgBase model = new()
            {
                Type = "poke",
                Data = new()
                {
                    Id = qq,
                    Type = type,
                    Strength = level
                }
            };
            List.Add(model);
            return this;
        }

        /// <summary>
        /// 戳一戳(双击头像)
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public MessageChainBuilder Touch(long qq)
        {
            MsgBase model = new()
            {
                Type = "touch",
                Data = new()
                {
                    Id = qq,
                }
            };
            List.Add(model);
            return this;
        }

        /// <summary>
        /// 音乐
        /// </summary>
        /// <param name="id">音乐 ID</param>
        /// <param name="type">音乐类型(qq/163)</param>
        /// <returns></returns>
        public MessageChainBuilder Music(int id, string type = "qq")
        {
            MsgBase model = new()
            {
                Type = "music",
                Data = new()
                {
                    Id = id,
                    Type = type
                }
            };
            List.Add(model);
            return this;
        }

        /// <summary>
        /// 音乐（自定义）
        /// </summary>
        /// <param name="url">跳转链接</param>
        /// <param name="audio">音乐链接</param>
        /// <param name="title">标题</param>
        /// <param name="singer">歌手</param>
        /// <param name="image">封面</param>
        /// <returns></returns>
        public MessageChainBuilder MusicDIY(string url, string audio, string title, string singer, string image)
        {
            MsgBase model = new()
            {
                Type = "music",
                Data = new()
                {
                    Type = "music",
                    Url = url,
                    Audio = audio,
                    Title = title,
                    Singer = singer,
                    Image = image
                }
            };
            List.Add(model);
            return this;
        }

        /// <summary>
        /// 发送天气
        /// </summary>
        /// <param name="city">城市</param>
        /// <returns></returns>
        public MessageChainBuilder WeatherByCity(string city)
        {
            MsgBase model = new()
            {
                Type = "weather",
                Data = new()
                {
                    City = city
                }
            };
            List.Add(model);
            return this;
        }
        /// <summary>
        /// 发送天气
        /// </summary>
        /// <param name="code">城市代码</param>
        /// <returns></returns>
        public MessageChainBuilder WeatherByCityCode(string code)
        {
            MsgBase model = new()
            {
                Type = "weather",
                Data = new()
                {
                    Code = code
                }
            };
            List.Add(model);
            return this;
        }

        /// <summary>
        /// 发送位置
        /// </summary>
        /// <param name="lat">纬度</param>
        /// <param name="lon">经度</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public MessageChainBuilder Location(string lat, string lon, string title = "", string content = "")
        {
            MsgBase model = new()
            {
                Type = "location",
                Data = new()
                {
                    Lat = lat,
                    Lon = lon
                }
            };
            List.Add(model);
            return this;
        }

        /// <summary>
        /// 链接分析
        /// </summary>
        /// <param name="url">https://example.com</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="img">https://example.com/image.jpg</param>
        /// <param name="file">https://example.com/image.jpg</param>
        /// <returns></returns>
        public MessageChainBuilder Share(string url, string title, string content = "", string img = "", string file = "")
        {
            MsgBase model = new()
            {
                Type = "share",
                Data = new()
                {
                    Url = url,
                    Title = title,
                    Content = content,
                    Image = img,
                    File = file
                }
            };
            List.Add(model);
            return this;
        }
        /// <summary>
        /// 发送礼物
        /// </summary>
        /// <param name="qq">qq</param>
        /// <param name="id">礼物id</param>
        /// <returns></returns>
        public MessageChainBuilder Gift(long qq, int id)
        {
            MsgBase model = new()
            {
                Type = "gift",
                Data = new()
                {
                    QQ = qq,
                    Id = id
                }
            };
            List.Add(model);
            return this;
        }

        /// <summary>
        /// 发送json
        /// </summary>
        /// <param name="json">json数据</param>
        /// <returns></returns>
        public MessageChainBuilder Json(string json)
        {
            MsgBase model = new()
            {
                Type = "json",
                Data = new()
                {
                    Data = json
                }
            };
            List.Add(model);
            return this;
        }

        public MessageChain Build()
        {
            return new(List);
        }
    }

    public class MessageChain : List<MsgBase>
    {
        public MessageChain() { }
        public MessageChain(IEnumerable<MsgBase> collection)
        {
            AddRange(collection);
        }

        /// <summary>
        /// 获取文本消息
        /// </summary>
        /// <param name="separator">分隔符</param>
        /// <returns></returns>
        public string GetTextMessage(string separator = ",")
        {
            var msgs = ToArray().Where(t => t.Type == "text").Select(t => t.Data?.Text);
            return string.Join(separator, msgs);
        }
        public async Task<string> SendToAsync(GroupMessageReceiver receiver)
        {
            return "";
        }
        public async Task<string> SendToAsync(FriendMessageReceiver receiver)
        {
            return "";
        }
        public async Task<string> SendToAsync(TempMessageReceiver receiver)
        {
            return "";
        }
    }
}
