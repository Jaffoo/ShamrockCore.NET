using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Data.Model;
using ShamrockCore.Reciver.MsgChain;

namespace ShamrockCore.Reciver
{
    /// <summary>
    /// 消息管理器
    /// </summary>
    public static class MessageManager
    {
        /// <summary>
        /// 发送私聊，返回消息id
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="message"></param>
        /// <param name="autoEscape"></param>
        /// <returns></returns>
        public static async Task<string> SendPrivateMsg(long qq, object message, bool autoEscape = false) => await Api.SendPrivateMsg(qq, message, autoEscape);

        /// <summary>
        /// 发送私聊，返回消息id
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<string> SendPrivateMsg(this Friend friend, MessageChain message) => await Api.SendPrivateMsg(friend.Id, message);

        /// <summary>
        /// 发送私聊，返回消息id
        /// </summary>
        /// <returns></returns>
        public static async Task<string> SendPrivateMsg(this Friend friend, string message)
        {
            MessageChain chain = new()
            {
                new() { Type = MessageType.Text, Data = new() { Text = message } }
            };
            return await SendPrivateMsg(friend, chain);
        }

        /// <summary>
        /// 发送群聊消息，返回消息id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="message"></param>
        /// <param name="autoEscape"></param>
        /// <returns></returns>
        public static async Task<string> SendGroupMsg(long groupId, object message, bool autoEscape = false) => await Api.SendGroupMsg(groupId, message, autoEscape);

        /// <summary>
        /// 发送群聊消息，返回消息id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="message"></param>
        /// <param name="autoEscape"></param>
        /// <returns></returns>
        public static async Task<string> SendGroupMsg(this Group group, MessageChain message) => await Api.SendGroupMsg(group.Id, message);

        /// <summary>
        /// 发送私聊，返回消息id
        /// </summary>
        /// <returns></returns>
        public static async Task<string> SendGroupMsg(this Group group, string message)
        {
            MessageChain chain = new()
            {
                new() { Type = MessageType.Text, Data = new() { Text = message } }
            };
            return await SendGroupMsg(group, chain);
        }

        /// <summary>
        /// 发送群聊消息，返回消息id
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="message"></param>
        /// <param name="autoEscape"></param>
        /// <returns></returns>
        public static async Task<string> SendMsg(MessageType type, long qq, long groupId, long discussId, object message, bool autoEscape = false) => await Api.SendMsg(type, qq, groupId, discussId, message, autoEscape);

        /// <summary>
        /// 发送群聊合并转发
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static async Task<string> SendGroupForwardMsg(long groupId, object messages) => await Api.SendGroupForwardMsg(groupId, messages);

        /// <summary>
        /// 发送群聊合并转发
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static async Task<string> SendGroupForwardMsg(this Group group, MessageChain messages) => await Api.SendGroupForwardMsg(group.Id, messages);

        /// <summary>
        /// 发送私聊合并转发
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static async Task<string> SendPrivateForwardMsg(long qq, object messages) => await Api.SendPrivateForwardMsg(qq, messages);

        /// <summary>
        /// 发送私聊合并转发
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static async Task<string> SendPrivateForwardMsg(this Friend friend, object messages) => await Api.SendPrivateForwardMsg(friend.Id, messages);
    }
}
