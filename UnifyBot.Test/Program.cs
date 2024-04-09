using UnifyBot;
using UnifyBot.Message;
using UnifyBot.Message.Chain;
using UnifyBot.Model;

namespace UniBot.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Connect connect = new("localhost", 3001, 3000);
            Bot bot = new(connect);
            await bot.StartAsync();
            MessageChain msg = new()
            {
                new TextMessage("1"),
                new ImageByUrl("https://www.zink.asia/upload/h3468-01.jpg"),
                new TextMessage("3"),
            };
            await bot.SendPrivateForwardMessage(1737678289, msg);
            await bot.SendGroupForwardMessage(341630390, msg);
            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }
}
