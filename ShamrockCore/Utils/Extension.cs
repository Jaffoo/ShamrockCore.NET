using System;
using System.ComponentModel;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShamrockCore.Receiver.MsgChain;

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
            catch (Exception e)
            {
                throw new Exception(e.Message);
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
            try
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
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 字符串转枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string str) where T : struct
        {
            try
            {
                return (T)Enum.Parse(typeof(T), str);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 数字转枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="num"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int num) where T : struct
        {
            try
            {
                if (Enum.IsDefined(typeof(T), num))
                {
                    return (T)Enum.ToObject(typeof(T), num);
                }
                else
                {
                    throw new Exception("转换失败！");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 转int
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static int ToInt(this string? str, int defaultVal = 0)
        {
            if (string.IsNullOrWhiteSpace(str)) return defaultVal;
            if (int.TryParse(str, out defaultVal)) return defaultVal;
            return defaultVal;
        }

        /// <summary>
        /// 转bool
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static bool ToBool(this string? str, bool defaultVal = false)
        {
            if (string.IsNullOrWhiteSpace(str)) return defaultVal;
            if (bool.TryParse(str, out defaultVal)) return defaultVal;
            return defaultVal;
        }
    }

    /// <summary>
    /// 自定义json序列化特性标注
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CustomJsonPropertyAttribute : Attribute
    {
        public string[] FieldNames { get; }

        public CustomJsonPropertyAttribute(params string[] fieldNames)
        {
            FieldNames = fieldNames;
        }
    }

    /// <summary>
    /// 一个类属性可以对应多个json字段，但只会反序列化一个
    /// </summary>
    public class CustomJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetCustomAttributes(typeof(CustomJsonPropertyAttribute), true).Length > 0;
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);

            PropertyInfo[] properties = objectType.GetProperties();
            foreach (var property in properties)
            {
                var attribute = (CustomJsonPropertyAttribute?)property.GetCustomAttribute(typeof(CustomJsonPropertyAttribute));
                if (attribute != null)
                {
                    foreach (var fieldName in attribute.FieldNames)
                    {
                        if (jsonObject[fieldName] != null)
                        {
                            return jsonObject[fieldName]?.Value<string>();
                        }
                    }
                }
            }

            return null;
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
