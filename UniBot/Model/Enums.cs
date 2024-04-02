using Newtonsoft.Json;

namespace UniBot.Model
{
    public enum PostType
    {
        /// <summary>
        /// 消息事件
        /// </summary>
        Message,

        /// <summary>
        /// 通知事件
        /// </summary>
        Notice,

        /// <summary>
        /// 元事件
        /// </summary>
        [JsonProperty("meta_event")]
        MetaEvent,

        /// <summary>
        /// 请求事件
        /// </summary>
        Request
    }

    /// <summary>
    /// 消息类型
    /// </summary>
    public enum Messages
    {
        /// <summary>
        /// 文本
        /// </summary>
        Text,

        /// <summary>
        /// 表情
        /// </summary>
        Face,

        /// <summary>
        /// 图片
        /// </summary>
        Image,

        /// <summary>
        /// 语音
        /// </summary>
        Record,

        /// <summary>
        /// 短视频
        /// </summary>
        Video,

        /// <summary>
        /// @某人
        /// </summary>
        At,

        /// <summary>
        /// 猜拳魔法表情
        /// </summary>
        Rps,

        /// <summary>
        /// 掷骰子魔法表情
        /// </summary>
        Dice,

        /// <summary>
        /// 窗口抖动（戳一戳）
        /// </summary>
        Shake,

        /// <summary>
        /// 戳一戳
        /// </summary>
        Poke,

        /// <summary>
        /// 匿名发消息
        /// </summary>
        Anonymous,

        /// <summary>
        /// 连接分享
        /// </summary>
        Share,

        /// <summary>
        /// 推荐好友/推荐群
        /// </summary>
        Contact,

        /// <summary>
        /// 位置
        /// </summary>
        Location,

        /// <summary>
        /// 音乐分享/自定义分享
        /// </summary>
        Music,

        /// <summary>
        /// 回复
        /// </summary>
        Reply,

        /// <summary>
        /// 合并转发
        /// </summary>
        Forward,

        /// <summary>
        /// 合并转发节点/自定义节点
        /// </summary>
        Node,

        /// <summary>
        /// xml
        /// </summary>
        Xml,

        /// <summary>
        /// JSON
        /// </summary>
        Json,
    }
}
