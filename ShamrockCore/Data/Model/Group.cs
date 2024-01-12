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
        public long GroupQQ { get; set; }

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
        [JsonIgnore]
        public IEnumerable<Member>? Members
        {
            get
            {
                _members ??= new(() => Api.GetGroupMemberList(GroupQQ).Result);
                return _members.Value;
            }
        }
        [JsonIgnore] private Lazy<IEnumerable<Member>?>? _members;

        /// <summary>
        /// 被禁言列表
        /// </summary>
        [JsonIgnore]
        public IEnumerable<Ban>? BanList
        {
            get
            {
                _banList ??= new(() => Api.GetBanList(GroupQQ).Result);
                return _banList.Value;
            }
        }
        [JsonIgnore] private Lazy<IEnumerable<Ban>?>? _banList;

        /// <summary>
        /// 群精华消息
        /// </summary>
        [JsonIgnore]
        public IEnumerable<EssenceMsg>? EssenceMsg
        {
            get
            {
                _essenceMsg ??= new(() => Api.GetEssenceMsgs(GroupQQ).Result);
                return _essenceMsg.Value;
            }
        }
        [JsonIgnore] private Lazy<IEnumerable<EssenceMsg>?>? _essenceMsg;

        /// <summary>
        /// 群文件系统信息
        /// </summary>
        [JsonIgnore]
        public FileSystemInfo? FilesSystemInfo
        {
            get
            {
                _filesSystemInfo ??= new(() => Api.GetGroupFileSystemInfo(GroupQQ).Result);
                return _filesSystemInfo.Value;
            }
        }
        [JsonIgnore] private Lazy<FileSystemInfo?>? _filesSystemInfo;

        /// <summary>
        /// 群根目录
        /// </summary>
        [JsonIgnore]
        public FilesFloders? RootFiles
        {
            get
            {
                _rootFiles ??= new(() => Api.GetGroupRootFiles(GroupQQ).Result);
                return _rootFiles.Value;
            }
        }
        [JsonIgnore] private Lazy<FilesFloders?>? _rootFiles;

        /// <summary>
        /// 群荣誉
        /// </summary>
        [JsonIgnore]
        public Honor? Honor
        {
            get
            {
                _honor ??= new(() => Api.GetGroupHonorInfo(GroupQQ).Result);
                return _honor.Value;
            }
        }
        [JsonIgnore] private Lazy<Honor?>? _honor;

        /// <summary>
        /// 群公告
        /// </summary>
        [JsonIgnore]
        public IEnumerable<Announcement>? Notice
        {
            get
            {
                _notice ??= new(() => Api.GetGroupNotice(GroupQQ).Result);
                return _notice.Value;
            }
        }
        [JsonIgnore] private Lazy<IEnumerable<Announcement>?>? _notice;

        /// <summary>
        /// 群系统消息
        /// </summary>
        [JsonIgnore]
        public GroupSysMsg? SystemMsg
        {
            get
            {
                _systemMsg ??= new(() => Api.GetGroupSystemMsg(GroupQQ).Result);
                return _systemMsg.Value;
            }
        }
        [JsonIgnore] private Lazy<GroupSysMsg?>? _systemMsg;

        /// <summary>
        /// 全体禁言
        /// </summary>
        public async Task<bool> AllBan() => await Api.SetGroupWholeBan(GroupQQ);

        /// <summary>
        /// 全体取消禁言
        /// </summary>
        public async Task<bool> AllBanCancel() => await Api.SetGroupWholeBan(GroupQQ, false);

        /// <summary>
        /// 获取群历史聊天
        /// </summary>
        /// <param name="count">数量</param>
        /// <param name="start">开始</param>
        /// <returns></returns>
        public async Task<MessageChain?> GetHistoryMsg(int count, int start) => await Api.GetGroupMsgHistory(GroupQQ, count, start);

        /// <summary>
        /// 群打卡
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Sign() => await Api.SendGroupSign(GroupQQ);

        /// <summary>
        /// 发送群公告
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="image">图片,支持base64、http(s)和本地路径</param>
        /// <returns></returns>
        public async Task<bool> SendNotice(string content, string? image = null) => await Api.SendGroupNotice(GroupQQ, content, image);

        /// <summary>
        /// 退出群聊
        /// </summary>
        /// <returns></returns>
        public async Task<bool> Leave() => await Api.SetGroupLeave(GroupQQ);

        /// <summary>
        /// 设置群名
        /// </summary>
        /// <param name="name">群名</param>
        /// <returns></returns>
        public async Task<bool> SetName(string name) => await Api.SetGroupName(GroupQQ, name);

        /// <summary>
        /// 创建根目录文件夹
        /// </summary>
        /// <param name="name">文件夹名称</param>
        /// <returns></returns>
        public async Task<UploadInfo?> CreateFolder(string name) => await Api.CreateGroupFolder(GroupQQ, name);

        /// <summary>
        /// 上传到群文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<UploadInfo?> UploadFilesByPath(string file, string name) => await Api.UploadGroupFile(GroupQQ, file, name);

        /// <summary>
        /// 上传到群文件
        /// </summary>
        /// <param name="url"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<UploadInfo?> UploadFilesByUrl(string url, string name)
        {
            var path = await Api.DownloadFile1(url);
            return path == null ? throw new Exception("数据错误！") : await Api.UploadGroupFile(GroupQQ, path.File, name);
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
            return path == null ? throw new Exception("数据错误！") : await Api.UploadGroupFile(GroupQQ, path.File, name);
        }
        #endregion
    }
}