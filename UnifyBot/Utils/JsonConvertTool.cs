using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Reflection;
using Newtonsoft.Json.Converters;
using UnifyBot.Message;
using UnifyBot.Message.Chain;
using UnifyBot.Receiver.MessageReceiver;
using UnifyBot.Model;
using UnifyBot.Receiver.EventReceiver;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace UnifyBot.Utils
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
                            return Enum.Parse(objectType, unknow.Name);
                        else
                        {
                            var def = members.FirstOrDefault(x => x.MemberType == MemberTypes.Field && x.Name != "value__");
                            return Enum.Parse(objectType, def!.Name);
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

        private static List<T> CreateInstance<T>(string @namespace, string where = "") where T : class
        {
            return Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.FullName != null)
            .Where(x => x.FullName!.Contains(@namespace))
            .Where(x => x.Name.Contains(where))
            .Where(x => !x.IsAbstract)
            .Select(x =>
            {
                if (Activator.CreateInstance(x) is T instance)
                {
                    return instance;
                }
                return null;
            })
            .Where(i => i != null).ToList()!;
        }

        private static readonly List<MessageBase> MessageBases = CreateInstance<MessageBase>("UnifyBot.Message", "Message");
        private static readonly List<MessageReceiver> MessageReceiverBases = CreateInstance<MessageReceiver>("UnifyBot.Receiver.MessageReceiver");
        private static readonly List<EventReceiver> MetaEventReceiverBases = CreateInstance<EventReceiver>("UnifyBot.Receiver.EventReceiver.Meta");
        private static readonly List<EventReceiver> NoticeEventReceiverBases = CreateInstance<EventReceiver>("UnifyBot.Receiver.EventReceiver.Notice");
        private static readonly List<EventReceiver> RequestEventReceiverBases = CreateInstance<EventReceiver>("UnifyBot.Receiver.EventReceiver.Request");

        /// <summary>
        /// 消息段处理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static void MessageHandel(MessageReceiver data)
        {
            try
            {
                data.Message = JsonConvert.DeserializeObject<MessageChain>(data.OriginalData!["message"]!.ToString()) ?? throw new InvalidDataException("消息段解析失败");
                foreach (var item in MessageBases)
                {
                    Type dllType = item.GetType();
                    if (dllType.Name == "MessageBase") continue;
                    var bodyDll = dllType.GetNestedType("Body")!;
                    for (int i = 0; i < data.Message.Count; i++)
                    {
                        var msg = data.Message![i];
                        if (msg.Type == item.Type)
                        {
                            if (msg == null) continue;
                            var msgStr = msg.ToJsonStr();
                            if (!(JsonConvert.DeserializeObject(msgStr, dllType) is MessageBase mb)) throw new Exception();
                            data.Message![i] = mb;
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
                if (!(JsonConvert.DeserializeObject(data, type) is EventReceiver message)) return null;
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
                if (!(JsonConvert.DeserializeObject(data, type) is EventReceiver message)) return null;
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
                if (!(JsonConvert.DeserializeObject(data, type) is EventReceiver message)) return null;
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
                        if (type.Name.Contains("MessageReceiver"))
                            continue;
                        break;
                    }
                }
                if (!(JsonConvert.DeserializeObject(data, type) is MessageReceiver message)) return null;
                message.OriginalData = JObject.Parse(data);
                message.Connect = conf;
                MessageHandel(message);
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
