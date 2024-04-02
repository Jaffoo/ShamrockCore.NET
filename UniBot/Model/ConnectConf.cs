namespace UniBot.Model
{/// <summary>
 /// 连接初始化配置类
 /// </summary>
    public class ConnectConf
    {

        /// <summary>
        /// host
        /// </summary>
        public string Host { get; set; } = "";

        /// <summary>
        /// websocket服务端口
        /// </summary>
        public int WsPort { get; set; }

        /// <summary>
        /// http服务端口
        /// </summary>
        public int HttpPort { get; set; }

        /// <summary>
        /// 鉴权token
        /// </summary>
        public string Token { get; set; } = "";

        /// <summary>
        /// 启用反向Ws，（此程序作为服务端）
        /// </summary>
        public bool WsReverse { get; set; } = false;

        /// <summary>
        /// httpUrl
        /// </summary>
        public string HttpUrl => "http://" + Host + ":" + HttpPort + "/";

        /// <summary>
        /// wsUrl
        /// </summary>
        public string WsUrl => "ws://" + Host + ":" + WsPort + "/";

        /// <summary>
        /// 反向ws
        /// </summary>
        public string ReverseWsUrl => "ws://0.0.0.0:" + WsPort + "/";

        public Dictionary<string, string> Headers
        {
            get
            {
                var header = new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + Token }
                };
                return header;
            }
        }
    }
}
