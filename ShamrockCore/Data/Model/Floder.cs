using Newtonsoft.Json;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 文件夹
    /// </summary>
    public record Floder
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("group_id")] public long GroupId { get; set; }

        /// <summary>
        /// 文件夹ID
        /// </summary>
        [JsonProperty("folder_id")] public string FolderId { get; set; } = "";

        /// <summary>
        /// 文件夹
        /// </summary>
        [JsonProperty("folder_name")] public string Folder { get; set; } = "";

        /// <summary>
        /// 创建时间
        /// </summary>
        [JsonProperty("create_time")] public long CreateTime { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        [JsonProperty("creator")] public string CreatorId { get; set; } = "";

        /// <summary>
        /// 创建者
        /// </summary>
        [JsonProperty("creator_name")] public string Creator { get; set; } = "";

        /// <summary>
        /// 子文件数量
        /// </summary>
        [JsonProperty("total_file_count")] public int FileCount { get; set; }
    }
}