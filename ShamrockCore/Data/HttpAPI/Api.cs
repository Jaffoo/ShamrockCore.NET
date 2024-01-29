using Flurl;
using Manganese.Text;
using ShamrockCore.Data.Model;
using ShamrockCore.Receiver.MsgChain;
using ShamrockCore.Utils;

namespace ShamrockCore.Data.HttpAPI
{
    internal static class Api
    {
        #region 接口
        #region 获取信息
        /// <summary>
        /// 获取登录号信息
        /// </summary>
        /// <returns></returns>
        public static async Task<LoginInfo?> GetLoginInfo()
        {
            try
            {
                var res = await HttpEndpoints.GetLoginInfo.GetAsync<LoginInfo>();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取陌生人信息
        /// </summary>
        /// <param name="strangerId"></param>
        /// <returns></returns>
        public static async Task<Stranger?> GetStrangerInfo(long qq)
        {
            try
            {
                if (qq <= 0) throw new ArgumentException("qq号不存在");
                var res = await HttpEndpoints.GetStrangerInfo.GetAsync<Stranger>("user_id=" + qq);
                return res;
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
        public static async Task<IEnumerable<Group>?> GetGroups()
        {
            try
            {
                var res = await HttpEndpoints.GetGroupList.GetAsync<IEnumerable<Group>>();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群信息
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <returns></returns>
        public static async Task<Group?> GetGroupInfo(long groupQQ)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var res = await HttpEndpoints.GetGroupInfo.GetAsync<Group>("group_id=" + groupQQ);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群成员
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<Member>?> GetGroupMemberList(long groupQQ)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var res = await HttpEndpoints.GetGroupMemberList.GetAsync<IEnumerable<Member>>("group_id=" + groupQQ);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群成员信息
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <param name="qq"></param>
        /// <returns></returns>
        public static async Task<Member?> GetGroupMemberInfo(long groupQQ, long qq)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (qq <= 0) throw new ArgumentException("成员不存在");
                var res = await HttpEndpoints.GetGroupMemberInfo.GetAsync<Member>("group_id=" + groupQQ, "user_id=" + qq);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群荣誉信息
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <returns></returns>
        public static async Task<Honor?> GetGroupHonorInfo(long groupQQ)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var res = await HttpEndpoints.GetGroupHonorInfo.GetAsync<Honor>("group_id=" + groupQQ);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群系统消息
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <returns></returns>
        public static async Task<GroupSysMsg?> GetGroupSystemMsg(long groupQQ)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var res = await HttpEndpoints.GetGroupSystemMsg.GetAsync<GroupSysMsg>("group_id=" + groupQQ);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取精华消息列表
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<EssenceMsg>?> GetEssenceMsgs(long groupQQ)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var res = await HttpEndpoints.GetEssenceMsgList.GetAsync<IEnumerable<EssenceMsg>>("group_id=" + groupQQ);
                return res;
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
        public static async Task<IEnumerable<Friend>?> GetFriends()
        {
            try
            {
                var res = await HttpEndpoints.GetFriendList.GetAsync<IEnumerable<Friend>>();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取好友系统消息(未能正确获取到数据)
        /// </summary>
        /// <returns></returns>
        public static async Task<IEnumerable<FriendSysMsg>?> GetFriendSysMsg()
        {
            try
            {
                var res = await HttpEndpoints.GetFriendSysMsg.GetAsync<IEnumerable<FriendSysMsg>>();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 是否在黑名单中
        /// </summary>
        /// <returns></returns>
        public static async Task<IsInBack?> IsBlacklistUin(long qq)
        {
            try
            {
                if (qq <= 0) throw new ArgumentException("qq号不存在");
                var res = await HttpEndpoints.IsBlacklistUin.GetAsync<IsInBack>("user_id=" + qq);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取合并转发内容(不稳定，暂不提供使用)
        /// 由于QQ内部错误，该接口可能导致闪退等问题的出现！一般是闪退一次后再次重新启动便不再闪退，但是可能无法获取合并转发的内容！
        /// </summary>
        /// <param name="id">消息资源ID（卡片消息里面的resId）</param>
        /// <returns></returns>
        public static async Task<MessageChain?> GetForwardMsg(int id)
        {
            try
            {
                await Task.Delay(1);
                return new();
                //var res = await HttpEndpoints.GetForwardMsg.GetAsync<MessageChain>("id=" + id);
                //return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="fileMd5">文件 MD5</param>
        /// <returns></returns>
        public static async Task<Model.FileInfo?> GetImage(string fileMd5)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileMd5)) throw new ArgumentException("文件不存在");
                var res = await HttpEndpoints.GetImage.GetAsync<Model.FileInfo>("file=" + fileMd5);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取语音(要使用此接口, 通常需要安装 ffmpeg, 请参考 OneBot 实现的相关说明)
        /// </summary>
        /// <param name="fileMd5">文件 MD5</param>
        /// <param name="OutFormat">输出格式(mp3、amr、wma、m4a、spx、ogg、wav、flac)</param>
        /// <returns></returns>
        public static async Task<RecordInfo?> GetRecord(string fileMd5, string OutFormat = "mp3")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(fileMd5)) throw new ArgumentException("文件不存在");
                var res = await HttpEndpoints.GetRecord.GetAsync<RecordInfo>("file=" + fileMd5, "out_format=" + OutFormat);
                return res;
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
        public static async Task<MsgInfo?> GetMsg(long messageId)
        {
            try
            {
                if (messageId <= 0) throw new ArgumentException("消息不存在");
                var res = await HttpEndpoints.GetMsg.GetAsync<MsgInfo>("message_id=" + messageId);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取历史消息
        /// </summary>
        /// <param name="msgType"></param>
        /// <param name="qq"></param>
        /// <param name="groupQQ"></param>
        /// <param name="count"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<MsgInfo>?> GetHistoryMsg(MessageType msgType, long qq = 0, long groupQQ = 0, int count = 10, int start = 0)
        {
            try
            {
                var obj = new
                {
                    message_type = msgType,
                    user_id = qq,
                    group_id = groupQQ,
                    count,
                    message_seq = start
                };
                var res = await HttpEndpoints.GetHistoryMsg.PostAsync<IEnumerable<MsgInfo>>(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群聊历史消息
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <param name="count"></param>    
        /// <param name="start"></param>
        /// <returns></returns>
        public static async Task<MessageChain?> GetGroupMsgHistory(long groupQQ, int count = 10, int start = 0)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var obj = new
                {
                    group_id = groupQQ,
                    count,
                    message_seq = start
                };
                var res = await HttpEndpoints.GetGroupMsgHistory.PostAsync<MessageChain>(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群公告
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <returns></returns>
        public static async Task<IEnumerable<Announcement>?> GetGroupNotice(long groupQQ)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var res = await HttpEndpoints.GetGroupNotice.GetAsync<IEnumerable<Announcement>>("group_id=" + groupQQ);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取被禁言的群成员列表
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <returns></returns>
        public static async Task<IEnumerable<Banner>?> GetBanList(long groupQQ)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var obj = new
                {
                    group_id = groupQQ
                };
                var res = await HttpEndpoints.GetBanList.PostAsync<IEnumerable<Banner>>(obj);
                if (res != null)
                {
                    foreach (var item in res)
                    {
                        item.GroupQQ = groupQQ;
                    }
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群文件系统信息
        /// </summary>
        /// <returns></returns>
        public static async Task<FileSystemInfo?> GetGroupFileSystemInfo(long groupQQ)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var obj = new
                {
                    group_id = groupQQ
                };
                var res = await HttpEndpoints.GetGroupFileSystemInfo.PostAsync<FileSystemInfo>(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群根目录文件列表
        /// </summary>
        /// <returns></returns>
        public static async Task<FilesFloders?> GetGroupRootFiles(long groupQQ)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var obj = new
                {
                    group_id = groupQQ,
                };
                var res = await HttpEndpoints.GetGroupRootFiles.PostAsync<FilesFloders>(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群子目录文件列表
        /// </summary>
        /// <returns></returns>
        public static async Task<FilesFloders?> GetGroupFiles(long groupQQ, string folderId)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (string.IsNullOrWhiteSpace(folderId)) throw new ArgumentException("群文件夹不存在");
                var obj = new
                {
                    group_id = groupQQ,
                    folder_id = folderId
                };
                var res = await HttpEndpoints.GetGroupFiles.PostAsync<FilesFloders>(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取群文件资源链接
        /// </summary>
        /// <returns></returns>
        public static async Task<FileBaseInfo?> GetGroupFileUrl(long groupQQ, string fileId, int busid)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (string.IsNullOrWhiteSpace(fileId)) throw new ArgumentException("群文件不存在");
                if (busid <= 0) throw new ArgumentException("文件类型不存在");
                var obj = new
                {
                    group_id = groupQQ,
                    file_id = fileId,
                    busid
                };
                var res = await HttpEndpoints.GetGroupFileUrl.PostAsync<FileBaseInfo>(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取手机电池信息
        /// </summary>
        /// <returns></returns>
        public static async Task<BatteryInfo?> GetDeviceBattery()
        {
            try
            {
                var res = await HttpEndpoints.GetDeviceBattery.PostAsync<BatteryInfo>();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取Shamrock启动时间
        /// </summary>
        /// <returns></returns>
        public static async Task<long> GetStartTime()
        {
            try
            {
                var res = await HttpEndpoints.GetStartTime.PostAsync<long>();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取Shamrock日志
        /// </summary>
        /// <param name="start">开始的行</param>
        /// <param name="recent">是否只显示最近的日志</param>
        /// <returns></returns>
        public static async Task<string> GetLog(int start = 0, bool recent = false)
        {
            try
            {
                var url = Bot.Instance!.Config.HttpUrl + HttpEndpoints.Log.Description();
                if (start > 0) url = url.SetQueryParam("start", start);
                var res = await HttpUtil.GetStringAsync(url.SetQueryParam("recent", recent));
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 获取机器人可在群@全体成员的剩余次数
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <returns></returns>
        public static async Task<int> GetAtAllCount(long groupQQ)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var url = Bot.Instance!.Config.HttpUrl + HttpEndpoints.GetAtAllCount.Description();
                var res = await HttpUtil.GetStringAsync(url.SetQueryParam("group_id", groupQQ));
                var canAtAll = (res.Fetch("can_at_all") ?? "false").ToBool();
                if (!canAtAll) return 0;
                var count = res.Fetch("remain_at_all_count_for_uin") ?? "0";
                return count.ToInt();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 设置/发布信息
        /// <summary>
        /// 设置 qq 个人资料
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> SetQQProfile(Profile profile)
        {
            try
            {
                var res = await HttpEndpoints.SetQQProfile.PostAsync(profile);
                return res;
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
        public static async Task<bool> DeleteMsg(long messageId)
        {
            try
            {
                if (messageId <= 0) throw new ArgumentException("消息不存在");
                var res = await HttpEndpoints.DeleteMsg.GetAsync("message_id=" + messageId);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 清除本地缓存消息
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> ClearMsgs(MessageType msgType, long qq = 0, long group = 0)
        {
            try
            {
                var obj = new
                {
                    message_type = msgType,
                    user_id = qq,
                    group_id = group
                };
                var res = await HttpEndpoints.ClearMsgs.PostAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 处理加好友请求
        /// </summary>
        /// <param name="flag">加群请求的 flag</param>
        /// <param name="approve">是否同意请求</param>
        /// <param name="remark">添加后的好友备注（仅在同意时有效）</param>
        /// <returns></returns>
        public static async Task<bool> SetFriendAddRequest(string flag, bool approve, string remark = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(flag)) throw new ArgumentException("请求不存在");
                var obj = new
                {
                    flag,
                    approve,
                    remark,
                };
                var res = await HttpEndpoints.SetFriendAddRequest.PostAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 处理加群请求／邀请
        /// </summary>
        /// <param name="flag">加群请求的 flag</param>
        /// <param name="type">add或invite（需要和上报消息中的sub_type字段相符）</param>
        /// <param name="approve">是否同意请求／邀请</param>
        /// <param name="reason">拒绝理由（仅在拒绝时有效）</param>
        /// <returns></returns>
        public static async Task<bool> SetGroupAddRequest(string flag, string type, bool approve, string reason = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(flag)) throw new ArgumentException("请求不存在");
                if (string.IsNullOrWhiteSpace(type)) throw new ArgumentException("请求类型不可为空");
                var obj = new
                {
                    flag,
                    approve,
                    type,
                    reason
                };
                var res = await HttpEndpoints.SetGroupAddRequest.PostAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 设置群名
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <param name="newName">新名称</param>
        /// <returns></returns>
        public static async Task<bool> SetGroupName(long groupQQ, string newName)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (string.IsNullOrWhiteSpace(newName)) throw new ArgumentException("新群名为空");
                var obj = new
                {
                    group_id = groupQQ,
                    group_name = newName
                };
                var res = await HttpEndpoints.SetGroupName.PostAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 设置群管理
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <param name="qq">要设置的qq</param>
        /// <param name="enable">是否设置</param>
        /// <returns></returns>
        public static async Task<bool> SetGroupAdmin(long groupQQ, long qq, bool enable = true)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (qq <= 0) throw new ArgumentException("成员不存在");
                var obj = new
                {
                    group_id = groupQQ,
                    user_id = qq,
                    enable
                };
                var res = await HttpEndpoints.SetGroupAdmin.PostAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 设置群组专属头衔
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <param name="qq">要设置的qq</param>
        /// <param name="title">头衔</param>
        /// <returns></returns>
        public static async Task<bool> SetGroupSpecialTitle(long groupQQ, long qq, string title)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (qq <= 0) throw new ArgumentException("成员不存在");
                if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("头衔不可为空");
                var obj = new
                {
                    group_id = groupQQ,
                    user_id = qq,
                    special_title = title
                };
                var res = await HttpEndpoints.SetGroupSpecialTitle.PostAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 群单人禁言
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <param name="qq">要禁言的qq</param>
        /// <param name="duration">禁言时长</param>
        /// <returns></returns>
        public static async Task<bool> SetGroupBan(long groupQQ, long qq, long duration)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (qq <= 0) throw new ArgumentException("成员不存在");
                var obj = new
                {
                    group_id = groupQQ,
                    user_id = qq,
                    duration
                };
                var res = await HttpEndpoints.SetGroupBan.PostAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 群全体禁言
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <param name="enable">是否禁言</param>
        /// <returns></returns>
        public static async Task<bool> SetGroupWholeBan(long groupQQ, bool enable = true)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var obj = new
                {
                    group_id = groupQQ,
                    enable
                };
                var res = await HttpEndpoints.SetGroupWholeBan.PostAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 设置精华消息
        /// </summary>
        /// <param name="messageId">消息ID</param>
        /// <returns></returns>
        public static async Task<bool> SetEssenceMsg(long messageId)
        {
            try
            {
                if (messageId <= 0) throw new ArgumentException("精华消息不存在");
                var res = await HttpEndpoints.SetEssenceMsg.GetAsync("message_id=" + messageId);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 移出精华消息
        /// </summary>
        /// <param name="messageId">消息ID</param>
        /// <returns></returns>
        public static async Task<bool> DeleteEssenceMsg(long messageId)
        {
            try
            {
                if (messageId <= 0) throw new ArgumentException("精华消息不存在");
                var res = await HttpEndpoints.DeleteEssenceMsg.GetAsync("message_id=" + messageId);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 群打卡
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <returns></returns>
        public static async Task<bool> SendGroupSign(long groupQQ)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var res = await HttpEndpoints.SendGroupSign.GetAsync("group_id=" + groupQQ);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 发送群公告
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <param name="content">内容</param>
        /// <param name="image">图片,支持base64、http(s)和本地路径</param>
        /// <returns></returns>
        public static async Task<bool> SendGroupNotice(long groupQQ, string content, string? image = null)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                bool res = false;
                if (image == null)
                {
                    var obj = new
                    {
                        group_id = groupQQ,
                        content
                    };
                    res = await HttpEndpoints.SendGroupNotice.PostAsync(obj);
                }
                else
                {
                    var obj = new
                    {
                        group_id = groupQQ,
                        content,
                        image
                    };
                    res = await HttpEndpoints.SendGroupNotice.PostAsync(obj);
                }
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 群组踢人
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <param name="qq">qq号</param>
        /// <param name="rejectAddAgain">是否拒绝再次加群</param>
        /// <returns></returns>
        public static async Task<bool> SetGroupKick(long groupQQ, long qq, bool rejectAddAgain = false)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (qq <= 0) throw new ArgumentException("成员不存在");
                var obj = new
                {
                    group_id = groupQQ,
                    user_id = qq,
                    reject_add_request = rejectAddAgain
                };
                var res = await HttpEndpoints.SetGroupKick.PostAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 退出群组
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <returns></returns>
        public static async Task<bool> SetGroupLeave(long groupQQ)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                var obj = new
                {
                    group_id = groupQQ,
                };
                var res = await HttpEndpoints.SetGroupLeave.PostAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 群戳一戳
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <param name="qq">qq 号</param>
        /// <returns></returns>
        public static async Task<bool> GroupTouch(long groupQQ, long qq)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (qq <= 0) throw new ArgumentException("成员不存在");
                var obj = new
                {
                    group_id = groupQQ,
                    user_id = qq,
                };
                var res = await HttpEndpoints.GroupTouch.PostAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 上传私聊文件
        /// 只能上传本地文件, 需要上传 http 文件的话请先下载至本地
        /// </summary>
        /// <param name="qq">qq 号</param>
        /// <param name="file">文件路径</param>
        /// <param name="name">文件名</param>
        /// <returns></returns>
        public static async Task<UploadInfo?> UploadPrivateFile(long qq, string file, string name)
        {
            try
            {
                if (qq <= 0) throw new ArgumentException("好友不存在");
                if (string.IsNullOrWhiteSpace(file)) throw new ArgumentException("文件不存在");
                if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("文件名为空");
                var obj = new
                {
                    user_id = qq,
                    file,
                    name
                };
                var res = await HttpEndpoints.UploadPrivateFile.PostAsync<UploadInfo>(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 上传群文件
        /// 只能上传本地文件, 需要上传 http 文件的话请先下载至本地
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <param name="file">文件路径</param>
        /// <param name="name">文件名</param>
        /// <returns></returns>
        public static async Task<UploadInfo?> UploadGroupFile(long groupQQ, string file, string name)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (string.IsNullOrWhiteSpace(file)) throw new ArgumentException("文件不存在");
                if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("文件名为空");
                var obj = new
                {
                    group_id = groupQQ,
                    file,
                    name
                };
                var res = await HttpEndpoints.UploadGroupFile.PostAsync<UploadInfo>(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除群文件
        /// </summary>
        /// <param name="groupQQ">群号</param>
        /// <param name="fileId">文件ID</param>
        /// <param name="busid">文件类型</param>
        /// <returns></returns>
        public static async Task<bool> DeleteGroupFile(long groupQQ, string fileId, int busid)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (string.IsNullOrWhiteSpace(fileId)) throw new ArgumentException("文件不存在");
                if (busid <= 0) throw new ArgumentException("文件类型不存在");

                var obj = new
                {
                    group_id = groupQQ,
                    file_id = fileId,
                    busid
                };
                var res = await HttpEndpoints.DeleteGroupFile.PostAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 创建群文件文件夹
        /// 仅能在根目录创建文件夹
        /// </summary>
        /// <returns></returns>
        public static async Task<UploadInfo?> CreateGroupFolder(long groupQQ, string name)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("文件夹名称为空");
                var obj = new
                {
                    group_id = groupQQ,
                    folder_name = name
                };
                var res = await HttpEndpoints.CreateGroupFolder.PostAsync<UploadInfo>(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除群文件文件夹
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> DeleteGroupFolder(long groupQQ, string folderId)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (string.IsNullOrWhiteSpace(folderId)) throw new ArgumentException("群文件夹不存在");
                var obj = new
                {
                    group_id = groupQQ,
                    folder_id = folderId
                };
                var res = await HttpEndpoints.DeleteGroupFolder.PostAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 上传文件到缓存目录（保留）
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> UploadFile(string path)
        {
            try
            {
                await Task.Delay(1);
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 让Shamrock下载文件到缓存目录
        /// </summary>
        /// <param name="url">url和base64二选一，两个均传优选url</param>
        /// <param name="base64">base64</param>
        /// <param name="name">文件名称,默认：文件md5</param>
        /// <param name="threadCount">下载的线程数量	</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static async Task<RecordInfo?> DownloadFile1(string url, string base64 = "", string name = "", int threadCount = 1, string headers = "")
        {
            try
            {
                var obj = new
                {
                    url,
                    base64,
                    name,
                    headers,
                    thread_cnt = threadCount
                };
                var res = await HttpEndpoints.DownloadFile.PostAsync<RecordInfo>(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 让Shamrock下载文件到缓存目录
        /// </summary>
        /// <param name="url">url和base64二选一，两个均传优选url</param>
        /// <param name="base64">base64</param>
        /// <param name="name">文件名称,默认：文件md5</param>
        /// <param name="threadCount">下载的线程数量</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static async Task<RecordInfo?> DownloadFile(string url, string base64 = "", string name = "", int threadCount = 1, IEnumerable<string>? headers = null)
        {
            try
            {
                var obj = new
                {
                    url,
                    base64,
                    name,
                    headers,
                    thread_cnt = threadCount
                };
                var res = await HttpEndpoints.DownloadFile.PostAsync<RecordInfo>(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 发送消息
        /// <summary>
        /// 发送私聊，返回消息id
        /// </summary>
        /// <param name="qq">QQ 号</param>
        /// <param name="message">消息内容</param>
        /// <param name="autoEscape">是否解析 CQ 码。</param>
        /// <returns></returns>
        public static async Task<string> SendPrivateMsgAsync(long qq, MessageChain message, bool autoEscape = false)
        {
            try
            {
                if (qq <= 0) throw new ArgumentException("好友不存在");
                if (message == null) throw new ArgumentException("发送的消息为空");
                var obj = new
                {
                    user_id = qq,
                    message,
                    auto_escape = autoEscape
                };
                var res = await HttpEndpoints.SendPrivateMsg.SendMsgAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 发送群聊消息，返回消息id
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <param name="message">消息内容</param>
        /// <param name="autoEscape">是否解析 CQ 码。</param>
        /// <returns></returns>
        public static async Task<string> SendGroupMsgAsync(long groupQQ, MessageChain message, bool autoEscape = false)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (message == null) throw new ArgumentException("发送的消息为空");
                var obj = new
                {
                    group_id = groupQQ,
                    message,
                    auto_escape = autoEscape
                };
                var res = await HttpEndpoints.SendGroupMsg.SendMsgAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 发送消息，返回消息id
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="message">消息内容</param>
        /// <param name="autoEscape">是否解析 CQ 码。</param>
        /// <returns></returns>
        public static async Task<string> SendMsgAsync(MessageType type, long qq, long groupQQ, long discussId, object message, bool autoEscape = false)
        {
            try
            {
                if (qq <= 0) throw new ArgumentException("好友不存在");
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (message == null) throw new ArgumentException("发送的消息为空");
                var obj = new
                {
                    message_type = type,
                    user_id = qq,
                    group_id = groupQQ,
                    discuss_id = discussId,
                    message,
                    auto_escape = autoEscape
                };
                var res = await HttpEndpoints.SendMsg.SendMsgAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 发送群聊合并转发
        /// </summary>
        /// <param name="groupQQ"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static async Task<string> SendGroupForwardMsgAsync(long groupQQ, object messages)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (messages == null) throw new ArgumentException("发送的消息为空");
                var obj = new
                {
                    group_id = groupQQ,
                    messages
                };
                var res = await HttpEndpoints.SendGroupForwardMsg.SendMsgAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 发送私聊合并转发
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="messages"></param>
        /// <returns></returns>
        public static async Task<string> SendPrivateForwardMsgAsync(long qq, object messages)
        {
            try
            {
                if (qq <= 0) throw new ArgumentException("好友不存在");
                if (messages == null) throw new ArgumentException("发送的消息为空");
                var obj = new
                {
                    user_id = qq,
                    messages
                };
                var res = await HttpEndpoints.SendPrivateForwardMsg.SendMsgAsync(obj);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<bool> SetGroupCommentFace(long groupQQ, int msgId, int faceId, bool isSet)
        {
            try
            {
                if (groupQQ <= 0) throw new ArgumentException("群不存在");
                if (msgId <= 0) throw new ArgumentException("消息不存在");
                if (faceId <= 0) throw new ArgumentException("表情无效");
                var obj = new
                {
                    group_id = groupQQ,
                    msg_id = msgId,
                    face_id = faceId,
                    is_set = isSet
                };
                return await HttpEndpoints.SetGroupCommentFace.PostAsync(obj);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
        #endregion
    }
}
