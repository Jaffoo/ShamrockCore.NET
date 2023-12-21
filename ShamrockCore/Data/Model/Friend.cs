using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 好友
    /// </summary>
    public record Friend
    {
        /// <summary>
        ///     好友的QQ号
        /// </summary>
        [JsonProperty("user_id")]
        public long QQ { get; set; }

        /// <summary>
        ///     好友的备注
        /// </summary>
        [JsonProperty("user_remark")]
        public string RemarkName { get; set; } = "";

        /// <summary>
        ///     好友的昵称
        /// </summary>
        [JsonProperty("user_displayname")]
        public string NickName { get; set; } = "";

        /// <summary>
        ///     好友的年龄
        /// </summary>
        [JsonProperty("age")]
        public string Age { get; set; } = "";

        /// <summary>
        ///     好友的性别
        /// </summary>
        [JsonProperty("gender")]
        public int Gender { get; set; }

        /// <summary>
        ///     分组ID(不是群)
        /// </summary>
        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        /// <summary>
        ///     平台
        /// </summary>
        [JsonProperty("platform")]
        public object Platform { get; set; } = "";

        /// <summary>
        ///     终端类型
        /// </summary>
        [JsonProperty("term_type")]
        public string TermType { get; set; } = "";

        #region 扩展方法/属性
        /// <summary>
        /// 上传到私聊文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<UploadInfo?> UploadFilesByPath(string file, string name) => await Api.UploadPrivateFile(QQ, file, name);

        /// <summary>
        /// 上传到私聊文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<UploadInfo?> UploadFilesByUrl(string url, string name)
        {
            var path = await Api.DownloadFile1(url);
            return path == null ? throw new Exception("数据错误！") : await Api.UploadPrivateFile(QQ, path.File, name);
        }

        /// <summary>
        /// 上传到私聊文件
        /// </summary>
        /// <param name="base64"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<UploadInfo?> UploadFilesByBase64(string base64, string name)
        {
            var path = await Api.DownloadFile1("", base64);
            return path == null ? throw new Exception("数据错误！") : await Api.UploadPrivateFile(QQ, path.File, name);
        }
        #endregion
    }
}