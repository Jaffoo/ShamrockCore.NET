using Manganese.Text;
using Newtonsoft.Json;
using ShamrockCore.Reciver.Events;
using ShamrockCore.Reciver.Receivers;
using ShamrockCore.Utils;
using System.Reactive.Linq;

namespace ShamrockCore.Test
{
    internal class Program
    {
        static async Task Main()
        {
            var config = new ConnectConfig("154.12.93.103", 7100, 7200, "523366");
            Bot bot = new(config);
            await bot.Start();
            await Console.Out.WriteLineAsync("Open");
            bot.DisconnectionHappened.Subscribe(e =>
            {
                Console.WriteLine("webscoket断开连接：" + e);
            });
            bot.MessageReceived.OfType<GroupReceiver>().Subscribe(msg =>
            {
                msg.Message.GetPlainText();
                Console.WriteLine("群消息：" + msg.ToJsonString());
            });
            bot.MessageReceived.OfType<FriendReceiver>().Subscribe(msg =>
            {
                Console.WriteLine("好友消息：" + msg.ToJsonString());
            });
            bot.MessageReceived.OfType<FriendAddEvent>().Subscribe(msg =>
            {
                Console.WriteLine("好友请求事件：" + msg.ToJsonString());
            });
            bot.MessageReceived.OfType<GroupIncreaseEvent>().Subscribe(msg =>
            {
                Console.WriteLine("群成员增加事件：" + msg.ToJsonString());
            });
            bot.MessageReceived.OfType<GroupDecreaseEvent>().Subscribe(msg =>
            {
                Console.WriteLine("群成员减少事件：" + msg.ToJsonString());
            });
            bot.UnknownMessageReceived.Subscribe(msg =>
            {
                Console.WriteLine("未知消息：" + msg);
            });
            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }
}
