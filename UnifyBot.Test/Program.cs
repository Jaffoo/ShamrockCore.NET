using System.Reactive.Linq;
using TBC.CommonLib;
using UnifyBot;
using UnifyBot.Model;
using UnifyBot.Receiver;
using UnifyBot.Receiver.EventReceiver;
using UnifyBot.Receiver.EventReceiver.Notice;
using UnifyBot.Receiver.MessageReceiver;

namespace UniBot.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Connect connect = new("127.0.0.1", 3001, 3000);
            Bot bot = new(connect);
            await bot.StartAsync();
            #region 消息
            bot.MessageReceived.OfType<MessageReceiverBase>().Subscribe(x =>
            {
                //能接收到所有消息和事件
                Console.WriteLine(x.ToJsonStr());
            });
            bot.MessageReceived.OfType<MessageReceiver>().Subscribe(x =>
            {
                //只能接收到消息（所有类型）
                Console.WriteLine(x.ToJsonStr());
            });
            bot.MessageReceived.OfType<GroupReceiver>().Subscribe(x =>
            {
                //只能接收到群消息
                Console.WriteLine(x.ToJsonStr());
            });
            bot.MessageReceived.OfType<PrivateReceiver>().Subscribe(x =>
            {
                //只能接收到好友消息
                Console.WriteLine(x.ToJsonStr());

            });
            #endregion

            #region 事件
            bot.EventReceived.OfType<MessageReceiverBase>().Subscribe(x =>
            {
                //能接收到所有消息和事件
                Console.WriteLine(x.ToJsonStr());
            });
            bot.EventReceived.OfType<EventReceiver>().Subscribe(x =>
            {
                //只能接收到事件（所有类型）
                Console.WriteLine(x.ToJsonStr());
            });
            bot.EventReceived.OfType<FriendAdd>().Subscribe(x =>
            {
                //只能接收到特定事件（传入什么类型就是什么事件）
                Console.WriteLine(x.ToJsonStr());
            });
            #endregion
            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }
}
