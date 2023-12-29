using Manganese.Text;
using ShamrockCore.Reciver;
using ShamrockCore.Reciver.Events;
using ShamrockCore.Reciver.MsgChain;
using ShamrockCore.Reciver.Receivers;
using ShamrockCore.Utils;
using System.Reactive.Linq;

namespace ShamrockCore.Test
{
    internal class Program
    {
        static async Task Main()
        {
            var config = new ConnectConfig("IP", 1, 2, "token");
            using Bot bot = new(config);
            await bot.Start();
            await Console.Out.WriteLineAsync("Open");
            bot.DisconnectionHappened.Subscribe(e =>
            {
                Console.WriteLine("webscoket断开连接：" + e);
            });

            #region 消息测试
            bot.MessageReceived.OfType<GroupReceiver>().Subscribe(async msg =>
            {
                await Console.Out.WriteLineAsync("群消息：" + msg.ToJsonString());
            });
            bot.MessageReceived.OfType<FriendReceiver>().Subscribe(async msg =>
            {
                await Console.Out.WriteLineAsync("好友消息：" + msg.ToJsonString());
            });
            #endregion

            #region 事件测试
            //理论上，2个观察事件都会触发，第二个一定会触发，第一个待定，待测试实践。
            bot.EventReceived.OfType<EventBase>().Subscribe(async msg =>
            {
                if (msg.EventType == EventType.friend)
                {
                    var resq = msg as FriendAddEvent;
                    if (resq == null) return;
                    Console.WriteLine("好友请求事件：" + msg.ToJsonString());
                }
            });
            bot.EventReceived.OfType<FriendAddEvent>().Subscribe(async msg =>
            {
                Console.WriteLine("好友请求事件：" + msg.ToJsonString());
            });
            #endregion
            bot.UnknownMessageReceived.Subscribe(msg =>
            {
                Console.WriteLine("未知消息：" + msg);
            });
            #region 接口测试
            //System.Console.WriteLine(bot.FriendSysMsg.ToJsonString());
            #endregion
            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }
}
