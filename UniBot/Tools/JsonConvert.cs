using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;
using Newtonsoft.Json.Converters;
using UniBot.Receiver;

namespace UniBot.Tools
{
    internal static class JsonConvertTool
    {
        /// <summary>
        /// 自定义json序列化特性标注
        /// </summary>
        [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        internal class CustomJsonPropertyAttribute : Attribute
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
        internal class CustomJsonConverter : JsonConverter
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

        internal class LowercaseStringEnumConverter : StringEnumConverter
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

        private static List<T> CreateInstance<T>(string @namespace) where T : class
        {
            return Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.FullName != null)
            .Where(type => type.FullName!.Contains(@namespace))
            .Where(type => !type.IsAbstract)
            .Select(type =>
            {
                if (Activator.CreateInstance(type) is T instance)
                {
                    return instance;
                }

                return null;
            })
            .Where(i => i != null).ToList()!;
        }

        private static readonly List<MsgReceiverBase> msgReceiverBases = CreateInstance<MsgReceiverBase>("UniBot.Message");

        internal static MsgReceiverBase? MessageHandel(string data)
        {
            try
            {
                var raw = JsonConvert.DeserializeObject<MsgReceiverBase>(data);
                if (raw == null) return null;
                raw!.OriginalData = JObject.Parse(data);
                Type type = raw.GetType();
                // 因为有异常捕获来处理转换失败的情况, 如果获取不到类型那一定得抛出异常, 所以此处直接用索引获取.
                foreach (var msgReceiver in msgReceiverBases)
                {
                    if (msgReceiver == null) continue;
                    if (msgReceiver.PostType == raw.PostType)
                        type = msgReceiver.GetType();
                }
                return JsonConvert.DeserializeObject(data, type) as MsgReceiverBase;
            }
            catch
            {
                var re = JsonConvert.DeserializeObject<MsgReceiverBase>(data);
                re!.OriginalData = JObject.Parse(data);
                return re;
            }
        }
    }
}
