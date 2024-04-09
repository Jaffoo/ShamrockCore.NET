using Newtonsoft.Json;
using UnifyBot.Api;
using UnifyBot.Message.Chain;
using UnifyBot.Model;

namespace UnifyBot.Receiver.MessageReceiver
{
    public class PrivateReceiver : MessageReceiver
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        [JsonIgnore]
        public override MessageType MessageType => MessageType.Private;

        /// <summary>
        /// 发送人
        /// </summary>
        public Sender Sender { get; set; } = new();

        #region 扩展方法/属性
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendMessage(MessageChain msg) => await Connect.SendPrivateMsg(SenderQQ, msg);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendMessage(string msg) => await Connect.SendPrivateMsg(SenderQQ, msg);

        /// <summary>
        /// 发送合并转发(go-cqhttp的API，能否使用看onebot实现框架是否提供)
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<ForardMessageInfo> SendForwardMessage(MessageChain msg) => await Connect.SendPrivateForwardMsg(SenderQQ, msg);

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="times">次数</param>
        /// <returns></returns>
        public async Task<bool> Like(int times = 10) => await Connect.SendLike(times);
        #endregion
    }
}
