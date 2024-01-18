using Newtonsoft.Json;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Receiver.Events
{
    /// <summary>
    /// 群文件上传
    /// </summary>
    public class GroupFileUploadEvent : EventBase
    {
        /// <summary>
        /// 上传者 QQ
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        /// 群qq
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupQQ { get; set; }

        /// <summary>
        /// 群文件信息
        /// </summary>
        [JsonProperty("flie")]
        public GroupFileUpload GroupFile { get; set; } = new();

        /// <summary>
        /// 事件类型
        /// </summary>
        [JsonIgnore]
        public override PostEventType EventType { get; set; } = PostEventType.GroupUpload;
    }


    /// <summary>
    /// 文件上传事件用
    /// </summary>
    public record FileUpload
    {

        /// <summary>
        /// url
        /// </summary>
        public string Url { get; set; } = "";

        /// <summary>
        /// 文件名
        /// </summary>
        [JsonProperty("file_name")] public string Name { get; set; } = "";

        /// <summary>
        /// 文件标识id
        /// </summary>
        [JsonProperty("file_id")] public string Id { get; set; } = "";

        /// <summary>
        /// 文件大小
        /// </summary>
        [JsonProperty("file_size")] public long Size { get; set; }
    }

    /// <summary>
    /// 群文件上传事件用
    /// </summary>
    public record GroupFileUpload : FileUpload
    {
        /// <summary>
        /// 文件类型
        /// </summary>
        [JsonProperty("busid")] public int Busid { get; set; }
    }
}
