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
using Newtonsoft.Json.Serialization;
using UniBot.Receiver.EventReceiver.Notice;

namespace UniBot.Utils
{
    internal static class JsonConvertTool
    {
        internal class LowercaseStringEnumConverter : StringEnumConverter
        {
            public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
            {
                string enumString = (string)reader.Value!;
                var members = objectType.GetMembers();
                var unknow = members.FirstOrDefault(x => x.MemberType == MemberTypes.Field && x.Name.Contains("Unknown"));
                if (enumString.Contains('_')) enumString = enumString.Replace("_", "");
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
                        return Enum.Parse(objectType, unknow.Name);
                    else
                    {
                        var def = members.FirstOrDefault(x => x.MemberType == MemberTypes.Field && x.Name != "value__");
                        return Enum.Parse(objectType, def!.Name);
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
        private static readonly List<EventReceiver> MetaEventReceiverBases = CreateInstance<EventReceiver>("UniBot.Receiver.EventReceiver.Meta");
        private static readonly List<EventReceiver> NoticeEventReceiverBases = CreateInstance<EventReceiver>("UniBot.Receiver.EventReceiver.Notice");
        private static readonly List<EventReceiver> RequestEventReceiverBases = CreateInstance<EventReceiver>("UniBot.Receiver.EventReceiver.Request");

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
                            msg.Connect = conf;
                            //var tempData = ((JObject)msg.Data!).ToString()!;
                            //msg.Data = null;
                            //msg.Data = JsonConvert.DeserializeObject(tempData, bodyDll);
                            break;
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine(data);
                throw;
            }
        }

        /// <summary>
        /// 接收事件处理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static EventReceiver? MetaEventReceiverHandel(string data, Connect conf)
        {
            try
            {
                var raw = JsonConvert.DeserializeObject<EventReceiver>(data);
                if (raw == null) return null;
                raw!.OriginalData = JObject.Parse(data);
                Type type = raw.GetType();
                foreach (var messageReceiver in MetaEventReceiverBases)
                {
                    if (messageReceiver == null) continue;
                    if (messageReceiver.MetaEventType == raw.MetaEventType)
                    {
                        type = messageReceiver.GetType();
                        break;
                    }
                }
                if (JsonConvert.DeserializeObject(data, type) is not EventReceiver message) return null;
                message.OriginalData = JObject.Parse(data);
                message.Connect = conf;
                return message;
            }
            catch (Exception)
            {
                Console.WriteLine(data);
                throw;
            }
        }

        /// <summary>
        /// 接收事件处理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static EventReceiver? RequestEventReceiverHandel(string data, Connect conf)
        {
            try
            {
                var raw = JsonConvert.DeserializeObject<EventReceiver>(data);
                if (raw == null) return null;
                raw!.OriginalData = JObject.Parse(data);
                Type type = raw.GetType();
                foreach (var messageReceiver in RequestEventReceiverBases)
                {
                    if (messageReceiver == null) continue;
                    if (messageReceiver.RequestEventType == raw.RequestEventType)
                    {
                        type = messageReceiver.GetType();
                        break;
                    }
                }
                if (JsonConvert.DeserializeObject(data, type) is not EventReceiver message) return null;
                message.OriginalData = JObject.Parse(data);
                message.Connect = conf;
                return message;
            }
            catch (Exception)
            {
                Console.WriteLine(data);
                throw;
            }
        }

        /// <summary>
        /// 接收事件处理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static EventReceiver? NoticeEventReceiverHandel(string data, Connect conf)
        {
            try
            {
                var raw = JsonConvert.DeserializeObject<EventReceiver>(data);
                if (raw == null) return null;
                raw!.OriginalData = JObject.Parse(data);
                Type type = raw.GetType();
                foreach (var messageReceiver in NoticeEventReceiverBases)
                {
                    if (messageReceiver == null) continue;
                    if (messageReceiver.NoticeEventType == raw.NoticeEventType)
                    {
                        type = messageReceiver.GetType();
                        break;
                    }
                }
                if (JsonConvert.DeserializeObject(data, type) is not EventReceiver message) return null;
                message.OriginalData = JObject.Parse(data);
                message.Connect = conf;
                return message;
            }
            catch (Exception)
            {
                Console.WriteLine(data);
                throw;
            }
        }

        /// <summary>
        /// 接收消息处理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static MessageReceiver? MessageReceiverHandel(string data, Connect conf)
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
                    {
                        type = messageReceiver.GetType();
                        break;
                    }
                }
                if (JsonConvert.DeserializeObject(data, type) is not MessageReceiver message) return null;
                message.OriginalData = JObject.Parse(data);
                message.Connect = conf;
                MessageHandel(message, conf);
                return message;
            }
            catch (Exception)
            {
                Console.WriteLine(data);
                throw;
            }
        }

        internal static string ToLowJsonStr(this object obj)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            return JsonConvert.SerializeObject(obj, settings);
        }
    }
}
