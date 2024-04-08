using System.Reactive.Linq;
using Newtonsoft.Json;
using TBC.CommonLib;
using UniBot;
using UniBot.Model;
using UniBot.Receiver;
using UniBot.Receiver.EventReceiver;
using UniBot.Receiver.MessageReceiver;

namespace UniBot.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Connect connect = new("localhost", 3001, 3000);
            Bot bot = new(connect);
            await bot.StartAsync();
            var friends = bot.Friends;
            Console.WriteLine(JsonConvert.SerializeObject(friends));
            bot.MessageReceived.OfType<MessageReceiverBase>().Subscribe(async msg =>
            {
                if (msg.PostType == PostType.Message)
                {
                    var msg1 = msg as MessageReceiver;
                    if (msg1?.MessageType == MessageType.Group)
                    {
                        msg1 = msg1 as GroupReceiver;
                        await Console.Out.WriteLineAsync("群消息：" + msg1?.ToJsonStr());
                    }
                    if (msg1?.MessageType == MessageType.Private)
                    {
                        msg1 = msg1 as PrivateReceiver;
                        await Console.Out.WriteLineAsync("群消息：" + msg1?.ToJsonStr());
                    }
                }
                if (msg.PostType == PostType.Notice)
                {
                    var msg1 =msg as EventReceiver;
                    if (msg1?.EventType == EventType.GroupIncrease)
                    {
                        msg1 = msg1 as GroupMemberIncrease; 
                        await Console.Out.WriteLineAsync("群成员增加：" + msg1?.ToJsonStr());
                    }
                    if (msg1?.EventType == EventType.GroupDecrease)
                    {
                        msg1 = msg1 as GroupMemberDecrease; 
                        await Console.Out.WriteLineAsync("群成员减少：" + msg1?.ToJsonStr());
                    }
                }
            });
            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }
}
