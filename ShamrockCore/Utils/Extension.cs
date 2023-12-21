using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShamrockCore.Reciver.MsgChain;

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

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        internal static string Description<T>(this T value) where T : Enum
        {
            Type type = typeof(T);
            string name = Enum.GetName(type, value)!;
            MemberInfo member = type.GetMember(name)[0];
            DescriptionAttribute? attribute = member.GetCustomAttribute<DescriptionAttribute>();
            return attribute != null ? attribute.Description : name;
        }

        /// <summary>
        /// 消息类型转换
        /// </summary>
        /// <typeparam name="T">消息子类</typeparam>
        /// <param name="message">消息基类</param>
        /// <returns></returns>
        public static T ConvertTo<T>(this Message message) where T : class
        {
            T result = Activator.CreateInstance<T>();
            PropertyInfo[] properties = typeof(T).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.Name == "Type")
                {
                    property.SetValue(result, message.Type);
                }
                if (property.Name == "Data" && property.PropertyType.Name == "Body")
                {
                    PropertyInfo[]? msgProperty = message.Data.GetType().GetProperties();
                    PropertyInfo[]? tProperty = property.GetValue(result)?.GetType().GetProperties();
                    if (tProperty != null)
                    {
                        foreach (var tProp in tProperty)
                        {
                            var matchingProp = msgProperty.FirstOrDefault(p => p.Name == tProp.Name && p.PropertyType == tProp.PropertyType);
                            if (matchingProp != null)
                            {
                                var value = matchingProp.GetValue(message.Data);
                                tProp.SetValue(property.GetValue(result), value);
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
