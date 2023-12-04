using Mirai.Net.Bot.Managers;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Shared;

/// <summary>
/// 好友
/// </summary>
public record Friend
{
    /// <summary>
    /// 好友的资料
    /// </summary>
    [JsonIgnore] public Profile FriendProfile => this.GetFriendProfileAsync().GetAwaiter().GetResult();

    /// <summary>
    ///     好友的QQ号
    /// </summary>
    [JsonProperty("user_id")]
    public string Id { get; set; }

    /// <summary>
    ///     好友的昵称
    /// </summary>
    [JsonProperty("nickname")]
    public string NickName { get; set; }

    /// <summary>
    ///     好友的年龄
    /// </summary>
    [JsonProperty("age")]
    public string Age { get; set; }

    /// <summary>
    ///     好友的性别
    /// </summary>
    [JsonProperty("sex")]
    public string Sex { get; set; }

    /// <summary>
    ///     扩展字段
    /// </summary>
    [JsonProperty("ext")]
    public object Ext { get; set; }
}