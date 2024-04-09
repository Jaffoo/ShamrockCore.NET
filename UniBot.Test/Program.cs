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
