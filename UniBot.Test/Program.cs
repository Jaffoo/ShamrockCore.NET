using System.Reactive.Linq;
using TBC.CommonLib;
using UniBot.Receiver;
using UniBot.Receiver.EventReceiver.Notice;
using UnifyBot;
using UnifyBot.Model;
using UnifyBot.Receiver.EventReceiver;
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

            bot.MessageReceived.OfType<MessageReceiver>().Subscribe(async msg =>
            {
                Console.WriteLine(msg.OriginalData.ToString());
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
