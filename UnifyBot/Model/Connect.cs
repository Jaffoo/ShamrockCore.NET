﻿namespace UnifyBot.Model
{
    /// <summary>
    /// 连接初始化配置类
    /// </summary>
    public class Connect
    {
        /// <summary>
        /// 连接初始化配置类
        /// </summary>
        /// <param name="host">host</param>
        /// <param name="wsPort">websocket端口</param>
        /// <param name="httpPort">http端口</param>
        /// <param name="ssReverse">启用反向ws</param>
        /// <param name="token">token</param>
        public Connect(string host, int wsPort, int httpPort, bool wsReverse = false, string token = "")
        {
            Host = host;
            WsPort = wsPort;
            HttpPort = httpPort;
            Token = token;
            WsReverse = wsReverse;
        }

        /// <summary>
        /// host
        /// </summary>
        public string Host { get; } = "";

        /// <summary>
        /// websocket服务端口
        /// </summary>
        public int WsPort { get; }

        /// <summary>
        /// http服务端口
        /// </summary>
        public int HttpPort { get; }

        /// <summary>
        /// 鉴权token
        /// </summary>
        public string Token { get; } = "";

        /// <summary>
        /// 启用反向Ws，（此程序作为服务端）
        /// </summary>
        public bool WsReverse { get; } = false;

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
                if (string.IsNullOrWhiteSpace(Token))
                    return new();
                var header = new Dictionary<string, string>
                {
                    { "Authorization", "Bearer " + Token }
                };
                return header;
            }
        }
    }
}