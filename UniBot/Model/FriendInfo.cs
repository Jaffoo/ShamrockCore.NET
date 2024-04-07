﻿using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using UniBot.Message.Chain;

namespace UniBot.Model
{
    /// <summary>
    /// 好友信息
    /// </summary>
    public class FriendInfo : ModelBase
    {
        /// <summary>
        /// qq
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; } = "";

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; } = "";

        #region 扩展方法/属性
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendMessage(MessageChain msg) => await ConnectConf.SendPrivateMsg(QQ, msg);

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task<long> SendMessage(string msg) => await ConnectConf.SendPrivateMsg(QQ, msg);

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="times">次数</param>
        /// <returns></returns>
        public async Task<bool> Like(int times = 10) => await ConnectConf.SendLike(times);
        #endregion
    }
}
