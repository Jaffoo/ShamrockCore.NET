using Newtonsoft.Json;
using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Reciver.MsgChain;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 群
    /// </summary>
    public record Group
    {
        /// <summary>
        ///     群号
        /// </summary>
        [JsonProperty("group_id")]
        public long Id { get; set; }

        /// <summary>
        ///     群 Uin
        /// </summary>
        [JsonProperty("group_uin")]
        public long UinId { get; set; }

        /// <summary>
        ///     群名称
        /// </summary>
        [JsonProperty("group_name")]
        public string Name { get; set; } = "";

        /// <summary>
        ///     群备注
        /// </summary>
        [JsonProperty("group_remark")]
        public string Remark { get; set; } = "";

        /// <summary>
        ///     群分类
        /// </summary>
        [JsonProperty("class_text")]
        public string Text { get; set; } = "";

        /// <summary>
        ///     是否冻结
        /// </summary>
        [JsonProperty("is_frozen")]
        public bool Frozen { get; set; }

        /// <summary>
        ///     最大成员数
        /// </summary>
        [JsonProperty("max_member_count")]
        public int MaxCount { get; set; }

        /// <summary>
        ///     最大成员数
        /// </summary>
        [JsonProperty("max_member")]
        public int Max { get; set; }

        /// <summary>
        ///     成员数量
        /// </summary>
        [JsonProperty("member_num")]
        public int MemberNum { get; set; }

        /// <summary>
        ///     成员数量
        /// </summary>
        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        /// <summary>
        /// 管理员列表
        /// </summary>
        [JsonProperty("admins")]
        public List<long>? Admins { get; set; } = null;

        #region 群扩展方法/属性
        /// <summary>
        /// 群成员
        /// </summary>
        public List<Member>? Members => Api.GetGroupMemberList(Id).Result;

        /// <summary>
        /// 被禁言列表
        /// </summary>
        public List<Ban>? BanList => Api.GetBanList(Id).Result;

        /// <summary>
        /// 群精华消息
        /// </summary>
        public List<EssenceMsg>? EssenceMsg => Api.GetEssenceMsgs(Id).Result;

        /// <summary>
        /// 群文件系统信息
        /// </summary>
        public FileSystemInfo? FilesSystemInfo => Api.GetGroupFileSystemInfo(Id).Result;

        /// <summary>
        /// 群根目录
        /// </summary>
        public FilesFloders? RootFiles => Api.GetGroupRootFiles(Id).Result;

        /// <summary>
        /// 群荣誉
        /// </summary>
        public Honor? Honor => Api.GetGroupHonorInfo(Id).Result;

        /// <summary>
        /// 群公告
        /// </summary>
        public List<Announcement>? Notice => Api.GetGroupNotice(Id).Result;

        /// <summary>
        /// 群系统消息
        /// </summary>
        public GroupSysMsg? SystemMsg => Api.GetGroupSystemMsg(Id).Result;

        /// <summary>
        /// 全体禁言
        /// </summary>
        public bool AllBan => Api.SetGroupWholeBan(Id).Result;

        /// <summary>
        /// 全体取消禁言
        /// </summary>
        public bool AllBanCancel => Api.SetGroupWholeBan(Id, false).Result;

        /// <summary>
        /// 获取群历史聊天
        /// </summary>
        /// <param name="count">数量</param>
        /// <param name="start">开始</param>
        /// <returns></returns>
        public async Task<MessageChain?> GetHistoryMsg(int count, int start) => await Api.GetGroupMsgHistory(Id, count, start);

        /// <summary>
        /// 群打卡
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Sign() => await Api.SendGroupSign(Id);

        /// <summary>
        /// 发送群公告
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="image">图片,支持base64、http(s)和本地路径</param>
        /// <returns></returns>
        public async Task<bool> SendNotice(string content, string image = "") => await Api.SendGroupNotice(Id, content, image);

        /// <summary>
        /// 退出群聊
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Leave() => await Api.SetGroupLeave(Id);

        /// <summary>
        /// 设置群名
        /// </summary>
        /// <param name="name">群名</param>
        /// <returns></returns>
        public async Task<bool> SetName(string name) => await Api.SetGroupName(Id, name);

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="name">文件夹名称</param>
        /// <returns></returns>
        public async Task<UploadInfo?> CreateFolder(string name) => await Api.CreateGroupFolder(Id, name);

        /// <summary>
        /// 上传到群文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<UploadInfo?> UploadFilesByPath(string file, string name) => await Api.UploadGroupFile(Id, file, name);

        /// <summary>
        /// 上传到群文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<UploadInfo?> UploadFilesByUrl(string url, string name)
        {
            var path = await Api.DownloadFile1(url);
            return path == null ? throw new Exception("数据错误！") : await Api.UploadGroupFile(Id, path.File, name);
        }

        /// <summary>
        /// 上传到群文件
        /// </summary>
        /// <param name="base64"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<UploadInfo?> UploadFilesByBase64(string base64, string name)
        {
            var path = await Api.DownloadFile1("", base64);
            return path == null ? throw new Exception("数据错误！") : await Api.UploadGroupFile(Id, path.File, name);
        }
        #endregion
    }
}