using Newtonsoft.Json;
using UnifyBot.Utils;
using UnifyBot.Message.Chain;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 合并转发
    /// </summary>
    public class NodeMessage : MessageBase
    {
        public override Messages Type => Messages.Node;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        public NodeMessage() { }

        /// <summary>
        /// 合并转发
        /// </summary>
        /// <param name="msgId"></param>
        public NodeMessage(long msgId)
        {
            base.Data = new Body() { Id = msgId };
        }

        /// <summary>
        /// 合并转发自定义节点
        /// </summary>
        public NodeMessage(long qq, string nickname, string msg)
        {

            var text = new MessageChain
            {
                new TextMessage(msg)
            };
            base.Data = new Body()
            {
                QQ = qq,
                Nickname = nickname,
                Content = text
            };
        }

        /// <summary>
        /// 合并转发自定义节点
        /// </summary>
        public NodeMessage(long qq, string nickname, MessageChain msg)
        {
            base.Data = new Body() { QQ = qq, Nickname = nickname, Content = msg };
        }

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
            /// <summary>
            /// 转发的消息 ID
            /// </summary>
            public long Id { get; set; }

            /// <summary>
            /// 发送者 QQ 号
            /// </summary>
            [JsonProperty("user_id")]
            public long QQ { get; set; }

            /// <summary>
            /// 发送者昵称
            /// </summary>
            public string Nickname { get; set; } = "";

            /// <summary>
            /// 消息内容
            /// </summary>
            public MessageChain? Content { get; set; }
        }
    }
}
