using Newtonsoft.Json;
using TBC.CommonLib;
using UnifyBot.Model;

namespace UnifyBot.Message
{
    /// <summary>
    /// 位置
    /// </summary>
    public class LocationMessage : MessageBase
    {
        public override Messages Type => Messages.Location;
        public new Body Data => ((string)JsonConvert.SerializeObject(base.Data)).ToModel<Body>();

        public LocationMessage() { }
        /// <summary>
        /// 位置
        /// </summary>
        public LocationMessage(double lat, double lon, string title = "", string content = "")
        {
            base.Data = new Body()
            {
                Lat = lat,
                Lon = lon,
                Title = title,
                Content = content
            };
        }

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
            /// <summary>
            /// 纬度
            /// </summary>
            public double Lat { get; set; }

            /// <summary>
            /// 经度
            /// </summary>
            public double Lon { get; set; }

            /// <summary>
            /// 发送时可选，标题
            /// </summary>
            public string Title { get; set; } = "";

            /// <summary>
            /// 发送时可选，内容描述
            /// </summary>
            public string Content { get; set; } = "";
        }
    }
}
