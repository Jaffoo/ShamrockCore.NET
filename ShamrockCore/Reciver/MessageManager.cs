using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Data.Model;

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
        public static async Task<string> SendPrivateMsg(string qq, object message, bool autoEscape = false) => await Api.SendPrivateMsg(qq, message, autoEscape);

        /// <summary>
        /// 发送群聊消息，返回消息id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="message"></param>
        /// <param name="autoEscape"></param>
        /// <returns></returns>
        public static async Task<string> SendGroupMsg(string groupId, object message, bool autoEscape = false) => await Api.SendGroupMsg(groupId, message, autoEscape);

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
        public static async Task<string> SendGroupForwardMsg(string groupId, object messages) => await Api.SendGroupForwardMsg(groupId, messages);

        /// <summary>
        /// 发送私聊合并转发
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static async Task<string> SendPrivateForwardMsg(string qq, object messages) => await Api.SendPrivateForwardMsg(qq, messages);
    }
}
