using UniBot.Anonymous;
using UniBot.At;
using UniBot.Dict;
using UniBot.Face;
using UniBot.Forward;
using UniBot.Image;
using UniBot.Json;
using UniBot.Location;
using UniBot.Music;
using UniBot.Node;
using UniBot.Poke;
using UniBot.Record;
using UniBot.Reply;
using UniBot.Rps;
using UniBot.Shake;
using UniBot.Share;
using UniBot.Text;
using UniBot.Video;
using UniBot.Xml;

namespace UniBot.Message
{
    /// <summary>
    /// 构建消息连
    /// </summary>
    public class MessageChainBuild
    {
        private readonly MessageChain list;
        public MessageChainBuild()
        {
            list = new();
        }

        public MessageChainBuild(MessageChain chain)
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
        /// 匿名发送消息
        /// </summary>
        /// <returns></returns>
        public MessageChain Anonymous()
        {
            list.Add(new AnonymousMessage());
            return list;
        }

        /// <summary>
        /// at消息
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public MessageChain At(string qq)
        {
            list.Add(new AtMessage(qq));
            return list;
        }

        /// <summary>
        /// at全体成员
        /// </summary>
        /// <returns></returns>
        public MessageChain AtAll()
        {
            return At("all");
        }

        /// <summary>
        /// 掷骰子魔法表情
        /// </summary>
        /// <returns></returns>
        public MessageChain Dice()
        {
            list.Add(new DiceMessage());
            return At("all");
        }

        /// <summary>
        /// 表情消息
        /// </summary>
        /// <returns></returns>
        public MessageChain Face(int id)
        {
            list.Add(new FaceMessage(id));
            return list;
        }

        /// <summary>
        /// 合并转发
        /// </summary>
        /// <returns></returns>
        public MessageChain Forward(long forwardId)
        {
            list.Add(new ForwardMessage(forwardId));
            return list;
        }

        /// <summary>
        /// 图片消息
        /// </summary>
        /// <returns></returns>
        public MessageChain ImageByUrl(string url, bool cache = true, bool proxy = true)
        {
            list.Add(new ImageByUrl(url, cache, proxy));
            return list;
        }

        /// <summary>
        /// 图片消息
        /// </summary>
        /// <returns></returns>
        public MessageChain ImageByPath(string path)
        {
            list.Add(new ImageByPath(path));
            return list;
        }

        /// <summary>
        /// 图片消息
        /// </summary>
        /// <returns></returns>
        public MessageChain ImageByBase64(string base64)
        {
            list.Add(new ImageByBase64(base64));
            return list;
        }

        /// <summary>
        /// json
        /// </summary>
        /// <returns></returns>
        public MessageChain Json(string json)
        {
            list.Add(new JsonMessage(json));
            return list;
        }

        /// <summary>
        /// xml
        /// </summary>
        /// <returns></returns>
        public MessageChain Xml(string xml)
        {
            list.Add(new XmlMessage(xml));
            return list;
        }

        /// <summary>
        /// 位置
        /// </summary>
        /// <returns></returns>
        public MessageChain Location(double lat, double lon, string title = "", string content = "")
        {
            list.Add(new LocationMessage(lat, lon, title, content));
            return list;
        }

        /// <summary>
        /// 音乐
        /// </summary>
        /// <param name="musicId"></param>
        /// <param name="type">qq-qq音乐，163-网易云，xm-虾米</param>
        /// <returns></returns>
        public MessageChain Music(string musicId, string type = "qq")
        {
            list.Add(new MusicMessage(musicId, type));
            return list;
        }

        /// <summary>
        /// 音乐
        /// </summary>
        /// <returns></returns>
        public MessageChain MusicCustom(string url, string audio, string title, string content = "", string image = "")
        {
            list.Add(new MusicMessage(url, audio, title, content, image));
            return list;
        }

        /// <summary>
        /// 节点合并转发
        /// </summary>
        /// <returns></returns>
        public MessageChain Node(long msgId)
        {
            list.Add(new NodeMessage(msgId));
            return list;
        }

        /// <summary>
        /// 戳一戳
        /// </summary>
        /// <returns></returns>
        public MessageChain Poke()
        {
            list.Add(new Poke.Poke());
            return list;
        }

        /// <summary>
        /// 比心
        /// </summary>
        /// <returns></returns>
        public MessageChain ShowLove()
        {
            list.Add(new ShowLove());
            return list;
        }

        /// <summary>
        /// 点赞
        /// </summary>
        /// <returns></returns>
        public MessageChain Like()
        {
            list.Add(new Like());
            return list;
        }

