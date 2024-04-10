using Newtonsoft.Json.Linq;
using TBC.CommonLib;
using UnifyBot.Message;
using UnifyBot.Message.Chain;
using UnifyBot.Model;
using UnifyBot.Receiver;
using UnifyBot.Utils;

namespace UnifyBot.Api
{
    internal static class Api
    {
        #region onebot11
        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <returns></returns>
        public static async Task<long> SendPrivateMsg(this Connect conf, long qq, MessageChain msg)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SendPrivateMsg.GetDescription();
                var data = new
                {
                    user_id = qq,
                    message = msg
                };
                var res = await Tools.PostAsync<ApiResult<MessageInfoBase>>(url, data.ToLowJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data.MessageId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <returns></returns>
        public static async Task<long> SendPrivateMsg(this Connect conf, long qq, string msg)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SendPrivateMsg.GetDescription();
                var data = new
                {
                    user_id = qq,
                    message = new MessageChain() { new TextMessage(msg) }
                };
                var res = await Tools.PostAsync<ApiResult<MessageInfoBase>>(url, data.ToLowJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data.MessageId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 发送群聊消息
        /// </summary>
        /// <returns></returns>
        public static async Task<long> SendGroupMsg(this Connect conf, long qq, MessageChain msg)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SendGroupMsg.GetDescription();
                var data = new
                {
                    group_id = qq,
                    message = msg
                };
                var res = await Tools.PostAsync<ApiResult<MessageInfoBase>>(url, data.ToLowJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data.MessageId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 发送群聊消息
        /// </summary>
        /// <returns></returns>
        public static async Task<long> SendGroupMsg(this Connect conf, long qq, string msg)
        {
            try
            {
                var message = new MessageChain() { new TextMessage(msg) };
                var url = conf.HttpUrl + HttpEndpoints.SendGroupMsg.GetDescription();
                var data = new
                {
                    group_id = qq,
                    message
                };
                var res = await Tools.PostAsync<ApiResult<MessageInfoBase>>(url, data.ToLowJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data.MessageId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <returns></returns>
        public static async Task<long> SendMessage(this MessageReceiverBase mrb, MessageChain msg, long qq = 0, long groupQQ = 0, string type = "")
        {
            try
            {
                var conf = mrb.Connect!;
                var url = conf.HttpUrl + HttpEndpoints.SendMsg.GetDescription();
                var data = new
                {
                    message_type = type,
                    user_id = qq,
                    group_id = groupQQ,
                    message = msg
                };
                var res = await Tools.PostAsync<ApiResult<MessageInfoBase>>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data.MessageId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 撤回消息
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> MessageRecal(this Connect conf, long msgId)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.DeleteMsg.GetDescription();
                var data = new
                {
                    message_id = msgId
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取消息
        /// </summary>
        /// <returns></returns>
        public static async Task<MessageInfo> GetMsg(this Connect conf, long msgId)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetMsg.GetDescription();
                var data = new
                {
                    message_id = msgId
                };
                var res = await Tools.PostAsync<ApiResult<MessageInfo>>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取合并转发消息
        /// </summary>
        /// <returns></returns>
        public static async Task<MessageChain> GetForwardMsg(this Connect conf, long id)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetForwardMsg.GetDescription();
                var data = new
                {
                    id
                };
                var res = await Tools.PostAsync<ApiResult<MessageChain>>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 给好友点赞
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SendLike(this Connect conf, long qq, int times = 10)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SendLike.GetDescription();
                var data = new
                {
                    user_id = qq,
                    times
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 群组踢人
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SetGroupKick(this Connect conf, long groupQQ, long qq, bool reject = false)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SetGroupKick.GetDescription();
                var data = new
                {
                    user_id = qq,
                    group_id = groupQQ,
                    reject_add_request = reject
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 群组单人禁言
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SetGroupBan(this Connect conf, long groupQQ, long qq, int duration = 30 * 60)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SetGroupBan.GetDescription();
                var data = new
                {
                    user_id = qq,
                    group_id = groupQQ,
                    duration
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 群组匿名用户禁言
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SetGroupAnonymousBan(this Connect conf, long groupQQ, int duration = 30 * 60, Anonymous? anonymous = null, string flag = "")
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SetGroupAnonymousBan.GetDescription();
                var data = new
                {
                    anonymous,
                    flag,
                    group_id = groupQQ,
                    duration
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 群组全员禁言
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SetGroupWholeBan(this Connect conf, long groupQQ, bool enable = true)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SetGroupWholeBan.GetDescription();
                var data = new
                {
                    group_id = groupQQ,
                    enable
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 群组设置管理员
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SetGroupAdmin(this Connect conf, long groupQQ, long qq, bool enable = true)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SetGroupWholeBan.GetDescription();
                var data = new
                {
                    user_id = qq,
                    group_id = groupQQ,
                    enable
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 群组匿名
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SetGroupAnonymous(this Connect conf, long groupQQ, bool enable = true)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SetGroupAnonymous.GetDescription();
                var data = new
                {
                    group_id = groupQQ,
                    enable
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 设置群名片（群备注）
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SetGroupCard(this Connect conf, long groupQQ, long qq, string card = "")
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SetGroupCard.GetDescription();
                var data = new
                {
                    group_id = groupQQ,
                    user_id = qq,
                    card
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 设置群名
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SetGroupName(this Connect conf, long groupQQ, string name)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SetGroupName.GetDescription();
                var data = new
                {
                    group_id = groupQQ,
                    group_name = name
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 退出群组
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SetGroupLeave(this Connect conf, long groupQQ, bool dissolve)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SetGroupLeave.GetDescription();
                var data = new
                {
                    group_id = groupQQ,
                    is_dismiss = dissolve
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 设置群组专属头衔
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SetGroupSpecialTitle(this Connect conf, long groupQQ, long qq, string title = "", int duration = -1)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SetGroupSpecialTitle.GetDescription();
                var data = new
                {
                    group_id = groupQQ,
                    user_id = qq,
                    special_title = title,
                    duration
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 处理加好友请求
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SetFriendAddRequest(this Connect conf, string flag, bool approve = true, string remark = "")
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SetFriendAddRequest.GetDescription();
                var data = new
                {
                    flag,
                    approve,
                    remark
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 处理加群请求／邀请
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SetGroupAddRequest(this Connect conf, string flag, RequestSubType type, bool approve = true, string reason = "")
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.SetGroupAddRequest.GetDescription();
                var data = new
                {
                    flag,
                    approve,
                    type = type.ToString(),
                    reason
                };
                var res = await Tools.PostAsync<ApiResult>(url, data.ToJsonStr(), conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                var result = true;
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取登录号信息
        /// </summary>
        /// <returns></returns>
        public static async Task<UserBaseInfo> GetLoginInfo(this Connect conf)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetLoginInfo.GetDescription();
                var res = await Tools.GetAsync<ApiResult<UserBaseInfo>>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取陌生人信息
        /// </summary>
        /// <returns></returns>
        public static async Task<StrangerInfo> GetStrangerInfo(this Connect conf, long qq, bool noCache = false)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetStrangerInfo.GetDescription();
                url += $"?user_id={qq}&no_cache={noCache}";
                var res = await Tools.GetAsync<ApiResult<StrangerInfo>>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <returns></returns>
        public static async Task<List<FriendInfo>> GetFriendList(this Connect conf)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetFriendList.GetDescription();
                var res = await Tools.GetAsync<ApiResult<List<FriendInfo>>>(url, conf.Headers); if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                res.Data.ForEach(x => x.Connect = conf);
                return res.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群信息
        /// </summary>
        /// <returns></returns>
        public static async Task<GroupInfo> GetGroupInfo(this Connect conf, long groupQQ, bool noCache = false)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetGroupInfo.GetDescription();
                url += $"?group_id={groupQQ}&no_cache={noCache}";
                var res = await Tools.GetAsync<ApiResult<GroupInfo>>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                res.Data.Connect = conf;
                return res.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群列表
        /// </summary>
        /// <returns></returns>
        public static async Task<List<GroupInfo>> GetGroupList(this Connect conf)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetGroupList.GetDescription();
                var res = await Tools.GetAsync<ApiResult<List<GroupInfo>>>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                res.Data.ForEach(x => x.Connect = conf);
                return res.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群成员信息
        /// </summary>
        /// <returns></returns>
        public static async Task<GroupMemberInfo> GetGroupMemberInfo(this Connect conf, long groupQQ, long qq, bool noCache = false)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetGroupMemberInfo.GetDescription();
                url += $"?group_id={groupQQ}&user_id={qq}&no_cache={noCache}";
                var res = await Tools.GetAsync<ApiResult<GroupMemberInfo>>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                res.Data.Connect = conf;
                return res.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群成员列表
        /// </summary>
        /// <returns></returns>
        public static async Task<List<GroupMemberInfo>> GetGroupMemberList(this Connect conf, long groupQQ)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetGroupMemberList.GetDescription();
                url += $"?group_id={groupQQ}";
                var res = await Tools.GetAsync<ApiResult<List<GroupMemberInfo>>>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                res.Data.ForEach(x => x.Connect = conf);
                return res.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群荣誉信息
        /// </summary>
        /// <returns></returns>
        public static async Task<GroupHonorInfo> GetGroupHonorInfo(this Connect conf, long groupQQ)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetGroupHonorInfo.GetDescription();
                url += $"?group_id={groupQQ}";
                var res = await Tools.GetAsync<ApiResult<GroupHonorInfo>>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #region Cookie相关接口暂时不用
        /// <summary>
        /// 获取 Cookies
        /// </summary>
        //[Description("get_cookies")] GetCookies,

        /// <summary>
        /// 获取 CSRF Token
        /// </summary>
        //[Description("get_csrf_token")] GetCsrfToken,

        /// <summary>
        /// 获取 QQ 相关接口凭证
        /// </summary>
        //[Description("get_credentials")] GetCredentials,
        #endregion

        /// <summary>
        /// 获取语音
        /// 要使用此接口，通常需要安装 ffmpeg
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetRecord(this Connect conf, string file, string format)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetRecord.GetDescription();
                url += $"?file={file}&out_format={format}";
                var res = await Tools.GetAsync<ApiResult<FileInfoBase>>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data.File;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetImage(this Connect conf, string file)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetImage.GetDescription();
                url += $"?file={file}";
                var res = await Tools.GetAsync<ApiResult<FileInfoBase>>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data.File;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 检查是否可以发送图片
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> CanSendImage(this Connect conf)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.CanSendImage.GetDescription();
                var res = await Tools.GetAsync<ApiResult<FileCanSend>>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data.Yes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 检查是否可以发送语音
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> CanSendRecord(this Connect conf)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.CanSendRecord.GetDescription();
                var res = await Tools.GetAsync<ApiResult<FileCanSend>>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                return res.Data.Yes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取运行状态
        /// </summary>
        /// <returns></returns>
        public static async Task<JObject> GetStatus(this Connect conf)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetStatus.GetDescription();
                var res = await Tools.GetAsync<ApiResult<object>>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                var result = res.Data.ToJsonStr().ToJObject();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取版本信息
        /// </summary>
        /// <returns></returns>
        public static async Task<JObject> GetVersion(this Connect conf)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.GetVersion.GetDescription();
                var res = await Tools.GetAsync<ApiResult<object>>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                if (res.Data == null) throw new InvalidDataException("响应数据为空");
                var result = res.Data.ToJsonStr().ToJObject();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 重启 OneBot 实现
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> Restart(this Connect conf, int delay = 0)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.Restart.GetDescription() + "?delay=" + delay;
                var res = await Tools.GetAsync<ApiResult>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 清理缓存
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> CleanCache(this Connect conf)
        {
            try
            {
                var url = conf.HttpUrl + HttpEndpoints.CleanCache.GetDescription();
                var res = await Tools.GetAsync<ApiResult>(url, conf.Headers);
                if (res == null) throw new InvalidDataException("响应内容为空！");
                if (res.Status == "failed") throw new Exception(res.Message);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 扩展API
        #endregion
    }
}