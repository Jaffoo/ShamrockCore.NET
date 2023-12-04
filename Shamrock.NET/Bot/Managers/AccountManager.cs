﻿using Manganese.Text;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mirai.Net;

/// <summary>
///     账号管理器
/// </summary>
public static class AccountManager
{
    #region Private helpers

    private static async Task<IEnumerable<T>> GetCollectionAsync<T>(HttpEndpoints endpoints, object extra = null)
    {
        var raw = await endpoints.GetAsync(extra);
        raw = raw.Fetch("data");

        return raw.ToJArray().Select(x => x.ToObject<T>());
    }

    private static async Task<Profile> GetProfileAsync(HttpEndpoints endpoints, object extra = null)
    {
        var raw = await endpoints.GetAsync(extra);

        return JsonConvert.DeserializeObject<Profile>(raw);
    }

    #endregion

    #region Exposed

    /// <summary>
    ///     获取bot账号的好友列表
    /// </summary>
    public static async Task<IEnumerable<Friend>> GetFriendsAsync()
    {
        return await GetCollectionAsync<Friend>(HttpEndpoints.GetFriendList);
    }

    /// <summary>
    ///     获取bot账号的QQ群列表
    /// </summary>
    public static async Task<IEnumerable<Group>> GetGroupsAsync()
    {
        return await GetCollectionAsync<Group>(HttpEndpoints.GetGroupList);
    }

    /// <summary>
    ///     获取某群的全部群成员
    /// </summary>
    public static async Task<IEnumerable<Member>> GetGroupMembersAsync(string groupId)
    {
        return await GetCollectionAsync<Member>(HttpEndpoints.GetGroupMemberList, new
        {
            group_id = groupId
        });
    }

    /// <summary>
    ///     获取某群的全部群成员
    /// </summary>
    public static async Task<IEnumerable<Member>> GetGroupMembersAsync(this Group target)
    {
        return await GetGroupMembersAsync(target.Id);
    }

    /// <summary>
    ///     删除好友（未实现）
    /// </summary>
    /// <param name="friendId"></param>
    public static async Task DeleteFriendAsync(string friendId)
    {
        _ = await HttpEndpoints.DeleteFriend.PostJsonAsync(new
        {
            target = friendId
        });
    }

    /// <summary>
    ///     删除好友（未实现）
    /// </summary>
    /// <param name="friend"></param>
    public static async Task DeleteFriendAsync(this Friend friend)
    {
        await DeleteFriendAsync(friend.Id);
    }

    /// <summary>
    ///     获取bot资料
    /// </summary>
    public static async Task<Profile> GetBotProfileAsync()
    {
        return await GetProfileAsync(HttpEndpoints.GetLoginInfo);
    }

    /// <summary>
    ///     获取陌生人资料
    /// </summary>
    public static async Task<Profile> GetStrangerProfileAsync(string qq)
    {
        return await GetProfileAsync(HttpEndpoints.GetStrangerInfo, new
        {
            user_id = qq
        });
    }

    /// <summary>
    ///     获取好友资料
    /// </summary>
    public static async Task<Profile> GetFriendProfileAsync(string friendId)
    {
        return await GetProfileAsync(HttpEndpoints.GetStrangerInfo, new
        {
            target = friendId
        });
    }

    /// <summary>
    ///     获取好友资料
    /// </summary>
    public static async Task<Profile> GetFriendProfileAsync(this Friend target)
    {
        return await GetFriendProfileAsync(target.Id);
    }

    /// <summary>
    ///     获取群员资料
    /// </summary>
    /// <param name="id"></param>
    /// <param name="memberId">群号</param>
    public static async Task<Profile> GetMemberProfileAsync(string id, string memberId)
    {
        return await GetProfileAsync(HttpEndpoints.GetGroupMemberInfo, new
        {
            target = memberId,
            memberId = id
        });
    }

    /// <summary>
    ///     获取群员资料
    /// </summary>
    public static async Task<Profile> GetMemberProfileAsync(this Member member)
    {
        return await GetMemberProfileAsync(member.Id, member.Group.Id);
    }
    #endregion
}