using System.Reactive.Linq;
using TBC.CommonLib;
using UniBot.Model;
using UniBot.Receiver;
using UniBot.Receiver.EventReceiver;
using UniBot.Receiver.EventReceiver.Notice;
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
            bot.Receiver.OfType<MessageReceiverBase>().Subscribe(async msg =>
            {
                if (msg.OriginalData.ToString().Contains("notice"))
                {
                    Console.WriteLine("111");
                }
                if (msg.PostType == PostType.Message)
                {
                    var msg1 = msg as MessageReceiver;
                    if (msg1?.MessageType == MessageType.Group)
                    {
                        var msg2 = msg1 as GroupReceiver;
                        if (msg2.Group.GroupName.Contains("机器人测试"))
                        {
                           
                        }
                        await Console.Out.WriteLineAsync("群消息：" + msg1?.ToJsonStr());
                    }
                    if (msg1?.MessageType == MessageType.Private)
                    {
                        msg1 = msg1 as PrivateReceiver;
                        await Console.Out.WriteLineAsync("群消息：" + msg1?.ToJsonStr());
                    }
                }
                else if (msg.PostType == PostType.Notice)
                {
                    var msg1 = msg as EventReceiver;
                    if (msg1?.NoticeEventType == NoticeType.GroupIncrease)
                    {
                        var msg2 = msg1 as GroupMemberIncrease;
                        await Console.Out.WriteLineAsync("群成员增加：" + msg2?.ToJsonStr());
                    }
                    if (msg1?.NoticeEventType == NoticeType.GroupDecrease)
                    {
                        var msg3 = msg1 as GroupMemberDecrease;
                        await Console.Out.WriteLineAsync("群成员减少：" + msg3?.ToJsonStr());
                    }
                    if (msg1?.NoticeEventType == NoticeType.GroupRecall)
                    {
                        var msg4 = msg1 as GroupMsgRecall;
                        await Console.Out.WriteLineAsync("群消息撤回：" + msg4?.ToJsonStr());
                    }
                }
            });
            bot.EventReceived.OfType<EventReceiver>().Subscribe(async msg =>
            {
                Console.WriteLine(msg.OriginalData.ToString());
            });
            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }
}
