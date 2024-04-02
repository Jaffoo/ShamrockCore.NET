using System.Net.WebSockets;
using UniBot.Model;
using Websocket.Client;

namespace UniBot
{
    /// <summary>
    /// 主函数
    /// </summary>
    public class UniBot
    {
        #region 全局变量/构造函数
        private readonly WebsocketClient? _client;
        public ConnectConf Conn;
        public UniBot(ConnectConf conf)
        {
            Conn = conf;
        }
        #endregion
    }
}
