using UnifyBot.Api;
using UnifyBot.Model;

namespace UnifyBot.Message.Chain
{
    /// <summary>
    /// 构建消息连
    /// </summary>
    public class MessageChainBuild
    {
        private readonly MessageChain list;
        public MessageChainBuild()
        {
            list = [];
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
        public MessageChainBuild Anonymous()
        {
            list.Add(new AnonymousMessage());
            return this;
        }

        /// <summary>
        /// at消息
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public MessageChainBuild At(string qq)
        {
            list.Add(new AtMessage(qq));
            return this;
        }

        /// <summary>
        /// at消息
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public MessageChainBuild At(long qq)
        {
            list.Add(new AtMessage(qq));
            return this;
        }

        /// <summary>
        /// at全体成员
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild AtAll()
        {
            return At("all");
        }

        /// <summary>
        /// 掷骰子魔法表情
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Dice()
        {
            list.Add(new DiceMessage());
            return this;
        }

        /// <summary>
        /// 表情消息
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Face(int id)
        {
            list.Add(new FaceMessage(id));
            return this;
        }

        /// <summary>
        /// 合并转发
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Forward(long forwardId)
        {
            list.Add(new ForwardMessage(forwardId));
            return this;
        }

        /// <summary>
        /// 图片消息
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild ImageByUrl(string url, ImageType type = 0, bool cache = true, bool proxy = true)
        {
            list.Add(new ImageByUrl(url, type, cache, proxy));
            return this;
        }

        /// <summary>
        /// 图片消息
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild ImageByPath(string path, ImageType type = 0)
        {
            list.Add(new ImageByPath(path, type));
            return this;
        }

        /// <summary>
        /// 图片消息
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild ImageByBase64(string base64, ImageType type = 0)
        {
            list.Add(new ImageByBase64(base64, type));
            return this;
        }

        /// <summary>
        /// json
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Json(string json)
        {
            list.Add(new JsonMessage(json));
            return this;
        }

        /// <summary>
        /// xml
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Xml(string xml)
        {
            list.Add(new XmlMessage(xml));
            return this;
        }

        /// <summary>
        /// 位置
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Location(double lat, double lon, string title = "", string content = "")
        {
            list.Add(new LocationMessage(lat, lon, title, content));
            return this;
        }

        /// <summary>
        /// 音乐
        /// </summary>
        /// <param name="musicId"></param>
        /// <param name="type">qq-qq音乐，163-网易云，xm-虾米</param>
        /// <returns></returns>
        public MessageChainBuild Music(string musicId, string type = "qq")
        {
            list.Add(new MusicMessage(musicId, type));
            return this;
        }

        /// <summary>
        /// 音乐
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild MusicCustom(string url, string audio, string title, string content = "", string image = "")
        {
            list.Add(new MusicMessage(url, audio, title, content, image));
            return this;
        }

        /// <summary>
        /// 节点合并转发
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Node(long msgId)
        {
            list.Add(new NodeMessage(msgId));
            return this;
        }

        /// <summary>
        /// 节点合并转发
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Node(long qq, string nickname, string msg)
        {
            list.Add(new NodeMessage(qq, nickname, msg));
            return this;
        }

        /// <summary>
        /// 节点合并转发
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Node(long qq, string nickname, MessageChain msg)
        {
            list.Add(new NodeMessage(qq, nickname, msg));
            return this;
        }

        /// <summary>
        /// 戳一戳
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Poke()
        {
            list.Add(new Poke());
            return this;
        }

        /// <summary>
        /// 比心
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild ShowLove()
        {
            list.Add(new ShowLove());
            return this;
        }

        /// <summary>
        /// 点赞
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Like()
        {
            list.Add(new Like());
            return this;
        }

        /// <summary>
        /// 心碎
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Heartbroken()
        {
            list.Add(new Heartbroken());
            return this;
        }

        /// <summary>
        /// 666
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild SixSixSix()
        {
            list.Add(new SixSixSix());
            return this;
        }

        /// <summary>
        /// 放大招
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild FangDaZhao()
        {
            list.Add(new FangDaZhao());
            return this;
        }

        /// <summary>
        /// 宝贝球 (SVIP)
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild BaoBeiQiu()
        {
            list.Add(new BaoBeiQiu());
            return this;
        }

        /// <summary>
        /// 玫瑰花 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Rose()
        {
            list.Add(new Rose());
            return this;
        }

        /// <summary>
        /// 召唤术 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild ZhaoHuanShu()
        {
            list.Add(new ZhaoHuanShu());
            return this;
        }

        /// <summary>
        /// 让你皮 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild RangNiPi()
        {
            list.Add(new RangNiPi());
            return this;
        }

        /// <summary>
        /// 结印 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild JieYin()
        {
            list.Add(new JieYin());
            return this;
        }

        /// <summary>
        /// 手雷 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild ShouLei()
        {
            list.Add(new ShouLei());
            return this;
        }

        /// <summary>
        /// 勾引 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild GouYin()
        {
            list.Add(new GouYin());
            return this;
        }

        /// <summary>
        /// 抓一下 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild ZhuaYiXia()
        {
            list.Add(new ZhuaYiXia());
            return this;
        }

        /// <summary>
        /// 碎屏 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild SuiPing()
        {
            list.Add(new SuiPing());
            return this;
        }

        /// <summary>
        /// 敲门 (SVIP) 
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild QiaoMen()
        {
            list.Add(new QiaoMen());
            return this;
        }

        /// <summary>
        /// 发语音
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild RecordByUrl(string url, bool cache = true, bool proxy = true)
        {
            list.Add(new RecordByUrl(url, cache, proxy));
            return this;
        }

        /// <summary>
        /// 发语音
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild RecordByPath(string path)
        {
            list.Add(new RecordByPath(path));
            return this;
        }

        /// <summary>
        /// 发语音
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild RecordByBase64(string base64)
        {
            list.Add(new RecordByBase64(base64));
            return this;
        }

        /// <summary>
        /// 回复
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Reply(long msgId)
        {
            list.Add(new ReplyMessage(msgId));
            return this;
        }

        /// <summary>
        /// 猜拳魔法表情
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Rps()
        {
            list.Add(new RpsMessage());
            return this;
        }

        /// <summary>
        /// 窗口抖动（戳一戳）
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Shake()
        {
            list.Add(new ShakeMessage());
            return this;
        }

        /// <summary>
        /// 连接分享
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Share(string url, string title, string content = "", string image = "")
        {
            list.Add(new ShareMessage(url, title, content, image));
            return this;
        }

        /// <summary>
        /// 文本消息
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild Text(string content)
        {
            list.Add(new TextMessage(content));
            return this;
        }

        /// <summary>
        /// 视频
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild VideoByUrl(string url, bool cache = true, bool proxy = true)
        {
            list.Add(new VideoByUrl(url, cache, proxy));
            return this;
        }

        /// <summary>
        /// 视频
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild VideoByPath(string path)
        {
            list.Add(new VideoByPath(path));
            return this;
        }

        /// <summary>
        /// 视频
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild VideoByBase64(string base64)
        {
            list.Add(new VideoByBase64(base64));
            return this;
        }

        /// <summary>
        /// 推荐好友
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild ContactFriend(long qq)
        {
            list.Add(new QQContact(qq));
            return this;
        }

        /// <summary>
        /// 推荐群
        /// </summary>
        /// <returns></returns>
        public MessageChainBuild ContactGroup(long qq)
        {
            list.Add(new GroupContact(qq));
            return this;
        }

        /// <summary>
        /// 发送群
        /// </summary>
        public async Task<long> SendGroup(Bot bot, long groupQQ)
        {
            return await bot.Conn.SendGroupMsg(groupQQ, list);
        }

        /// <summary>
        /// 发送群
        /// </summary>
        public async Task<long> SendGroup(GroupInfo group)
        {
            if (group.Connect.CanConnetBot) return await group.Connect.SendGroupMsg(group.GroupQQ, list);
            else throw new Exception("尽量不要手动实例化GroupInfo对象，如果非要这么做，实例化后将此对象中的Connect属性值用Bot.Conn赋值!");
        }

        /// <summary>
        /// 发送好友
        /// </summary>
        public async Task<long> SendPrivate(Bot bot, long qq)
        {
            return await bot.Conn.SendPrivateMsg(qq, list);
        }

        /// <summary>
        /// 发送好友
        /// </summary>
        public async Task<long> SendPrivate(FriendInfo friend)
        {
            if (friend.Connect.CanConnetBot) return await friend.Connect.SendPrivateMsg(friend.QQ, list);
            else throw new Exception("尽量不要手动实例化FriendInfo对象，如果非要这么做，实例化后将此对象中的Connect属性值用Bot.Conn赋值!");
        }
    }
}
