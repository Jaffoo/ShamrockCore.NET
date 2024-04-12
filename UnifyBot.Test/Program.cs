using System.Reactive.Linq;
using TBC.CommonLib;
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
            Connect connect = new("localhost1", 3001, 3000);
            Bot bot = new(connect);
            await bot.StartAsync();
            
          
            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }
}