        /// <summary>
        /// 心碎
        /// </summary>
        /// <returns></returns>
        public MessageChain Heartbroken()
        {
            list.Add(new Heartbroken());
            return list;
        }

        /// <summary>
        /// 666
        /// </summary>
        /// <returns></returns>
        public MessageChain SixSixSix()
        {
            list.Add(new SixSixSix());
            return list;
        }

        /// <summary>
        /// 放大招
        /// </summary>
        /// <returns></returns>
        public MessageChain FangDaZhao()
        {
            list.Add(new FangDaZhao());
            return list;
        }

        /// <summary>
        /// 宝贝球 (SVIP)
        /// </summary>
        /// <returns></returns>
        public MessageChain BaoBeiQiu()
        {
            list.Add(new BaoBeiQiu());
            return list;
        }

        /// <summary>
        /// 玫瑰花 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChain Rose()
        {
            list.Add(new Rose());
            return list;
        }

        /// <summary>
        /// 召唤术 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChain ZhaoHuanShu()
        {
            list.Add(new ZhaoHuanShu());
            return list;
        }

        /// <summary>
        /// 让你皮 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChain RangNiPi()
        {
            list.Add(new RangNiPi());
            return list;
        }

        /// <summary>
        /// 结印 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChain JieYin()
        {
            list.Add(new JieYin());
            return list;
        }

        /// <summary>
        /// 手雷 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChain ShouLei()
        {
            list.Add(new ShouLei());
            return list;
        }

        /// <summary>
        /// 勾引 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChain GouYin()
        {
            list.Add(new GouYin());
            return list;
        }

        /// <summary>
        /// 抓一下 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChain ZhuaYiXia()
        {
            list.Add(new ZhuaYiXia());
            return list;
        }

        /// <summary>
        /// 碎屏 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChain SuiPing()
        {
            list.Add(new SuiPing());
            return list;
        }

        /// <summary>
        /// 敲门 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChain QiaoMen()
        {
            list.Add(new QiaoMen());
            return list;
        }

        /// <summary>
        /// 发语音
        /// </summary>
        /// <returns></returns>
        public MessageChain RecordByUrl(string url, bool cache = true, bool proxy = true)
        {
            list.Add(new RecordByUrl(url, cache, proxy));
            return list;
        }

        /// <summary>
        /// 发语音
        /// </summary>
        /// <returns></returns>
        public MessageChain RecordByPath(string path)
        {
            list.Add(new RecordByPath(path));
            return list;
        }

        /// <summary>
        /// 发语音
        /// </summary>
        /// <returns></returns>
        public MessageChain RecordByBase64(string base64)
        {
            list.Add(new RecordByBase64(base64));
            return list;
        }

        /// <summary>
        /// 回复
        /// </summary>
        /// <returns></returns>
        public MessageChain Reply(long msgId)
        {
            list.Add(new ReplyMessage(msgId));
            return list;
        }

        /// <summary>
        /// 猜拳魔法表情
        /// </summary>
        /// <returns></returns>
        public MessageChain Rps()
        {
            list.Add(new RpsMessage());
            return list;
        }

        /// <summary>
        /// 窗口抖动（戳一戳）
        /// </summary>
        /// <returns></returns>
        public MessageChain Shake()
        {
            list.Add(new ShakeMessage());
            return list;
        }

        /// <summary>
        /// 连接分享
        /// </summary>
        /// <returns></returns>
        public MessageChain Share(string url, string title, string content = "", string image = "")
        {
            list.Add(new ShareMessage(url, title, content, image));
            return list;
        }

        /// <summary>
        /// 文本消息
        /// </summary>
        /// <returns></returns>
        public MessageChain Text(string content)
        {
            list.Add(new TextMessage(content));
            return list;
        }

        /// <summary>
        /// 视频
        /// </summary>
        /// <returns></returns>
        public MessageChain VideoByUrl(string url, bool cache = true, bool proxy = true)
        {
            list.Add(new VideoByUrl(url, cache, proxy));
            return list;
        }

        /// <summary>
        /// 视频
        /// </summary>
        /// <returns></returns>
        public MessageChain VideoByPath(string path)
        {
            list.Add(new VideoByPath(path));
            return list;
        }

        /// <summary>
        /// 视频
        /// </summary>
        /// <returns></returns>
        public MessageChain VideoByBase64(string base64)
        {
            list.Add(new VideoByBase64(base64));
            return list;
        }
    }
}
