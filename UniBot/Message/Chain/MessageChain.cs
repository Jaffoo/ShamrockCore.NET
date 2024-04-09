using UnifyBot.Api;
using UnifyBot.Model;

namespace UnifyBot.Message.Chain
{
    public class MessageChain : List<MessageBase>
    {
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="qq">要发送的qq</param>
        /// <param name="groupQQ">要发送的群</param>
        /// <returns></returns>
        public async Task<(long privateMsg, long groupMsg)> Send(Bot bot, long qq = 0, long groupQQ = 0)
        {
            long privateMsg = 0;
            long groupMsg = 0;
            if (qq > 0) privateMsg = await bot.Conn.SendPrivateMsg(qq, this);
            if (groupQQ > 0) groupMsg = await bot.Conn.SendPrivateMsg(qq, this);
            return (privateMsg, groupMsg);
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
                return (string)firstChain.Data.Txt;
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
