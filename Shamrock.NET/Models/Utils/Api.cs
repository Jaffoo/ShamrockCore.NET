namespace Shamrock.NET
{
    public static class Api
    {
        #region 账号相关
        /// <summary>
        /// 获取QQ用户信息
        /// </summary>
        public const string GetUserInfo = "/get_login_info";

        /// <summary>
        /// 设置QQ个人资料
        /// </summary>
        public const string SetInfo = "/set_qq_profile";

        /// <summary>
        /// 获取在线机型
        /// </summary>
        public const string GetClient = "/_set_model_show";

        /// <summary>
        /// 设置在线机型
        /// </summary>
        public const string SetClient = "/_set_model_show";

        /// <summary>
        /// 获取当前账号在线客户端列表(未实现)
        /// </summary>
        public const string GetOnlineClient = "/get_online_clients";
        #endregion

        #region 联系人相关
        /// <summary>
        /// 获取陌生人信息
        /// </summary>
        public const string GetStrangerInfo = "/get_stranger_info";

        /// <summary>
        /// 获取好友列表
        /// </summary>
        public const string GetFriendList = "/get_friend_list";

        /// <summary>
        /// 获取单向好友列表(未实现)
        /// </summary>
        public const string GetSingleFriendList = "/get_unidirectional_friend_list";

        /// <summary>
        /// 群信息
        /// </summary>
        public const string GetGroupInfo = "/get_group_info";

        /// <summary>
        /// 群列表
        /// </summary>
        public const string GetGroupList = "/get_group_list";

        /// <summary>
        /// 群成员信息
        /// </summary>
        public const string GetGroupMemberInfo = "/get_group_member_info";

        /// <summary>
        /// 获取群成员列表
        /// </summary>
        public const string GetGroupMemberList = "/get_group_member_list";

        /// <summary>
        /// 获取群荣誉信息
        /// </summary>
        public const string GetGroupHonorInfo = "/get_group_honor_info";

        /// <summary>
        /// 获取群系统消息
        /// </summary>
        public const string GetGroupSystemMsg = "/get_group_system_msg";

        /// <summary>
        /// 获取精华消息列表
        /// </summary>
        public const string GetEssenceMsgList = "/get_essence_msg_list";

        /// <summary>
        /// QQ是否在黑名单内
        /// </summary>
        public const string InBacklist = "/is_blacklist_uin";
        #endregion

        #region 用户相关
        /// <summary>
        /// 删除好友(未实现)
        /// </summary>
        public const string DeleteFirend = "/delete_friend";

        /// <summary>
        /// 删除单向好友(未实现)
        /// </summary>
        public const string DeleteSingleFirend = "/delete_unidirectional_friend";
        #endregion

        #region 消息相关
        /// <summary>
        /// 发送私聊消息
        /// </summary>
        public const string SendPrivateMsg = "/send_private_msg";

        /// <summary>
        /// 发送群聊消息
        /// </summary>
        public const string SendGroupMsg = "/send_group_msg";

        /// <summary>
        /// 发送消息
        /// </summary>
        public const string SendMsg = "/send_msg";

        /// <summary>
        /// 获取消息
        /// </summary>
        public const string GetMsg = "/get_msg";

        /// <summary>
        /// 获取历史消息
        /// </summary>
        public const string GetHistoryMsg = "/get_history_msg";

        /// <summary>
        /// 获取群聊历史消息
        /// </summary>
        public const string GetGroupHistoryMsg = "/get_group_msg_history";

        /// <summary>
        /// 清除本地缓存消息
        /// </summary>
        public const string ClearMsgs = "/clear_msgs";

        /// <summary>
        /// 获取合并转发消息内容
        /// </summary>
        public const string GetForwardMsg = "/get_forward_msg";

        /// <summary>
        /// 发送群聊合并转发
        /// </summary>
        public const string SendGroupForwardMsg = "/send_group_forward_msg";

        /// <summary>
        /// 发送私聊合并转发
        /// </summary>
        public const string SendPrivateForwardMsg = "/send_private_forward_msg";
        #endregion

        #region 资源相关
        /// <summary>
        /// 获取图片(只能获取已缓存的图片)
        /// </summary>
        public const string GetImg = "/get_image";

        /// <summary>
        /// 检查是否可以发送图片(未实现)
        /// </summary>
        public const string CanSendImg = "/can_send_image";

        /// <summary>
        /// 图片OCR(未实现)
        /// </summary>
        public const string OCRimg = "/ocr_image";

        /// <summary>
        /// 获取语音
        /// </summary>
        public const string GetRecord = "/get_record";

        /// <summary>
        /// 检查是否可以发送语音(未实现)
        /// </summary>
        public const string CanSendRecord = "/can_send_record";

        /// <summary>
        /// 获取文件(未实现)
        /// </summary>
        public const string GetFile = "";

        /// <summary>
        /// 获取视频(未实现)
        /// </summary>
        public const string GetVideo = "";

        /// <summary>
        /// 获取缩略图(未实现)
        /// </summary>
        public const string GetThumb = "";
        #endregion

        #region 处理相关
        /// <summary>
        /// 处理加好友请求
        /// </summary>
        public const string SetFirendAddRequest = "/set_friend_add_request";

        /// <summary>
        /// 处理加群请求／邀请
        /// </summary>
        public const string SetGroupAddRequest = "/set_group_add_request";

        /// <summary>
        /// 设置群名
        /// </summary>
        public const string SetGroupName = "/set_group_name";

        /// <summary>
        /// 设置群头像(未实现)
        /// </summary>
        public const string SetGroupPortrait = "/set_group_portrait";

        /// <summary>
        /// 设置群管理员
        /// </summary>
        public const string SetGroupAdmin = "/set_group_admin";

        /// <summary>
        /// 设置群备注(未实现)
        /// </summary>
        public const string SetGroupCard = "/set_group_card";

        /// <summary>
        /// 设置群组专属头衔
        /// </summary>
        public const string SetSpecialTitle = "/set_group_special_title";

        /// <summary>
        /// 群单人禁言
        /// </summary>
        public const string SetBanMember = "/set_group_ban";

        /// <summary>
        /// 群全员禁言
        /// </summary>
        public const string SetBanGroup = "/set_group_whole_ban";

        /// <summary>
        /// 设置精华消息
        /// </summary>
        public const string SetEssenceMsg = "/set_essence_msg";

        /// <summary>
        /// 移出精华消息
        /// </summary>
        public const string DeleteEssenceMsg = "/delete_essence_msg";

        /// <summary>
        /// 群打卡(未实现)
        /// </summary>
        public const string SendGroupSign = "/send_group_sign";

        /// <summary>
        /// 发送群公告
        /// </summary>
        public const string SendGroupNotice = "/send_group_notice";

        /// <summary>
        /// 获取群公告
        /// </summary>
        public const string GetGroupNotice = "/get_group_notice";

        /// <summary>
        /// 群组踢人
        /// </summary>
        public const string SetGroupKick = "/set_group_kick";

        /// <summary>
        /// 退出群组
        /// </summary>
        public const string SetGroupLeave = "/set_group_leave";

        /// <summary>
        /// 群戳一戳
        /// </summary>
        public const string GroupTouch = "/group_touch";

        /// <summary>
        /// 获取被禁言的群成员列表
        /// </summary>
        public const string GetBanList = "/get_prohibited_member_list";
        #endregion

        #region 文件相关
        /// <summary>
        /// 上传私聊文件
        /// </summary>
        public const string UploadPrivateFile = "/upload_private_file";

        /// <summary>
        /// 上传群文件
        /// </summary>
        public const string UploadGroupFile = "/upload_group_file";

        /// <summary>
        /// 删除群文件
        /// </summary>
        public const string DeleteGroupFile = "/delete_group_file";

        /// <summary>
        /// 创建群文件文件夹
        /// </summary>
        public const string CreateGroupFolder = "/create_group_file_folder";

        /// <summary>
        /// 删除群文件文件夹
        /// </summary>
        public const string DeleteGroupFolder = "/delete_group_folder";

        /// <summary>
        /// 获取群文件系统信息
        /// </summary>
        public const string GetGroupFileSystemInfo = "/get_group_file_system_info";

        /// <summary>
        /// 获取群根目录文件列表
        /// </summary>
        public const string GetGroupRootFiles = "/get_group_root_files";

        /// <summary>
        /// 获取群子目录文件列表
        /// </summary>
        public const string GetGroupFileByFolder = "/get_group_files_by_folder";

        /// <summary>
        /// 获取群文件资源链接
        /// </summary>
        public const string GetGroupFileUrl = "/get_group_file_url";
        #endregion

        #region Shamrock相关
        /// <summary>
        /// 切换账号
        /// </summary>
        public const string SwitchAccount = "/switch_account";

        /// <summary>
        /// 上传文件到本地缓存目录(以file格式上传文件，不要使用binary)
        /// </summary>
        public const string UploadFile = "/upload_file";

        /// <summary>
        /// 让Shamrock下载文件到缓存目录(url和base64二选一，url优先)
        /// </summary>
        public const string DownloadFile = "/download_file";

        /// <summary>
        /// 获取手机电池信息
        /// </summary>
        public const string GetDeviceBattery = "/get_device_battery";

        /// <summary>
        /// 获取Shamerock启动时间
        /// </summary>
        public const string GetStartTime = "/get_start_time";

        /// <summary>
        /// 获取Shamrock日志
        /// </summary>
        public const string GetLogs = "/log";

        /// <summary>
        /// 关闭Shamrock
        /// </summary>
        public const string Shut = "/shut";
        #endregion

        #region 其他接口
        /// <summary>
        /// 获取城市ADCode
        /// </summary>
        public const string GetCityCode = "/get_weather_city_code";

        /// <summary>
        /// 获取天气
        /// </summary>
        public const string GetWeather = "/get_weather";

        /// <summary>
        /// [实验] 上传群图片
        /// </summary>
        public const string SendGroupImgMsg = "/upload_group_image";
        #endregion
    }
}
