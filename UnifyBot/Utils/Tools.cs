using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnifyBot.Utils
{
    public static class Tools
    {
        #region 网络请求
        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static async Task<string> GetAsync(string url, Dictionary<string, string>? headers = null)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(res) ?? throw new Exception("类型转换失败！");
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="jsonBody">请求body</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static async Task<string> PostAsync(string url, string jsonBody, Dictionary<string, string>? headers = null)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                HttpResponseMessage response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="jsonBody">请求body</param>
        /// <param name="headers">请求头</param>
        /// <returns></returns>
        public static async Task<T> PostAsync<T>(string url, string jsonBody, Dictionary<string, string>? headers = null)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                HttpResponseMessage response = await httpClient.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                var res = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(res) ?? throw new Exception("类型转换失败！");
            }
            catch (HttpRequestException)
            {
                throw;
            }
        }
        #endregion

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T value) where T : Enum
        {
            Type type = typeof(T);
            string name = Enum.GetName(type, value)!;
            MemberInfo member = type.GetMember(name)[0];
            DescriptionAttribute? attribute = member.GetCustomAttribute<DescriptionAttribute>();
            return attribute != null ? attribute.Description : name;
        }

        /// <summary>
        /// 类转json字符串
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="value">实体类</param>
        /// <param name="format">格式化方式</param>
        /// <returns></returns>
        public static string ToJsonStr<T>(this T value, Formatting format = Formatting.Indented) where T : class
        {
            var jsonStr = JsonConvert.SerializeObject(value, format);
            return jsonStr;
        }

        /// <summary>
        /// 是否是json字符串
        /// </summary>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static bool IsValidJson(this string jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString)) return false;
            try
            {
                _ = JsonConvert.DeserializeObject(jsonString);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }

        /// <summary>
        /// json字符串转对象
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="str">json字符串</param>
        /// <returns></returns>
        public static T ToModel<T>(this string str) where T : class
        {
            if (!str.IsValidJson()) throw new Exception("请传入json字符串");
            var res = JsonConvert.DeserializeObject<T>(str);
            return res ?? throw new Exception("json字符串转对象失败");
        }


        /// <summary>
        /// 获取json字符串的键的值
        /// </summary>
        /// <param name="str">json字符串</param>
        /// <param name="keys">键</param>
        /// <returns></returns>
        public static string Fetch(this string str, params string[] keys)
        {
            if (!str.IsValidJson())
                throw new ArgumentException("无效的JSON字符串。");

            JObject jsonObject = JObject.Parse(str);
            var results = new List<string>();

            foreach (var key in keys)
            {
                var list = key.Split(':');
                JToken? token = jsonObject;
                foreach (var l in list)
                {
                    token = token[l];
                    if (token == null) throw new KeyNotFoundException($"JSON字符串中找不到键值'{key}'。");
                }
                if (token == null)
                {
                    throw new KeyNotFoundException($"JSON字符串中找不到键值'{key}'。");
                }

                results.Add(token.ToString());
            }

            return string.Concat(results); // 直接拼接结果
        }


        /// <summary>
        /// 获取json字符串的键的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str">json字符串</param>
        /// <param name="keys">键</param>
        /// <returns></returns>
        public static T Fetch<T>(this string str, params string[] keys)
        {
            if (!str.IsValidJson())
                throw new ArgumentException("无效的JSON字符串。");

            JObject jsonObject = JObject.Parse(str);
            var results = new List<string>();

            foreach (var key in keys)
            {
                var list = key.Split(':');
                JToken? token = jsonObject;
                foreach (var l in list)
                {
                    token = token[l];
                    if (token == null) throw new KeyNotFoundException($"JSON字符串中找不到键值'{key}'。");
                }
                if (token == null)
                {
                    throw new KeyNotFoundException($"JSON字符串中找不到键值'{key}'。");
                }

                results.Add(token.ToString());
            }
            try
            {
                return (T)Convert.ChangeType(string.Concat(results), typeof(T));
            }
            catch
            {
                return JsonConvert.DeserializeObject<T>(string.Concat(results)) ?? throw new JsonSerializationException();
            }
        }

        /// <summary>
        /// 字符串转JObject
        /// </summary>
        /// <param name="str">json字符串</param>
        /// <returns></returns>
        public static JObject ToJObject(this string str)
        {
            if (!str.IsValidJson()) throw new Exception("非json字符串！");
            return JObject.Parse(str);
        }
    }
}
