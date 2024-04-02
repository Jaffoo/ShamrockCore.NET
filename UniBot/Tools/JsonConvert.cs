using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;
using Newtonsoft.Json.Converters;

namespace UniBot.Tools
{
    public static class JsonConvert
    {
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

        public class LowercaseStringEnumConverter : StringEnumConverter
        {
            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value is Enum)
                {
                    string enumString = value!.ToString()!.ToLower();
                    writer.WriteValue(enumString);
                }
                else
                {
                    base.WriteJson(writer, value, serializer);
                }
            }
        }
    }
}
