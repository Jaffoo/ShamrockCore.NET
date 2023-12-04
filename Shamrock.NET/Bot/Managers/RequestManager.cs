using Shamrock.Net.Data.Events.Concretes.Request;
using Shamrock.Net.Data.Sessions;
using Shamrock.Net.Data.Shared;
using Shamrock.Net.Utils.Internal;
using System.Threading.Tasks;

namespace Shamrock.Net;

/// <summary>
/// 请求管理器
/// </summary>
public static class RequestManager
{
    /// <summary>
    ///     处理好友申请
    /// </summary>
    /// <param name="requestedEvent"></param>
    /// <param name="handler"></param>
    /// <param name="message"></param>
    public static async Task HandleNewFriendRequestedAsync(NewFriendRequestedEvent requestedEvent,
        NewFriendRequestHandlers handler, string message = "")
    {
        var payload = new
        {
            eventId = requestedEvent.EventId,
            fromId = requestedEvent.FromId,
            groupId = requestedEvent.GroupId,
            operate = handler,
            message
        };

        _ = await HttpEndpoints.NewFriendRequested.PostJsonAsync(payload);
    }

    /// <summary>
    ///     处理新成员入群申请,需要管理员权限
    /// </summary>
    /// <param name="requestedEvent"></param>
    /// <param name="handler"></param>
    /// <param name="message"></param>
    public static async Task HandleNewMemberRequestedAsync(NewMemberRequestedEvent requestedEvent,
        NewMemberRequestHandlers handler, string message = "")
    {
        var payload = new
        {
            eventId = requestedEvent.EventId,
            fromId = requestedEvent.FromId,
            groupId = requestedEvent.GroupId,
            operate = handler,
            message
        };

        _ = await HttpEndpoints.MemberJoinRequested.PostJsonAsync(payload);
    }

    /// <summary>
    ///     处理bot被邀请进群申请
    /// </summary>
    /// <param name="requestedEvent"></param>
    /// <param name="handler"></param>
    /// <param name="message"></param>
    public static async Task HandleNewInvitationRequestedAsync(NewInvitationRequestedEvent requestedEvent,
        NewInvitationRequestHandlers handler, string message)
    {
        var payload = new
        {
            eventId = requestedEvent.EventId,
            fromId = requestedEvent.FromId,
            groupId = requestedEvent.GroupId,
            operate = handler,
            message
        };

        _ = await HttpEndpoints.BotInvited.PostJsonAsync(payload);
    }
}