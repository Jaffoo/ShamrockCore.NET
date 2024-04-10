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
            Connect connect = new("localhost", 3001, 3000);
            Bot bot = new(connect);
            await bot.StartAsync();
            bot.MessageReceived.OfType<MessageReceiver>()
                .Subscribe(async msg =>
                {
                    foreach (var item in msg.Message)
                    {
                        if (item.Type == Messages.Text)
                        {
                            var text = item as TextMessage;
                            var ntext = (TextMessage)item;
                            Console.WriteLine("文本消息测试：" + text.Data.Text);
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
