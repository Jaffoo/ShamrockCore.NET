using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 发送者的性别
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

    /// <summary>
    /// 发送消息类型
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// at
        /// </summary>
        At,

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
        /// json数据
        /// </summary>
        Json,

        /// <summary>
        /// 回复
        /// </summary>
        Reply,

        /// <summary>
        /// 语言
        /// </summary>
        Record,

        /// <summary>
        /// 视频
        /// </summary>
        Video,

        /// <summary>
        /// 篮球表情
        /// </summary>
        Basketball,

        /// <summary>
        /// 新猜拳
        /// </summary>
        New_rps,

        /// <summary>
        /// 新骰子
        /// </summary>
        New_dice,

        /// <summary>
        /// 戳一戳
        /// </summary>
        Poke,

        /// <summary>
        /// 戳一戳（双击头像）
        /// </summary>
        Touch,

        /// <summary>
        /// 音乐
        /// </summary>
        Music,

        /// <summary>
        /// 天气
        /// </summary>
        Weather,

        /// <summary>
        /// 位置
        /// </summary>
        Location,

        /// <summary>
        /// 连接分享
        /// </summary>
        Share,

        /// <summary>
        /// 礼物
        /// </summary>
        Gift,

        /// <summary>
        /// 事件
        /// </summary>
        Button,

        /// <summary>
        /// Markdown文本
        /// </summary>
        Markdown,
    }

    /// <summary>
    /// 篮球类型
    /// </summary>
    public enum Ball
    {
        /// <summary>
        /// 正中
        /// </summary>
        ZZ = 1,

        /// <summary>
        /// 擦边中
        /// </summary>
        CBZ = 2,

        /// <summary>
        /// 卡框
        /// </summary>
        KK = 3,

        /// <summary>
        /// 擦边没中
        /// </summary>
        CBMZ = 4,

        /// <summary>
        /// 没中
        /// </summary>
        MZ = 5
    }

    /// <summary>
    /// 猜拳类型
    /// </summary>
    public enum Rps
    {
        /// <summary>
        /// 布
        /// </summary>
        B = 1,

        /// <summary>
        /// 见到
        /// </summary>
        JD = 2,

        /// <summary>
        /// 石头
        /// </summary>
        ST = 3,
    }

    /// <summary>
    /// 主事件类型
    /// </summary>
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
        /// 请求事件
        /// </summary>
        Request,
    }

    /// <summary>
    /// 事件类型
    /// </summary>
    public enum PostEventType
    {
        /// <summary>
        /// 添加好友请求
        /// </summary>
        Friend,

        /// <summary>
        /// 加群请求／邀请
        /// </summary>
        Group,
        /// <summary>
        /// 群成员增加事件
        /// </summary>
        [JsonProperty("group_increase")] GroupIncrease,

        /// <summary>
        /// 群成员减少事件
        /// </summary>
        [JsonProperty("group_decrease")] GroupDecrease,

        /// <summary>
        /// 私聊消息撤回
        /// </summary>
        [JsonProperty("friend_recall")] FriendRecall,

        /// <summary>
        /// 群聊消息撤回
        /// </summary>
        [JsonProperty("group_recall")] GroupRecall,

        /// <summary>
        /// 群管理员变动
        /// </summary>
        [JsonProperty("group_admin")] GroupAdmin,

        /// <summary>
        /// 群文件上传
        /// </summary>
        [JsonProperty("group_upload")] GroupUpload,

        /// <summary>
        /// 私聊文件上传
        /// </summary>
        [JsonProperty("private_upload")] PrivateUpload,

        /// <summary>
        /// 群禁言
        /// </summary>
        [JsonProperty("group_ban")] GroupBan,

        /// <summary>
        /// 群成员名片变动
        /// </summary>
        [JsonProperty("group_card")] GroupCard,

        /// <summary>
        /// 精华消息
        /// </summary>
        Essence,

        /// <summary>
        /// 头像戳一戳
        /// </summary>
        Poke,

        /// <summary>
        /// 群头衔变更
        /// </summary>
        Title
    }

    /// <summary>
    /// 接收消息类型
    /// </summary>
    public enum PostMessageType
    {
        /// <summary>
        /// 群
        /// </summary>
        Group,

        /// <summary>
        /// 好友
        /// </summary>
        [JsonProperty("private")]
        Friend,

        /// <summary>
        /// 群私聊
        /// </summary>
        Less,

        /// <summary>
        /// 频道
        /// </summary>
        Guild,
    }

    /// <summary>
    /// 加群类型
    /// </summary>
    public enum AddType
    {
        /// <summary>
        /// 申请
        /// </summary>
        Approve,
        /// <summary>
        /// 邀请
        /// </summary>
        Invite,
    }

    /// <summary>
    /// 退群类型
    /// </summary>
    public enum LeaveType
    {
        /// <summary>
        /// 退群
        /// </summary>
        Leave,
        /// <summary>
        /// 踢人
        /// </summary>
        Kick,
        /// <summary>
        /// 自己
        /// </summary>
        [JsonProperty("kick_me")] Self,
    }

    /// <summary>
    /// 管理员操作类型
    /// </summary>
    public enum AdminType
    {
        /// <summary>
        /// 任命
        /// </summary>
        Set,
        /// <summary>
        /// 卸任
        /// </summary>
        Unset,
    }

    /// <summary>
    /// 禁言类型
    /// </summary>
    public enum BanType
    {
        /// <summary>
        /// 禁言
        /// </summary>
        Ban,
        /// <summary>
        /// 解禁
        /// </summary>
        [JsonProperty("lift_ban")]
        LiftBan
    }

    /// <summary>
    /// 精华消息类型
    /// </summary>
    public enum EssenceType
    {
        /// <summary>
        /// 添加
        /// </summary>
        Add,
        /// <summary>
        /// 删除
        /// </summary>
        Delete
    }

    /// <summary>
    /// 发送图片的类型
    /// </summary>
    public enum ImgType
    {
        /// <summary>
        /// 不知道是啥
        /// </summary>
        Show,
        /// <summary>
        /// 应该是闪照
        /// </summary>
        Flash,
        /// <summary>
        /// 原图
        /// </summary>
        Original
    }

    /// <summary>
    /// 发送图片的子类型
    /// </summary>
    public enum ImgSubType
    {
        /// <summary>
        /// 正常图片
        /// </summary>
        Normal,
        /// <summary>
        /// 表情包, 在客户端会被分类到表情包图片并缩放显示
        /// </summary>
        Face,
        /// <summary>
        /// 热图
        /// </summary>
        Hot,
        /// <summary>
        /// 斗图
        /// </summary>
        Fight,
        /// <summary>
        /// 智图?
        /// </summary>
        Smart,
        /// <summary>
        /// 贴图
        /// </summary>
        Map = 7,
        /// <summary>
        /// 自拍
        /// </summary>
        Self,
        /// <summary>
        /// 贴图广告?
        /// </summary>
        Adv,
        /// <summary>
        /// 有待测试
        /// </summary>
        Unkonw,
        /// <summary>
        /// 热搜图
        /// </summary>
        HotSearch = 13
    }

    /// <summary>
    /// 子频道类型
    /// </summary>
    public enum ChannelType
    {
        /// <summary>
        /// 文字频道
        /// </summary>
        Text=1,
        /// <summary>
        /// 语言频道
        /// </summary>
        Record,
        /// <summary>
        /// 直播频道
        /// </summary>
        Live,
        /// <summary>
        /// 主题频道
        /// </summary>
        Theme
    }

    public class LowercaseStringEnumConverter : StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is Enum)
            {
                string enumString = value!.ToString()!.ToLower();
                writer.WriteValue(enumString);
            }
            else
            {
                base.WriteJson(writer, value, serializer);
            }
        }
    }
}