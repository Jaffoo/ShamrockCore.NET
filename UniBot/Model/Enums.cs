using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;

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

    public enum MessageType
    {
        /// <summary>
        /// 私聊消息
        /// </summary>
        Private,

        /// <summary>
        /// 群聊消息
        /// </summary>
        Group
    }

    public enum MessageSubType
    {
        /// <summary>
        /// 好友消息
        /// </summary>
        Friend,

        /// <summary>
        /// 群消息
        /// </summary>
        Group,

        /// <summary>
        /// 其他消息
        /// </summary>
        Other,

        /// <summary>
        /// 群正常消息
        /// </summary>
        Normal,

        /// <summary>
        /// 群匿名消息
        /// </summary>
        Anonymous,

        /// <summary>
        /// 群系统提示
        /// </summary>
        Notice
    }

    /// <summary>
    /// 性别
    /// </summary>
    public enum Genders
    {
        /// <summary>
        /// 男性
        /// </summary>
        [EnumMember(Value = "MALE")]
        [Description("MALE")]
        Male,

        /// <summary>
        /// 女性
        /// </summary>
        [EnumMember(Value = "FEMALE")]
        [Description("FEMALE")]
        Female,

        /// <summary>
        /// 未知
        /// </summary>
        [EnumMember(Value = "UNKNOWN")]
        [Description("UNKNOWN")]
        Unknown
    }

    /// <summary>
    /// 群内权限
    /// </summary>
    public enum Permissions
    {
        /// <summary>
        /// 群主
        /// </summary>
        [EnumMember(Value = "OWNER")]
        [Description("OWNER")]
        Owner,

        /// <summary>
        /// 管理员
        /// </summary>
        [EnumMember(Value = "ADMINISTRATOR")]
        [Description("ADMINISTRATOR")]
        Administrator,

        /// <summary>
        /// 群员
        /// </summary>
        [EnumMember(Value = "MEMBER")]
        [Description("MEMBER")]
        Member
    }
}
