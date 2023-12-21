using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 目录和文件
    /// </summary>
    public record FilesFloders
    {
        /// <summary>
        /// 文件列表
        /// </summary>
        [JsonProperty("files")]
        public List<FileInfo> Files { get; set; } = new();

        /// <summary>
        /// 文件夹列表
        /// </summary>
        [JsonProperty("floders")]
        public List<Floder> Floders { get; set; } = new();
    }

    /// <summary>
    /// 文件
    /// </summary>
    public record FileInfo
    {
        /// <summary>
        /// 文件名
        /// </summary>
        [JsonProperty("file_name")] public string Name { get; set; } = "";

        /// <summary>
        /// 文件标识id
        /// </summary>
        [JsonProperty("file_id")] public string Id { get; set; } = "";

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")] public long GroupQQ { get; set; }

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
        [JsonProperty("md5")] public string MD5 { get; set; } = "";

        /// <summary>
        /// sha
        /// </summary>
        [JsonProperty("sha")] public string Sha { get; set; } = "";

        /// <summary>
        /// sha3可能获取不到
        /// </summary>
        [JsonProperty("sha3")] public string Sha3 { get; set; } = "";

        #region 扩展属性/方法
        /// <summary>
        /// 文件url
        /// </summary>
        public string Url => Api.GetGroupFileUrl(GroupQQ, Id, Busid).Result?.Url ?? "";

        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Delete() => await Api.DeleteGroupFile(GroupQQ, Id, Busid);
        #endregion
    }

    public record FileBaseInfo
    {
        /// <summary>
        /// url
        /// </summary>
        public string Url { get; set; } = "";
    }

    /// <summary>
    /// 图片
    /// </summary>
    public record ImageInfo : FileBaseInfo
    {
        /// <summary>
        /// 大小
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// 图片名
        /// </summary>
        public string FileName { get; set; } = "";
    }

    /// <summary>
    /// 语音信息
    /// </summary>
    public record RecordInfo : FileBaseInfo
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string File { get; set; } = "";
    }

    public record UploadInfo
    {
        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("msg_id")]
        public int MsgId { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public int Busid { get; set; }

        /// <summary>
        /// md5
        /// </summary>
        public string Md5 { get; set; } = "";

        /// <summary>
        /// 文件uuid
        /// </summary>
        [JsonProperty("file_id")]
        public string FileId { get; set; } = "";
    }
}