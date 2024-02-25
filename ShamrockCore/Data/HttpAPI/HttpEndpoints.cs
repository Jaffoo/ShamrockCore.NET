using System.ComponentModel;

namespace ShamrockCore.Data.HttpAPI
{
    /// <summary>
    ///     http请求端点
    /// </summary>
    internal enum HttpEndpoints
    {
        /// <summary>
        /// 获取登录号信息
        /// </summary>
        [Description("get_login_info")] GetLoginInfo,

        /// <summary>
        /// 设置 QQ 个人资料
        /// </summary>
        [Description("set_qq_profile")] SetQQProfile,

        /// <summary>
        /// 获取在线机型
        /// </summary>
        [Description("get_model_show")] GetModelShow,

        /// <summary>
        /// 设置在线机型
        /// </summary>
        [Description("set_model_show")] SetModelShow,

        /// <summary>
        /// 获取当前账号在线客户端列表（未实现）
        /// </summary>
        [Description("get_online_clients")] GetOnlineClients,

        /// <summary>
        /// 获取陌生人信息
        /// </summary>
        [Description("get_stranger_info")] GetStrangerInfo,

        /// <summary>
        /// 获取好友列表
        /// </summary>
        [Description("get_friend_list")] GetFriendList,

        /// <summary>
        /// 获取好友系统消息
        /// </summary>
        [Description("get_friend_system_msg")] GetFriendSysMsg,

        /// <summary>
        /// 获取单向好友列表（未实现）
        /// </summary>
        [Description("get_unidirectional_friend_list")] GetUnidirectionalFriendList,

        /// <summary>
        /// 获取群信息
        /// </summary>
        [Description("get_group_info")] GetGroupInfo,

        /// <summary>
        /// 获取群列表
        /// </summary>
        [Description("get_group_list")] GetGroupList,

        /// <summary>
        /// 获取群成员信息
        /// </summary>
        [Description("get_group_member_info")] GetGroupMemberInfo,

        /// <summary>
        /// 获取群成员列表
        /// </summary>
        [Description("get_group_member_list")] GetGroupMemberList,

        /// <summary>
        /// 获取群荣誉信息
        /// </summary>
        [Description("get_group_honor_info")] GetGroupHonorInfo,

        /// <summary>
        /// 获取群系统消息
        /// </summary>
        [Description("get_group_system_msg")] GetGroupSystemMsg,

        /// <summary>
        /// 获取精华消息列表
        /// </summary>
        [Description("get_essence_msg_list")] GetEssenceMsgList,

        /// <summary>
        /// QQ是否在黑名单内
        /// </summary>
        [Description("is_blacklist_uin")] IsBlacklistUin,

        /// <summary>
        /// 删除好友（未实现）
        /// </summary>
        [Description("delete_friend")] DeleteFriend,

        /// <summary>
        /// 删除单向好友（未实现）
        /// </summary>
        [Description("delete_unidirectional_friend")] DeleteUnidirectionalFriend,

        /// <summary>
        /// 撤回消息
        /// </summary>
        [Description("delete_msg")] DeleteMsg,

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        [Description("send_private_msg")] SendPrivateMsg,

        /// <summary>
        /// 发送群聊消息
        /// </summary>
        [Description("send_group_msg")] SendGroupMsg,

        /// <summary>
        /// 发送消息
        /// </summary>
        [Description("send_msg")] SendMsg,

        /// <summary>
        /// 获取消息
        /// </summary>
        [Description("get_msg")] GetMsg,

        /// <summary>
        /// 获取历史消息
        /// </summary>
        [Description("get_history_msg")] GetHistoryMsg,

        /// <summary>
        /// 获取群聊历史消息
        /// </summary>
        [Description("get_group_msg_history")] GetGroupMsgHistory,

        /// <summary>
        /// 清除本地缓存消息
        /// </summary>
        [Description("clear_msgs")] ClearMsgs,

        /// <summary>
        /// 获取合并转发消息内容
        /// </summary>
        [Description("get_forward_msg")] GetForwardMsg,

        /// <summary>
        /// 发送群聊合并转发
        /// </summary>
        [Description("send_group_forward_msg")] SendGroupForwardMsg,

        /// <summary>
        /// 发送私聊合并转发
        /// </summary>
        [Description("send_private_forward_msg")] SendPrivateForwardMsg,

        /// <summary>
        /// 获取图片(只能获取已缓存的图片)
        /// </summary>
        [Description("get_image")] GetImage,

        /// <summary>
        /// 检查是否可以发送图片（未实现）
        /// </summary>
        [Description("can_send_image")] CanSendImage,

        /// <summary>
        /// 图片 OCR（未实现）
        /// </summary>
        [Description("ocr_image")] OcrImage,

        /// <summary>
        /// 获取语音
        /// </summary>
        [Description("get_record")] GetRecord,

        /// <summary>
        /// 检查是否可以发送语音（未实现）
        /// </summary>
        [Description("can_send_record")] CanSendRecord,

        /// <summary>
        /// 处理加好友请求
        /// </summary>
        [Description("set_friend_add_request")] SetFriendAddRequest,

        /// <summary>
        /// 处理加群请求／邀请
        /// </summary>
        [Description("set_group_add_request")] SetGroupAddRequest,

        /// <summary>
        /// 设置群名（未实现）
        /// </summary>
        [Description("set_group_portrait")] SetGroupPortrait,

        /// <summary>
        /// 设置群头像
        /// </summary>
        [Description("set_group_name")] SetGroupName,

        /// <summary>
        /// 设置群管理员
        /// </summary>
        [Description("set_group_admin")] SetGroupAdmin,

        /// <summary>
        /// 设置群成员名片
        /// </summary>
        [Description("set_group_card")] SetGroupCard,

