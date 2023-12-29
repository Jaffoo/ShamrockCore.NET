using Newtonsoft.Json;

namespace ShamrockCore.Reciver
{
    /// <summary>
    /// 事件基类
    /// </summary>
    public class EventBase
    {
        /// <summary>
        /// 发送时间
        /// </summary>
        [JsonProperty("time")]
        public long Time { get; set; }

        /// <summary>
        /// 机器人qq
        /// </summary>
        [JsonProperty("self_id")]
        public long BotQQ { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonProperty("post_type")]
        public PostType PostType { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonIgnore]
        public EventType EventType { get; set; }
    }
    public enum PostType
    {
        //message,
        //message_sent,////这两个类型是消息接收发送，此处是事件，所以不需要
        /// <summary>
        /// 通知事件
        /// </summary>
        notice,
        /// <summary>
        /// 请求事件
        /// </summary>
        request,
    }
    public enum EventType
    {
        /// <summary>
        /// 添加好友请求
        /// </summary>
        friend,

        /// <summary>
        /// 加群请求／邀请
        /// </summary>
        group,
        /// <summary>
        /// 群成员增加事件
        /// </summary>
        group_increase,

        /// <summary>
        /// 群成员减少事件
        /// </summary>
        group_decrease,

        /// <summary>
        /// 私聊消息撤回
        /// </summary>
        friend_recall,

        /// <summary>
        /// 群聊消息撤回
        /// </summary>
        group_recall,

        /// <summary>
        /// 群管理员变动
        /// </summary>
        group_admin,

        /// <summary>
        /// 群文件上传
        /// </summary>
        group_upload,

        /// <summary>
        /// 私聊文件上传
        /// </summary>
        private_upload,

        /// <summary>
        /// 群禁言
        /// </summary>
        group_ban,

        /// <summary>
        /// 群成员名片变动
        /// </summary>
        group_card,

        /// <summary>
        /// 精华消息
        /// </summary>
        essence,

        /// <summary>
        /// 头像戳一戳
        /// </summary>
        poke,

        /// <summary>
        /// 群头衔变更
        /// </summary>
        title
    }
}
