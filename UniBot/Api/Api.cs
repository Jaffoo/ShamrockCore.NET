using System.Net;
using TBC.CommonLib;
using UniBot.Message;
using UniBot.Model;

namespace ShamrockCore.Data.HttpAPI
{
    public class Api
    {
        private readonly ConnectConf _conf;
        public Api(ConnectConf conf)
        {
            _conf = conf;
        }

        public async Task<long> SendPrivateMsg(long qq, MessageChain msg)
        {
            try
            {
                var url = _conf.HttpUrl + HttpEndpoints.SendPrivateMsg.GetDescription();
                var data = new
                {
                    user_id = qq,
                    message = msg
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), _conf.Headers);
                if (res == null) return 0;
                if (res.Status == "failed") throw new Exception(res.Message);
                var resulst = res.Data;
            }
            catch (Exception)
            {

                throw;
            }
        }
        ///// <summary>
        ///// 发送私聊消息
        ///// </summary>
        //[Description("send_private_msg")] SendPrivateMsg,

        ///// <summary>
        ///// 发送群消息
        ///// </summary>
        //[Description("send_group_msg")] SendGroupMsg,

        ///// <summary>
        ///// 发送消息
        ///// </summary>
        //[Description("send_msg")] SendMsg,

        ///// <summary>
        ///// 撤回消息
        ///// </summary>
        //[Description("delete_msg")] DeleteMsg,

        ///// <summary>
        ///// 获取消息
        ///// </summary>
        //[Description("get_msg")] GetMsg,

        ///// <summary>
        ///// 获取合并转发消息
        ///// </summary>
        //[Description("get_forward_msg")] GetForwardMsg,

        ///// <summary>
        ///// 发送好友赞
        ///// </summary>
        //[Description("send_like")] SendLike,

        ///// <summary>
        ///// 群组踢人
        ///// </summary>
        //[Description("set_group_kick")] SetGroupKick,

        ///// <summary>
        ///// 群组单人禁言
        ///// </summary>
        //[Description("set_group_ban")] SetGroupBan,

        ///// <summary>
        ///// 群组匿名用户禁言
        ///// </summary>
        //[Description("set_group_anonymous_ban")] SetGroupAnonymousBan,

        ///// <summary>
        ///// 群组全员禁言
        ///// </summary>
        //[Description("set_group_whole_ban")] SetGroupWholeBan,

        ///// <summary>
        ///// 群组设置管理员
        ///// </summary>
        //[Description("set_group_admin")] SetGroupAdmin,

        ///// <summary>
        ///// 群组匿名
        ///// </summary>
        //[Description("set_group_anonymous")] SetGroupAnonymous,

        ///// <summary>
        ///// 设置群名片（群备注）
        ///// </summary>
        //[Description("set_group_card")] SetGroupCard,

        ///// <summary>
        ///// 设置群名
        ///// </summary>
        //[Description("set_group_name")] SetGroupName,

        ///// <summary>
        ///// 退出群组
        ///// </summary>
        //[Description("set_group_leave")] SetGroupLeave,

        ///// <summary>
        ///// 设置群组专属头衔
        ///// </summary>
        //[Description("set_group_special_title")] SetGroupSpecialTitle,

        ///// <summary>
        ///// 处理加好友请求
        ///// </summary>
        //[Description("set_friend_add_request")] SetFriendAddRequest,

        ///// <summary>
        ///// 处理加群请求／邀请
        ///// </summary>
        //[Description("set_group_add_request")] SetGroupAddRequest,

        ///// <summary>
        ///// 获取登录号信息
        ///// </summary>
        //[Description("get_login_info")] GetLoginInfo,

        ///// <summary>
        ///// 获取陌生人信息
        ///// </summary>
        //[Description("get_stranger_info")] GetStrangerInfo,

        ///// <summary>
        ///// 获取好友列表
        ///// </summary>
        //[Description("get_friend_list")] GetFriendList,

        ///// <summary>
        ///// 获取群信息
        ///// </summary>
        //[Description("get_group_info")] GetGroupInfo,

        ///// <summary>
        ///// 获取群列表
        ///// </summary>
        //[Description("get_group_list")] GetGroupList,

        ///// <summary>
        ///// 获取群成员信息
        ///// </summary>
        //[Description("get_group_member_info")] GetGroupMemberInfo,

        ///// <summary>
        ///// 获取群成员列表
        ///// </summary>
        //[Description("get_group_member_list")] GetGroupMemberList,

        ///// <summary>
        ///// 获取群荣誉信息
        ///// </summary>
        //[Description("get_group_honor_info")] GetGroupHonorInfo,

        ///// <summary>
        ///// 获取 Cookies
        ///// </summary>
        //[Description("get_cookies")] GetCookies,

        ///// <summary>
        ///// 获取 CSRF Token
        ///// </summary>
        //[Description("get_csrf_token")] GetCsrfToken,

        ///// <summary>
        ///// 获取 QQ 相关接口凭证
        ///// </summary>
        //[Description("get_credentials")] GetCredentials,

        ///// <summary>
        ///// 获取语音
        ///// 要使用此接口，通常需要安装 ffmpeg
        ///// </summary>
        //[Description("get_record")] GetRecord,

        ///// <summary>
        ///// 获取图片
        ///// </summary>
        //[Description("get_image")] GetImage,

        ///// <summary>
        ///// 检查是否可以发送图片
        ///// </summary>
        //[Description("can_send_image")] CanSendImage,

        ///// <summary>
        ///// 检查是否可以发送语音
        ///// </summary>
        //[Description("can_send_record")] CanSendRecord,

        ///// <summary>
        ///// 获取运行状态
        ///// </summary>
        //[Description("get_status")] GetStatus,

        ///// <summary>
        ///// 获取版本信息
        ///// </summary>
        //[Description("get_version_info")] GetVersion,

        ///// <summary>
        ///// 重启 OneBot 实现
        ///// </summary>
        //[Description("set_restart")] Restart,

        ///// <summary>
        ///// 清理缓存
        ///// </summary>
        //[Description("clean_cache")] CleanCache,
    }
}