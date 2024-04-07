using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using UniBot.Message.Chain;
using UniBot.Model;

namespace UniBot.Receiver.MessageReceiver
{
    public class GroupReceiver : MessageReceiver
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonIgnore]
        public override MessageType MessageType => MessageType.Group;

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 匿名信息，如果不是匿名消息则为 null
        /// </summary>
        public Anonymous Anonymous { get { return new() { Connect = Connect, GroupQQ = GroupQQ }; } set { } }

        /// <summary>
        /// 发送人
        /// </summary>
        public GroupSender Sender { get; set; } = new();

        #region 扩展方法/属性
        /// <summary>
        /// 群信息
        /// </summary>
        [JsonIgnore]
        public Lazy<GroupInfo> Group => new(() => Connect.GetGroupInfo(GroupQQ).Result);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendMessage(MessageChain msg) => await Connect.SendGroupMsg(GroupQQ, msg);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendMessage(string msg) => await Connect.SendGroupMsg(GroupQQ, msg);

        #endregion
    }
}
