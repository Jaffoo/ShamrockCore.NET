using Manganese.Text;
using ShamrockCore.Data.Model;
using ShamrockCore.Receiver;
using ShamrockCore.Receiver.Events;
using ShamrockCore.Receiver.MsgChain;
using ShamrockCore.Receiver.Receivers;
using ShamrockCore.Utils;
using System.Reactive.Linq;

namespace ShamrockCore.Test
{
    internal class Program
    {
        static async Task Main()
        {
            var config = new ConnectConfig("localhost", 3001, 3000);
            using Bot bot = new(config);
            await bot.Start();
            var g = bot.Groups.FirstOrDefault(x => x.Name.Contains("机器人测试"));
            await g.SendGroupMsgAsync("你好");
            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }
}
