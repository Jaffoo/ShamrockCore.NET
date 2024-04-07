using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;
using Newtonsoft.Json.Converters;
using UniBot.Receiver;
using UniBot.Message;
using UniBot.Message.Chain;
using UniBot.Receiver.MessageReceiver;
using UniBot.Model;
using UniBot.Receiver.EventReceiver;
using System;
using TBC.CommonLib;

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
            public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
            {
                string enumString = (string)reader.Value!;
                var members = objectType.GetMembers();
                var unknow = members.FirstOrDefault(x => x.MemberType == MemberTypes.Field&&x.Name.Contains("Unknow"));
                if (Enum.TryParse(objectType, enumString, true, out object? parsedEnum))
                {
                    if (parsedEnum == null)
                    {
                        if (unknow != null)
                            return Enum.TryParse(objectType, unknow.Name, true, out object? unknowEnum);
                        else
                        {
                            var def = members.FirstOrDefault(x => x.MemberType == MemberTypes.Field && x.Name != "value__");
                            return Enum.TryParse(objectType, def!.Name, true, out object? unknowEnum);
                        }
                    }
                    return parsedEnum;
                }
                else
                {
                    if (unknow != null)
                        return Enum.TryParse(objectType, unknow.Name, true, out object? unknowEnum);
                    else
                    {
                        var def = members.FirstOrDefault(x => x.MemberType == MemberTypes.Field && x.Name != "value__");
                        return Enum.TryParse(objectType, def!.Name, true, out object? unknowEnum);
                    }
                }
            }
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

        private static readonly List<MessageBase> MessageBases = CreateInstance<MessageBase>("UniBot.Message");
        private static readonly List<MessageReceiver> MessageReceiverBases = CreateInstance<MessageReceiver>("UniBot.Receiver.MessageReceiver");
        private static readonly List<EventReceiver> EventReceiverBases = CreateInstance<EventReceiver>("UniBot.Receiver.Event");

        /// <summary>
        /// 消息段处理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static void MessageHandel(MessageReceiver data, Connect conf)
        {
            try
            {
                data.Message ??= JsonConvert.DeserializeObject<MessageChain>(data.OriginalData!["message"]!.ToString());
                foreach (var item in MessageBases)
                {
                    Type dllType = item.GetType();
                    if (dllType.Name == "MessageBase") continue;
                    var bodyDll = dllType.GetNestedType("Body")!;
                    foreach (var msg in data.Message!)
                    {
                        if (msg.Type == item.Type)
                        {
                            var tempData = ((JObject)msg.Data!).ToString()!;
                            msg.Connect = conf;
                            msg.Data = null;
                            msg.Data = JsonConvert.DeserializeObject(tempData, bodyDll);
                            break;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// 接收事件处理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static MessageReceiver? EventReceiverHandel(string data, Connect conf)
        {
            try
            {
                var raw = JsonConvert.DeserializeObject<MessageReceiver>(data);
                if (raw == null) return null;
                raw!.OriginalData = JObject.Parse(data);
                Type type = raw.GetType();
                foreach (var messageReceiver in EventReceiverBases)
                {
                    if (messageReceiver == null) continue;
                    if (messageReceiver.PostType == raw.PostType)
                        type = messageReceiver.GetType();
                }
                if (JsonConvert.DeserializeObject(data, type) is not MessageReceiver message) return null;
                message.OriginalData = JObject.Parse(data);
                message.Connect = conf;
                return message;
            }
            catch
            {
                var re = JsonConvert.DeserializeObject<MessageReceiver>(data);
                re!.OriginalData = JObject.Parse(data);
                return re;
            }
        }

        /// <summary>
        /// 接收消息处理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static MessageReceiverBase? MessageReceiverHandel(string data, Connect conf)
        {
            try
            {
                var raw = JsonConvert.DeserializeObject<MessageReceiver>(data);
                if (raw == null) return null;
                raw!.OriginalData = JObject.Parse(data);
                Type type = raw.GetType();
                foreach (var messageReceiver in MessageReceiverBases)
                {
                    if (messageReceiver == null) continue;
                    if (messageReceiver.MessageType == raw.MessageType)
                        type = messageReceiver.GetType();
                }
                if (JsonConvert.DeserializeObject(data, type) is not MessageReceiver message) return null;
                message.OriginalData = JObject.Parse(data);
                message.Connect = conf;
                MessageHandel(message, conf);
                return message;
            }
            catch
            {
                var re = JsonConvert.DeserializeObject<MessageReceiverBase>(data);
                re!.OriginalData = JObject.Parse(data);
                return re;
            }
        }
    }
}
