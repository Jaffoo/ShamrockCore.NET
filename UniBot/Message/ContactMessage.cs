using UniBot.Message;
using UniBot.Model;

namespace UniBot.Contact
{
    /// <summary>
    /// 掷骰子魔法表情
    /// </summary>
    public class ContactMessage : MessageBase
    {
        public override Messages Type => Messages.Contact;

        public ContactMessage(string type, string qq)
        {
            Data = new Body()
            {
                Type = type,
                Id = qq
            };
        }
    }

    /// <summary>
    /// 消息体
    /// </summary>
    public class Body
    {
        /// <summary>
        /// 推荐类型只能填入qq/group
        /// </summary>
        public string Type { get; set; } = "";

        /// <summary>
        /// 被推荐人/群的 QQ 号
        /// </summary>
        public string Id { get; set; } = "";
    }

    /// <summary>
    /// 推荐好友
    /// </summary>
    public class QQContact : ContactMessage
    {
        public QQContact(string qq) : base("qq", qq)
        {

        }
    }

    /// <summary>
    /// 推荐群
    /// </summary>
    public class GroupContact : ContactMessage
    {
        public GroupContact(string qq) : base("group", qq)
        {

        }
    }
}
