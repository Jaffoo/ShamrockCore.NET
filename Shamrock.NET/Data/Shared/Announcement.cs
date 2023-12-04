using Newtonsoft.Json;
using System.Collections.Generic;

namespace Shamrock.Net.Data.Shared
{
    /// <summary>
    /// 群公告
    /// </summary>
    public record Announcement
    {
        /// <summary>
        /// 公告发表者
        /// </summary>
        [JsonProperty("sender_id")]
        public long Sender { get; set; }

        /// <summary>
        /// 公告发布时间
        /// </summary>
        [JsonProperty("publish_time")]
        public long SenderTime { get; set; }

        /// <summary>
        /// 公告内容
        /// </summary>
        [JsonProperty("message")]
        public AnnouncementMsg Message { get; set; }
    }

    /// <summary>
    /// 公告内容
    /// </summary>
    public record AnnouncementMsg
    {
        /// <summary>
        /// 公告内容
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// 公告图片
        /// </summary>
        [JsonProperty("images")]
        public List<AnnouncementImg> Images { get; set; }
    }

    /// <summary>
    /// 公告图片
    /// </summary>
    public record AnnouncementImg
    {
        /// <summary>
        /// 图片高度
        /// </summary>
        [JsonProperty("height")]
        public string Height { get; set; }

        /// <summary>
        /// 图片宽度
        /// </summary>
        [JsonProperty("width")]
        public string Width { get; set; }

        /// <summary>
        /// 图片ID，可用https://gdynamic.qpic.cn/gdynamic/{id}/628获取
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
