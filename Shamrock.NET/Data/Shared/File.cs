using Newtonsoft.Json;

namespace Shamrock.Net.Data.Shared
{
    /// <summary>
    /// 文件
    /// </summary>
    public record File
    {
        /// <summary>
        /// 文件名
        /// </summary>
        [JsonProperty("file_name")] public string Name { get; set; }

        /// <summary>
        /// 文件标识id
        /// </summary>
        [JsonProperty("file_id")] public long Id { get; set; }

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")] public long GroupId { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [JsonProperty("busid")] public int Busid { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        [JsonProperty("file_size")] public long Size { get; set; }

        /// <summary>
        /// 上传时间
        /// </summary>
        [JsonProperty("upload_time")] public long UploadTime { get; set; }

        /// <summary>
        /// 过期时间，永久文件恒为0
        /// </summary>
        [JsonProperty("dead_time")] public long DeadTime { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [JsonProperty("modify_time")] public long ModifyTime { get; set; }

        /// <summary>
        /// 下载次数
        /// </summary>
        [JsonProperty("download_times")] public long DownloadCount { get; set; }

        /// <summary>
        /// 上传者ID
        /// </summary>
        [JsonProperty("uploader")] public long UploaderID { get; set; }

        /// <summary>
        /// 上传者名称
        /// </summary>
        [JsonProperty("uploader_name")] public long Uploader { get; set; }

        /// <summary>
        /// md5
        /// </summary>
        [JsonProperty("md5")] public string MD5 { get; set; }

        /// <summary>
        /// sha
        /// </summary>
        [JsonProperty("sha")] public string Sha { get; set; }

        /// <summary>
        /// sha3可能获取不到
        /// </summary>
        [JsonProperty("sha3")] public string Sha3 { get; set; }
    }
}