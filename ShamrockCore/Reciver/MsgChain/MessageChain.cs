﻿using ShamrockCore.Data.Model;

namespace ShamrockCore.Reciver.MsgChain
{
    /// <summary>
    /// 消息链
    /// </summary>
    public class MessageChain : List<Message>
    {
        /// <summary>
        /// 获取文本链
        /// </summary>
        /// <returns></returns>
        public List<string>? GetTextChain()
        {
            try
            {
                return this.Where(t => t.Type == MessageType.Text).Select(t => t.Data.Text).ToList();
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
                return (this.FirstOrDefault(t => t.Type == MessageType.Text)?.Data ?? new())?.Text ?? "";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