        /// <summary>
        /// 设置群组专属头衔
        /// </summary>
        [Description("set_group_special_title")] SetGroupSpecialTitle,

        /// <summary>
        /// 群单人禁言
        /// </summary>
        [Description("set_group_ban")] SetGroupBan,

        /// <summary>
        /// 群全员禁言
        /// </summary>
        [Description("set_group_whole_ban")] SetGroupWholeBan,

        /// <summary>
        /// 设置精华消息
        /// </summary>
        [Description("set_essence_msg")] SetEssenceMsg,

        /// <summary>
        /// 移出精华消息
        /// </summary>
        [Description("delete_essence_msg")] DeleteEssenceMsg,

        /// <summary>
        /// 群打卡（未实现）
        /// </summary>
        [Description("send_group_sign")] SendGroupSign,

        /// <summary>
        /// 发送群公告
        /// </summary>
        [Description("_send_group_notice")] SendGroupNotice,

        /// <summary>
        /// 获取群公告
        /// </summary>
        [Description("_get_group_notice")] GetGroupNotice,

        /// <summary>
        /// 群组踢人
        /// </summary>
        [Description("set_group_kick")] SetGroupKick,

        /// <summary>
        /// 退出群组
        /// </summary>
        [Description("set_group_leave")] SetGroupLeave,

        /// <summary>
        /// 群戳一戳
        /// </summary>
        [Description("group_touch")] GroupTouch,

        /// <summary>
        /// 获取被禁言的群成员列表
        /// </summary>
        [Description("get_prohibited_member_list")] GetBanList,

        /// <summary>
        /// 上传私聊文件
        /// </summary>
        [Description("upload_private_file")] UploadPrivateFile,

        /// <summary>
        /// 上传群文件
        /// </summary>
        [Description("upload_groupe_file")] UploadGroupFile,

        /// <summary>
        /// 删除群文件
        /// </summary>
        [Description("delete_group_file")] DeleteGroupFile,

        /// <summary>
        /// 创建群文件文件夹（仅能在根目录创建文件夹）
        /// </summary>
        [Description("create_group_file_folder")] CreateGroupFolder,

        /// <summary>
        /// 删除群文件文件夹
        /// </summary>
        [Description("delete_group_folder")] DeleteGroupFolder,

        /// <summary>
        /// 获取群文件系统信息
        /// </summary>
        [Description("get_group_file_system_info")] GetGroupFileSystemInfo,

        /// <summary>
        /// 获取群根目录文件列表
        /// </summary>
        [Description("get_group_root_files")] GetGroupRootFiles,

        /// <summary>
        /// 获取群子目录文件列表
        /// </summary>
        [Description("get_group_files_by_folder")] GetGroupFiles,

        /// <summary>
        /// 获取群文件资源链接
        /// </summary>
        [Description("get_group_file_url")] GetGroupFileUrl,

        /// <summary>
        /// 切换账号
        /// </summary>
        [Description("switch_account")] SwitchAccount,

        /// <summary>
        /// 上传文件到缓存目录
        /// </summary>
        [Description("upload_file")] UploadFile,

        /// <summary>
        /// 下载文件到缓存目录
        /// </summary>
        [Description("download_file")] DownloadFile,

        /// <summary>
        /// 获取手机电池信息
        /// </summary>
        [Description("get_device_battery")] GetDeviceBattery,

        /// <summary>
        /// 获取Shamrock日志
        /// </summary>
        [Description("log")] Log,

        /// <summary>
        /// 获取Shamrock启动时间
        /// </summary>
        [Description("get_start_time")] GetStartTime,

        /// <summary>
        /// 获取群 @全体成员 剩余次数
        /// </summary>
        [Description("get_group_at_all_remain")]GetAtAllCount,

        /// <summary>
        /// 设置消息底部评论小表情
        /// 目前版本（9.0.15）只在部分群聊进行灰度测试
        /// </summary>
        [Description("set_group_comment_face")] SetGroupCommentFace,

        /// <summary>
        /// 设置群聊备注
        /// </summary>
        [Description("set_group_remark")] SetGroupRemark,

        #region 频道接口
        /// <summary>
        /// 获取频道系统内BOT的资料
        /// </summary>
        [Description("get_guild_service_profile")] GetGuildBotInfo,

        /// <summary>
        /// 获取频道列表
        /// </summary>
        [Description("get_guild_list")] GetGuildList,

        /// <summary>
        /// 通过访客获取频道元数据
        /// </summary>
        [Description("get_guild_meta_by_guest")] GetGuildMetaById,

        /// <summary>
        /// 获取子频道列表
        /// </summary>
        [Description("get_guild_channel_list")] GetGuildChannelList,

        /// <summary>
        /// 获取频道成员列表
        /// </summary>
        [Description("get_guild_member_list")] GetGuildMemberList,

        /// <summary>
        /// 单独获取频道成员资料
        /// </summary>
        [Description("get_guild_member_profile")] GetGuildMemberProfile,

        /// <summary>
        /// 发送信息到子频道
        /// </summary>
        [Description("send_guild_channel_msg")] SendGuildChannelMsg,

        /// <summary>
        /// 获取频道帖子广场帖子
        /// </summary>
        [Description("get_guild_feeds")] GetGuildFeeds,

        /// <summary>
        /// 获取频道角色列表
        /// </summary>
        [Description("get_guild_roles")] GetGuildRoles,

        /// <summary>
        /// 删除频道角色
        /// </summary>
        [Description("delete_guild_role")] DeleteGuildRole,

        /// <summary>
        /// 设置用户在频道中的角色
        /// </summary>
        [Description("set_guild_member_role")] SetGuildMemberRole,
        #endregion
    }
}