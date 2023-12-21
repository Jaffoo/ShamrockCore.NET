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
            var config = new ConnectConfig("154.12.93.103", 7100, 7200, "523366");
            Bot bot = new(config);
            await bot.Start();
            await Console.Out.WriteLineAsync("Open");
            bot.DisconnectionHappened.Subscribe(e =>
            {
                Console.WriteLine("webscoket断开连接：" + e);
            });

            #region 消息测试
            bot.MessageReceived.OfType<GroupReceiver>().Subscribe(async msg =>
            {
                foreach (var item in msg.Message)
                {
                    if (item.Type == Data.Model.MessageType.Text)
                    {
                        var text = item.ConvertTo<TextMessage>();
                        await Console.Out.WriteLineAsync(text.Data.Text);
                    }
                    if (item.Type == Data.Model.MessageType.Image)
                    {
                        var text = item.ConvertTo<ImageMessage>();
                        await Console.Out.WriteLineAsync(text.Data.Url);
                    }
                }
                var msgStr = msg.Message.GetPlainText();
                if (msgStr == "你好")
                {
                    await msg.SendMessageAsync("你也好");
                }
            });
            bot.MessageReceived.OfType<FriendReceiver>().Subscribe(async msg =>
            {
                Console.WriteLine("好友消息：" + msg.ToJsonString());
            });
            #endregion

            #region 事件测试
            bot.EventReceived.OfType<FriendAddEvent>().Subscribe(async msg =>
            {
                Console.WriteLine("好友请求事件：" + msg.ToJsonString());
                await msg.Agree("你是谁？");
            });
            bot.EventReceived.OfType<GroupIncreaseEvent>().Subscribe(msg =>
            {
                Console.WriteLine("群成员增加事件：" + msg.ToJsonString());
            });
            bot.EventReceived.OfType<GroupDecreaseEvent>().Subscribe(msg =>
            {
                Console.WriteLine("群成员减少事件：" + msg.ToJsonString());
            });
            bot.UnknownMessageReceived.Subscribe(msg =>
            {
                Console.WriteLine("未知消息：" + msg);
            });
            #endregion

            #region 接口测试
            //System.Console.WriteLine(bot.Groups.ToJsonString());
            #endregion

            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }
}
