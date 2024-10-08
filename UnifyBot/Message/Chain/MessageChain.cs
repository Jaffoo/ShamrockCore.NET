using Newtonsoft.Json;
using TBC.CommonLib;
using UnifyBot.Api;
using UnifyBot.Model;

namespace UnifyBot.Message.Chain
{
    public class MessageChain : List<MessageBase>
    {
        /// <summary>
        /// 发送群
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="groupQQ">要发送的群</param>
        /// <returns></returns>
        public async Task<long> SendGroup(Bot bot, long groupQQ)
        {
            long groupMsg = await bot.Conn.SendGroupMsg(groupQQ, this);
            return groupMsg;
        }

        /// <summary>
        /// 发送群
        /// </summary>>
        /// <param name="group">要发送的群</param>
        /// <returns></returns>
        public async Task<long> SendGroup(GroupInfo group)
        {
            if (group.Connect.CanConnetBot)
            {
                long groupMsg = await group.Connect.SendGroupMsg(group.GroupQQ, this);
                return groupMsg;
            }
            else throw new Exception("尽量不要手动实例化GroupInfo对象，如果非要这么做，实例化后将此对象中的Connect属性值用Bot.Conn赋值!");
        }

        /// <summary>
        /// 发送好友
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="qq">要发送的qq</param>
        /// <returns></returns>
        public async Task<long> SendPrivate(Bot bot, long qq = 0)
        {
            long privateMsg = await bot.Conn.SendPrivateMsg(qq, this);
            return privateMsg;
        }

        /// <summary>
        /// 发送好友
        /// </summary>
        /// <param name="friend">要发送的qq</param>
        /// <returns></returns>
        public async Task<long> SendPrivate(FriendInfo friend)
        {
            if (friend.Connect.CanConnetBot)
            {
                long privateMsg = await friend.Connect.SendPrivateMsg(friend.QQ, this);
                return privateMsg;
            }
            else throw new Exception("尽量不要手动实例化FriendInfo对象，如果非要这么做，实例化后将此对象中的Connect属性值用Bot.Conn赋值!");
        }

        /// <summary>
        /// 获取文本链
        /// </summary>
        /// <returns></returns>
        public List<string>? GetTextChain()
        {
            try
            {
                return this.Where(t => t.Type == Messages.Text && t.Data != null).Select(t => (string)t.Data!.Text).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取第一条文本
        /// </summary>
        /// <returns></returns>
        public string GetPlainText()
        {
            try
            {
                var firstChain = this.FirstOrDefault(t => t.Type == Messages.Text && t.Data != null);
                if (firstChain == null) return "";
                if (firstChain.Data == null) return "";
                var msg = (string)JsonConvert.SerializeObject(firstChain.Data);
                var text = msg.ToModel<TextMessage.Body>();
                return text.Text;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 两个消息链合并
        /// </summary>
        /// <param name="chain1"></param>
        /// <param name="chain2"></param>
        /// <returns></returns>
        public static MessageChain operator +(MessageChain chain1, MessageChain chain2)
        {
            chain1.AddRange(chain2);
            return chain1;
        }

        /// <summary>
        /// 添加消息进消息链
        /// </summary>
        /// <param name="chain"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static MessageChain operator +(MessageChain chain, MessageBase message)
        {
            chain.Add(message);
            return chain;
        }
    }
}
