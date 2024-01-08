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

    public enum MessageType
    {
        At,
        Text,
        Face,
        Image,
        Json,
        Reply,
        Record,
        Video,
        Basketball,
        New_rps,
        New_dice,
        Poke,
        Touch,
        Music,
        Weather,
        Location,
        Share,
        Gift
    }

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
        [JsonProperty("group_increase")]GroupIncrease,

        /// <summary>
        /// 群成员减少事件
        /// </summary>
        [JsonProperty("group_decrease")]GroupDecrease,

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

    public enum PostMessageType
    {
        Group,
        [JsonProperty("private")]
        Friend
    }
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
        [JsonProperty("kick_me")]Self,
    }

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