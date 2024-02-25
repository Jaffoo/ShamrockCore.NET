using System.Text.RegularExpressions;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Receiver.MsgChain
{
    /// <summary>
    /// 消息构建类
    /// </summary>
    public class MessageChainBuilder
    {
        private readonly MessageChain list;
        public MessageChainBuilder()
        {
            list = new();
        }

        public MessageChainBuilder(MessageChain chain)
        {
            list = chain;
        }

        /// <summary>
        /// 构建消息
        /// </summary>
        /// <returns></returns>
        public MessageChain Build()
        {
            return list;
        }

        /// <summary>
        /// 文本消息
        /// </summary>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public MessageChainBuilder Text(string msg)
        {
            list.Add(new TextMessage(msg));
            return this;
        }

        /// <summary>
        /// at
        /// </summary>
        /// <param name="qq">qq</param>
        /// <returns></returns>
        public MessageChainBuilder At(long qq)
        {
            list.Add(new AtMessage(qq));
            return this;
        }

        /// <summary>
        /// at全体成员
        /// </summary>
        /// <returns></returns>
        public MessageChainBuilder AtAll()
        {
            list.Add(new AtMessage(0));
            return this;
        }

        /// <summary>
        /// 表情
        /// </summary>
        /// <param name="id">表情id</param>
        /// <returns></returns>
        public MessageChainBuilder Face(int id)
        {
            list.Add(new FaceMessage(id));
            return this;
        }

        /// <summary>
        /// 回复消息
        /// </summary>
        /// <param name="id">回复消息的id</param>
        /// <returns></returns>
        public MessageChainBuilder Reply(int id)
        {
            list.Add(new ReplyMessage(id));
            return this;
        }

        /// <summary>
        /// 图片
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="imgType">图片类型</param>
        /// <param name="imgSubType">图片子类型</param>
        /// <returns></returns>
        public MessageChainBuilder ImageByPath(string path, ImgType? imgType = null, ImgSubType? imgSubType = null)
        {
            if (!path.Contains("file://")) path = "file://" + path;
            list.Add(new ImageMessage(file: path, imgType: imgType, imgSubType: imgSubType));
            return this;
        }

        /// <summary>
        /// 图片
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="imgType">图片类型</param>
        /// <param name="imgSubType">图片子类型</param>
        /// <returns></returns>
        public MessageChainBuilder ImageByUrl(string url, ImgType? imgType = null, ImgSubType? imgSubType = null)
        {
            list.Add(new ImageMessage(url: url, imgType: imgType, imgSubType: imgSubType));
            return this;
        }

        /// <summary>
        /// 图片
        /// </summary>
        /// <param name="base64">base64编码</param>
        /// <param name="imgType">图片类型</param>
        /// <param name="imgSubType">图片子类型</param>
        /// <returns></returns>
        public MessageChainBuilder ImageByBase64(string base64, ImgType? imgType = null, ImgSubType? imgSubType = null)
        {
            string pattern = @"data:[a-zA-Z0-9]+/[a-zA-Z0-9]+;base64,";
            string result = Regex.Replace(base64, pattern, "");
            if (!result.Contains("base64://")) result = "base64://" + result;
            list.Add(new ImageMessage(base64: result, imgType: imgType, imgSubType: imgSubType));
            return this;
        }

        /// <summary>
        /// 语音
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="magic">是否为魔法语音</param>
        /// <returns></returns>
        public MessageChainBuilder RecordByPath(string path, bool magic = false)
        {
            if (!path.Contains("file://")) path = "file://" + path;
            list.Add(new RecordMessage(path, magic: magic));
            return this;
        }

        /// <summary>
        /// 语音
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="magic">是否为魔法语音</param>
        /// <returns></returns>
        public MessageChainBuilder RecordByUrl(string url, bool magic = false)
        {
            list.Add(new RecordMessage(url: url, magic: magic));
            return this;
        }

        /// <summary>
        /// 视频
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public MessageChainBuilder Video(string path)
        {
            if (!path.Contains("file://")) path = "file://" + path;
            list.Add(new VideoMessage(path));
            return this;
        }

        /// <summary>
        /// 篮球
        /// </summary>
        /// <param name="id">进球类型</param>
        /// <returns></returns>
        public MessageChainBuilder Ball(Ball id)
        {
            list.Add(new BallMessage(id));
            return this;
        }

        /// <summary>
        /// 猜拳
        /// </summary>
        /// <param name="id">出拳类型</param>
        /// <returns></returns>
        public MessageChainBuilder Rps(Rps id)
        {
            list.Add(new RpsMessage(id));
            return this;
        }

        /// <summary>
        /// 戳一戳(双击头像)
        /// </summary>
        /// <param name="qq">qq</param>
        /// <returns></returns>
        public MessageChainBuilder Touch(long qq)
        {
            list.Add(new TouchMessage(qq));
            return this;
        }

        /// <summary>
        /// 戳一戳表情
        /// </summary>
        /// <param name="type">戳一戳类型</param>
        /// <param name="id">戳一戳表情</param>
        /// <param name="strength">戳一戳强度(1-5)</param>
        /// <returns></returns>
        public MessageChainBuilder Poke(int type = 1, int id = 10000, int strength = 1)
        {
            list.Add(new PokeMessage(new() { Id = id, Type = type, Strength = strength }));
            return this;
        }

        /// <summary>
        /// 骰子
        /// </summary>
        /// <param name="num">点数（1-6）</param>
        /// <returns></returns>
        public MessageChainBuilder Dice(int num)
        {
            list.Add(new DiceMessage(num));
            return this;
        }

        /// <summary>
        /// 音乐
        /// </summary>
        /// <param name="id">音乐id</param>
        /// <param name="type">音乐类型(qq/163)</param>
        public MessageChainBuilder Music(long id, string type = "qq")
        {
            list.Add(new MusicMessage(id, type));
            return this;
        }

        /// <summary>
        /// 音乐自定义
        /// </summary>
        public MessageChainBuilder MusicCustom(MusicCustomMessage.Body music)
        {
            list.Add(new MusicCustomMessage(music));
            return this;
        }

        /// <summary>
        /// 位置
        /// </summary>
        /// <param name="lat">纬度</param>
        /// <param name="lon">经度</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public MessageChainBuilder Location(float lat, float lon, string title = "", string content = "")
        {
            list.Add(new LocationMessage(new()
            {
                Lat = lat,
                Lon = lon,
                Title = title,
                Content = content
            }));
            return this;
        }

        /// <summary>
        /// 天气
        /// </summary>
        /// <param name="city">城市</param>
        /// <param name="code">城市代码</param>
        public MessageChainBuilder Weather(string code, string city = "")
        {
            list.Add(new WeatherMessage(new() { City = city, Code = code }));
            return this;
        }

        /// <summary>
        /// 链接分享
        /// </summary>
        /// <param name="url">链接地址</param>
        /// <param name="image">图片链接</param>
        /// <param name="file">文件链接</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public MessageChainBuilder Share(string url, string image = "", string file = "", string title = "", string content = "")
        {
            list.Add(new ShareMessage(new()
            {
                Url = url,
                Image = image,
                File = file,
                Title = title,
                Content = content
            }));
            return this;
        }

        /// <summary>
        /// 礼物
        /// </summary>
        /// <param name="qq">qq</param>
        /// <param name="giftId">礼物id</param>
        public MessageChainBuilder Gift(long qq, int giftId)
        {
            list.Add(new GiftMessage(qq, giftId));
            return this;
        }

        /// <summary>
        /// JSON 消息
        /// </summary>
        public MessageChainBuilder Json(JsonMessage.Body json)
        {
            list.Add(new JsonMessage(json));
            return this;
        }

        /// <summary>
        /// 合并转发(暂留，不可用)
        /// </summary>
        public MessageChainBuilder Merge()
        {
            //list.Add(new MergeMessage());
            return this;
        }

        /// <summary>
        /// 合并转发节点(暂留，不可用)
        /// </summary>
        public MessageChainBuilder MergeNode()
        {
            //list.Add(new MergeMessage());
            return this;
        }

        /// <summary>
        /// 弹射表情
        /// </summary>
        /// <param name="id">表情id</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public MessageChainBuilder BubbleFace(int id, int count)
        {
            list.Add(new BubbleFaceMessage(id, count));
            return this;
        }
    }
}