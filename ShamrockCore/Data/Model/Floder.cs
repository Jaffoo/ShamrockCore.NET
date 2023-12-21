using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

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
        [JsonProperty("group_id")] public long GroupQQ { get; set; }

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

        #region 扩展属性/方法
        /// <summary>
        /// 获取子文件
        /// </summary>
        public FilesFloders? Files => Api.GetGroupFiles(GroupQQ, FolderId).Result;

        /// <summary>
        /// 删除
        /// </summary>
        public async Task<bool> Delete() =>await Api.DeleteGroupFolder(GroupQQ, FolderId);
        #endregion
    }
}