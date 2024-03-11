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
            #region 主动ws
            var config = new ConnectConfig("192.168.2.10", 5800, 5700, "token");
            using Bot bot = new(config);
            Console.WriteLine(config.HttpUrl);
            Console.WriteLine(config.WsUrl);
            Console.WriteLine(config.Token);
            #endregion
            #region 被动ws
            var reverseConfig = new ConnectConfig("192.168.2.10", 5800, 5700, "123", true);
            using Bot bot1 = new(reverseConfig);
            Console.WriteLine(reverseConfig.HttpUrl);
            Console.WriteLine(reverseConfig.ReverseWsUrl);
            Console.WriteLine(reverseConfig.Token);
            #endregion
            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();
            await bot.Start();
            await Console.Out.WriteLineAsync("Open");
            bot.DisconnectionHappened.Subscribe(e =>
            {
                Console.WriteLine("websocket断开连接：" + e);
            });

            #region 消息测试
            bot.MessageReceived.OfType<MessageReceiverBase>().Subscribe(async msg =>
            {
                if (msg.Type == PostMessageType.Group)
                {
                    var msg1 = msg as GroupReceiver;
                    await Console.Out.WriteLineAsync("群消息：" + msg1.ToJsonString());
                }
                if (msg.Type == PostMessageType.Friend)
                {
                    var msg1 = msg as FriendReceiver;
                    await Console.Out.WriteLineAsync("好友消息：" + msg1.ToJsonString());
                }
            });
            bot.MessageReceived.OfType<GroupReceiver>().Subscribe(async msg =>
            {
                await Console.Out.WriteLineAsync("群消息：" + msg.ToJsonString());
                if (msg.Message.GetPlainText() == "发送图片")
                {
                    var msbc = new MessageChainBuilder().ImageByUrl("https://gitee.com/jaffoo/ParkerBot/raw/master/images/star.png").Build();
                    await msg.SendGroupMsgAsync(msbc);
                }
            });
            bot.MessageReceived.OfType<FriendReceiver>().Subscribe(async msg =>
            {
                await Console.Out.WriteLineAsync("好友消息：" + msg.ToJsonString());
            });
            bot.MessageReceived.OfType<GuildReceiver>().Subscribe(async msg =>
            {
                await Console.Out.WriteLineAsync("频道消息：" + msg.ToJsonString());

            });
            #endregion

            #region 事件测试
            bot.EventReceived.OfType<EventBase>().Subscribe(msg =>
            {
                if (msg.EventType == PostEventType.Friend)
                {
                    if (msg is not FriendAddEvent req) return;
                    Console.WriteLine("好友请求事件：" + msg.ToJsonString());
                }
            });
            bot.EventReceived.OfType<FriendAddEvent>().Subscribe(msg =>
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
