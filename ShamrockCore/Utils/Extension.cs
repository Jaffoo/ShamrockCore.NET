using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShamrockCore.Data.HttpAPI;
using ShamrockCore.Data.Model;

namespace ShamrockCore.Utils
{
    public static class Extension
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public static T ToObject<T>(this string str)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(str)) throw new ArgumentNullException(nameof(str));
                var obj = JObject.Parse(str);
                var arr = obj["message"] ?? null;
                if (arr != null && arr.Any())
                {
                    foreach (JObject item in arr.Cast<JObject>())
                    {
                        var type = item["type"]?.ToString() ?? "";
                        if (type == "json")
                        {
                            var dataStr = item["data"]?["data"]?.ToString();
                            if (!string.IsNullOrWhiteSpace(dataStr))
                            {
                                item["data"]!["data"] = JObject.Parse(dataStr.Replace("\"{", "{").Replace("}\"", "}").Replace("\\", ""));
                            }
                        }
                    }
                    obj["message"] = arr;
                    str = obj.ToString();
                }
                var res = JsonConvert.DeserializeObject<T>(str);
                return res == null ? throw new Exception("反序列化失败！") : res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string Description<T>(this T value) where T : Enum
        {
            Type type = typeof(T);
            string name = Enum.GetName(type, value)!;
            MemberInfo member = type.GetMember(name)[0];
            DescriptionAttribute? attribute = member.GetCustomAttribute<DescriptionAttribute>();
            return attribute != null ? attribute.Description : name;
        }

        #region 接口
        #region 获取信息
        /// <summary>
        /// 获取登录号信息
        /// </summary>
        /// <param name="bot"></param>
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
        /// <param name="bot"></param>
        /// <param name="stangerId"></param>
        /// <returns></returns>
        public static async Task<Stranger?> GetStrangerInfo(long stangerId)
        {
            try
            {
                var res = await HttpEndpoints.GetStrangerInfo.GetAsync<Stranger>("user_id=" + stangerId);
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
        /// <param name="bot"></param>
        /// <returns></returns>
        public static async Task<List<Group>?> GetGroups()
        {
            try
            {
                var res = await HttpEndpoints.GetGroupList.GetAsync<List<Group>>();
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
        /// <param name="bot"></param>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public static async Task<Group?> GetGroupInfo(long groupId)
        {
            try
            {
                var res = await HttpEndpoints.GetGroupInfo.GetAsync<Group>("group_id=" + groupId);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // <summary>
        /// 获取好友列表
        /// </summary>
        /// <param name="bot"></param>
        /// <returns></returns>
        public static async Task<List<Friend>?> GetFriends()
        {
            try
            {
                var res = await HttpEndpoints.GetFriendList.GetAsync<List<Friend>>();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region 设置/发布信息
        #endregion
        #endregion
    }
}
