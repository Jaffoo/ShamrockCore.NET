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
    }
}
