using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

namespace UniBot.Receiver.MessageReceiver
{
    public class GroupReceiver : PrivateReceiver
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 匿名信息，如果不是匿名消息则为 null
        /// </summary>
        public object? Anonymous { get; set; }

        public async Task<bool> SendMessage()
        {
            base.ConnectConf.SendPrivateMsg();
        }
    }
}
