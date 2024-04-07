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
        Request,

        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow
    }

    /// <summary>
    /// 发送/接收的消息内容的具体类型
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

        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow
    }

    /// <summary>
    /// 收到的消息类型
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 私聊消息
        /// </summary>
        Private,

        /// <summary>
        /// 群聊消息
        /// </summary>
        Group,

        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow
    }

    /// <summary>
    /// 收到的消息类型的子类型
    /// </summary>
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
        Notice,

        /// <summary>
        /// 退群
        /// </summary>
        Leave,

        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow
    }

    /// <summary>
    /// 性别
    /// </summary>
    public enum Genders
    {
        /// <summary>
        /// 男性
        /// </summary>
        Male,

        /// <summary>
        /// 女性
        /// </summary>
        Female,

        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow
    }

    /// <summary>
    /// 群内权限
    /// </summary>
    public enum Permissions
    {
        /// <summary>
        /// 群主
        /// </summary>
        Owner,

        /// <summary>
        /// 管理员
        /// </summary>
        Admin,

        /// <summary>
        /// 群员
        /// </summary>
        Member,

        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow
    }

    /// <summary>
    /// 请求类型
    /// </summary>
    public enum RequestType
    {
        /// <summary>
        /// 好友
        /// </summary>
        Friend,

        /// <summary>
        /// 群
        /// </summary>
        Group,

        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow
    }

    /// <summary>
    /// 请求子类型
    /// </summary>
    public enum RequestSubType
    {
        /// <summary>
        /// 主动请求
        /// </summary>
        Add,

        /// <summary>
        /// 邀请（被动）
        /// </summary>
        Invite,

        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow
    }

    /// <summary>
    /// 通知类型
    /// </summary>
    public enum NoticeType
    {
        /// <summary>
        /// 群文件上传
        /// </summary>
        [JsonProperty("group_upload")]
        GroupUpload,

        /// <summary>
        /// 群管变动
        /// </summary>
        [JsonProperty("group_admin")]
        GroupAdmin,

        /// <summary>
        /// 群成员减少
        /// </summary>
        [JsonProperty("group_decrease")]
        GroupDecrease,

        /// <summary>
        /// 群成员增加
        /// </summary>
        [JsonProperty("group_increase")]
        GroupIncrease,

        /// <summary>
        /// 群禁言
        /// </summary>
        [JsonProperty("group_ban")]
        GroupBan,

        /// <summary>
        /// 好友添加
        /// </summary>
        [JsonProperty("friend_add")]
        FriendAdd,

        /// <summary>
        /// 群消息撤回
        /// </summary>
        [JsonProperty("group_recall")]
        GroupRecall,

        /// <summary>
        /// 好友消息撤回
        /// </summary>
        [JsonProperty("friend_recall")]
        FriendRecall,

        /// <summary>
        /// 群内戳一戳/群红包运气王/群成员荣誉变更
        /// </summary>
        [JsonProperty("notify")]
        Notify,

        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow
    }

    /// <summary>
    /// 通知子类型
    /// </summary>
    public enum NoticeSubType
    {
        /// <summary>
        /// 群成员荣誉变更
        /// </summary>
        [JsonProperty("honor")]
        Honor,

        /// <summary>
        /// 群红包运气王
        /// </summary>
        [JsonProperty("lucky_king")]
        LuckyKing,

        /// <summary>
        /// 群内戳一戳
        /// </summary>
        [JsonProperty("poke")]
        Poke,

        /// <summary>
        /// 任命管理
        /// </summary>
        Set,

        /// <summary>
        /// 卸任管理
        /// </summary>
        Unset,

        /// <summary>
        /// 禁言
        /// </summary>
        Ban,

        /// <summary>
        /// 解除禁言
        /// </summary>
        LeftBan,

        /// <summary>
        /// 未知
        /// </summary>
        Unknow = 99,
    }

    /// <summary>
    /// 荣誉类型
    /// </summary>
    public enum HonorType
    {
        /// <summary>
        /// 龙王
        /// </summary>
        Talkative,

        /// <summary>
        /// 群聊之火
        /// </summary>
        Performer,

        /// <summary>
        /// 快乐源泉
        /// </summary>
        Emotion,

        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow
    }

    /// <summary>
    /// 元事件类型
    /// </summary>
    public enum MetaType
    {
        /// <summary>
        /// 生命周期
        /// </summary>
        [JsonProperty("lifecycle")]
        LifeCycle,

        /// <summary>
        /// 心跳
        /// </summary>
        [JsonProperty("heartbeat")]
        HeartBeat,

        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow
    }

    /// <summary>
    /// 事件子类型
    /// </summary>
    public enum MetaSubType
    {
        /// <summary>
        /// 启用
        /// </summary>
        Enable,

        /// <summary>
        /// 停用
        /// </summary>
        Disable,

        /// <summary>
        /// 连接成功
        /// </summary>
        Connect,

        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow
    }

    /// <summary>
    /// 所有事件
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// 好友申请
        /// </summary>
        [JsonProperty("friend")]
        FriendRequest,

        /// <summary>
        /// 加群申请
        /// </summary>
        [JsonProperty("group")]
        GroupRequest,

        /// <summary>
        /// 群文件上传
        /// </summary>
        [JsonProperty("group_upload")]
        GroupUpload,

        /// <summary>
        /// 群管变动
        /// </summary>
        [JsonProperty("group_admin")]
        GroupAdmin,

        /// <summary>
        /// 群成员减少
        /// </summary>
        [JsonProperty("group_decrease")]
        GroupDecrease,

        /// <summary>
        /// 群成员增加
        /// </summary>
        [JsonProperty("group_increase")]
        GroupIncrease,

        /// <summary>
        /// 群禁言
        /// </summary>
        [JsonProperty("group_ban")]
        GroupBan,

        /// <summary>
        /// 好友添加
        /// </summary>
        [JsonProperty("friend_add")]
        FriendAdd,

        /// <summary>
        /// 群消息撤回
        /// </summary>
        [JsonProperty("group_recall")]
        GroupRecall,

        /// <summary>
        /// 好友消息撤回
        /// </summary>
        [JsonProperty("friend_recall")]
        FriendRecall,

        /// <summary>
        /// 群内戳一戳/群红包运气王/群成员荣誉变更
        /// </summary>
        [JsonProperty("notify")]
        Notify,
        /// <summary>
        /// 生命周期
        /// </summary>
        [JsonProperty("lifecycle")]
        LifeCycle,

        /// <summary>
        /// 心跳
        /// </summary>
        [JsonProperty("heartbeat")]
        HeartBeat,

        /// <summary>
        /// 未知类型
        /// </summary>
        Unknow
    }
}
