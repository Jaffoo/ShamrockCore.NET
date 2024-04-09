using Newtonsoft.Json;
using UnifyBot.Api;
using UnifyBot.Message.Chain;
using static UniBot.Tools.JsonConvertTool;

namespace UnifyBot.Model
{
    /// <summary>
    /// 群成员信息
    /// </summary>
    public class GroupMemberInfo : ModelBase
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// qq
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        [JsonProperty("nickname")]
        public string Nickname { get; set; } = "";

        /// <summary>
        /// 性别
        /// </summary>
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public Genders Sex { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 群名片／备注
        /// </summary>
        public string Card { get; set; } = "";

        /// <summary>
        /// 地区
        /// </summary>
        public string Area { get; set; } = "";

        /// <summary>
        /// 成员等级
        /// </summary>
        public string Level { get; set; } = "";

        /// <summary>
        /// 专属头衔
        /// </summary>
        public string Title { get; set; } = "";

        /// <summary>
        /// 专属头衔
        /// </summary>
        [JsonConverter(typeof(LowercaseStringEnumConverter))]
        public Permissions Role { get; set; }

        /// <summary>
        /// 加入时间
        /// </summary>
        [JsonProperty("join_tile")]
        public long JoinTime { get; set; }

        /// <summary>
        /// 最后发言时间
        /// </summary>
        [JsonProperty("last_send_time")]
        public long LastActive { get; set; }

        /// <summary>
        /// 头衔过期时间
        /// </summary>
        [JsonProperty("title_expire_time")]
        public long TitleExpire { get; set; }

        /// <summary>
        /// 是否允许修改群名片
        /// </summary>
        [JsonProperty("card_changeable")]
        public bool CardChangeable { get; set; }

        /// <summary>
        /// 是否不良记录成员
        /// </summary>
        public bool Unfriendly { get; set; }

        #region 扩展方法/属性
        /// <summary>
        /// 设置群组专属头衔
        /// </summary>
        /// <param name="title">专属头衔，不填或空字符串表示删除专属头衔</param>
        /// <param name="time">专属头衔有效期，单位秒，-1 表示永久</param>
        /// <returns></returns>
        public async Task<bool> SetTitle(string title, int time = -1) => await Connect.SetGroupSpecialTitle(GroupQQ, QQ, title, time);

        /// <summary>
        /// 成员在群的昵称，不填或空字符串表示删除昵称，使用qq昵称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<bool> SetNickname(string name) => await Connect.SetGroupCard(GroupQQ, QQ, name);

        /// <summary>
        /// 任命管理
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SetAdmin() => await Connect.SetGroupAdmin(GroupQQ, QQ);

        /// <summary>
        /// 卸任管理
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RemoveAdmin() => await Connect.SetGroupAdmin(GroupQQ, QQ, false);

        /// <summary>
        /// 禁言
        /// </summary>
        /// <param name="time">时间，单位秒</param>
        /// <returns></returns>
        public async Task<bool> Ban(int time = 30 * 60) => await Connect.SetGroupBan(GroupQQ, QQ, time);

        /// <summary>
        /// 取消禁言
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CacleBan() => await Connect.SetGroupBan(GroupQQ, QQ, 0);

        /// <summary>
        /// 踢出群聊
        /// </summary>
        /// <param name="reject">拒绝此人的加群请求</param>
        /// <returns></returns>
        public async Task<bool> Kick(bool reject = false) => await Connect.SetGroupKick(GroupQQ, QQ, reject);

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="times">次数</param>
        /// <returns></returns>
        public async Task<bool> Like(int times = 10) => await Connect.SendLike(times);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendMessage(MessageChain msg) => await Connect.SendPrivateMsg(QQ, msg);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendMessage(string msg) => await Connect.SendPrivateMsg(QQ, msg);
        #endregion
    }
}
