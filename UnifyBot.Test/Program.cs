using System.Reactive.Linq;
using UnifyBot;
using UnifyBot.Message;
using UnifyBot.Message.Chain;
using UnifyBot.Model;
using UnifyBot.Receiver.MessageReceiver;

namespace UniBot.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Connect connect = new("localhost", 3001, 3000);
            Bot bot = new(connect);
            await bot.StartAsync();
            bot.MessageReceived.OfType<MessageReceiver>()
                .Subscribe(async msg => Console.WriteLine(msg.OriginalData.ToString()));
            await new MessageChain()
            {
            new NodeMessage(1615842006,"测试","字符串")
            }
            .SendGroup(bot, 341630390);

            await new MessageChain()
            {
            new NodeMessage(1615842006,"测试",new MessageChain() { new TextMessage("消息段") })
            }
           .SendGroup(bot, 341630390);

            await new MessageChainBuild().Node(1615842006, "测试", new MessageChain() { new TextMessage("我测你码") }).SendGroup(bot, 341630390);
            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }
}
