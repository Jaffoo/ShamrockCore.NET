using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Data.Model;
using ShamrockCore.Reciver.MsgChain;
using ShamrockCore.Reciver.Receivers;

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
        public static async Task<string> SendPrivateMsgAsync(long qq, object message, bool autoEscape = false) => await Api.SendPrivateMsgAsync(qq, message, autoEscape);

        /// <summary>
        /// 发送私聊，返回消息id
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<string> SendMessageAsync(this Friend friend, MessageChain message) => await Api.SendPrivateMsgAsync(friend.QQ, message);

        /// <summary>
        /// 发送私聊，返回消息id
        /// </summary>
        /// <returns></returns>
        public static async Task<string> SendMessageAsync(this Friend friend, string message)
        {
            MessageChain chain = new()
            {
                new TextMessage() { Type = MessageType.Text, Data = new() { Text = message } }
            };
            return await SendMessageAsync(friend, chain);
        }

        /// <summary>
        /// 发送私聊，返回消息id
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<string> SendMessageAsync(this FriendReceiver friend, MessageChain message) => await Api.SendPrivateMsgAsync(friend.Sender!.UserId, message);

        /// <summary>
        /// 发送私聊，返回消息id
        /// </summary>
        /// <returns></returns>
        public static async Task<string> SendMessageAsync(this FriendReceiver friend, string message)
        {
            MessageChain chain = new()
            {
                new TextMessage() { Data = new() { Text = message } },
            };
            return await SendMessageAsync(friend, chain);
        }

        /// <summary>
        /// 发送群聊消息，返回消息id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="message"></param>
        /// <param name="autoEscape"></param>
        /// <returns></returns>
        public static async Task<string> SendGroupMsgAsync(long groupId, object message, bool autoEscape = false) => await Api.SendGroupMsgAsync(groupId, message, autoEscape);

        /// <summary>
        /// 发送群聊消息，返回消息id
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="message"></param>
        /// <param name="autoEscape"></param>
        /// <returns></returns>
        public static async Task<string> SendMessageAsync(this Group group, MessageChain message) => await Api.SendGroupMsgAsync(group.GroupQQ, message);

        /// <summary>
        /// 发送私聊，返回消息id
        /// </summary>
        /// <returns></returns>
        public static async Task<string> SendMessageAsync(this Group group, string message)
        {
            MessageChain chain = new()
            {
                new TextMessage() { Type = MessageType.Text, Data = new() { Text = message } }
            };
            return await SendMessageAsync(group, chain);
        }

        /// <summary>
        /// 发送私聊，返回消息id
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<string> SendMessageAsync(this GroupReceiver group, MessageChain message) => await Api.SendGroupMsgAsync(group.GroupId, message);

        /// <summary>
        /// 发送私聊，返回消息id
        /// </summary>
        /// <returns></returns>
        public static async Task<string> SendMessageAsync(this GroupReceiver group, string message)
        {
            MessageChain chain = new()
            {
                new TextMessage() { Type = MessageType.Text, Data = new() { Text = message } }
            };
            return await SendMessageAsync(group, chain);
        }

        /// <summary>
        /// 发送消息，返回消息id
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="message"></param>
        /// <param name="autoEscape"></param>
        /// <returns></returns>
        public static async Task<string> SendMsgAsync(MessageType type, long qq, long groupId, long discussId, object message, bool autoEscape = false) => await Api.SendMsgAsync(type, qq, groupId, discussId, message, autoEscape);

        /// <summary>
        /// 发送群聊合并转发
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static async Task<string> SendGroupForwardMsgAsync(long groupId, object messages) => await Api.SendGroupForwardMsgAsync(groupId, messages);

        /// <summary>
        /// 发送群聊合并转发
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static async Task<string> SendForwardMsgAsync(this Group group, MessageChain messages) => await Api.SendGroupForwardMsgAsync(group.GroupQQ, messages);

        /// <summary>
        /// 发送群聊合并转发
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static async Task<string> SendForwardMsgAsync(this GroupReceiver group, MessageChain messages) => await Api.SendGroupForwardMsgAsync(group.GroupId, messages);

        /// <summary>
        /// 发送私聊合并转发
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static async Task<string> SendPrivateForwardMsgAsync(long qq, object messages) => await Api.SendPrivateForwardMsgAsync(qq, messages);

        /// <summary>
        /// 发送私聊合并转发
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static async Task<string> SendForwardMsgAsync(this Friend friend, object messages) => await Api.SendPrivateForwardMsgAsync(friend.QQ, messages);

        /// <summary>
        /// 发送私聊合并转发
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static async Task<string> SendForwardMsgAsync(this FriendReceiver friend, object messages) => await Api.SendPrivateForwardMsgAsync(friend.Sender?.UserId ?? 0, messages);
    }
}
