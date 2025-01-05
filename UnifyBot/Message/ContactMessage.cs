using Newtonsoft.Json;
using UnifyBot.Utils;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 推荐好友
    /// </summary>
    public class ContactMessage : MessageBase
    {
        public override Messages Type => Messages.Contact;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        public ContactMessage() { }
        public ContactMessage(string type, long qq)
        {
            base.Data = new Body()
            {
                Type = type,
                Id = qq
            };
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
            public long Id { get; set; }
        }
    }

    /// <summary>
    /// 推荐好友
    /// </summary>
    public class QQContact : ContactMessage
    {
        public QQContact() { }
        public QQContact(long qq) : base("qq", qq)
        {

        }
    }

    /// <summary>
    /// 推荐群
    /// </summary>
    public class GroupContact : ContactMessage
    {
        public GroupContact() { }
        public GroupContact(long qq) : base("group", qq)
        {

        }
    }
}
