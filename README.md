# ShamrockCore.NET
注：目前还在测试阶段，可能会有bug，欢迎大家使用反馈，发现bug会快速修复。
## 简介
- 基于.NET 6开发，支持多平台。
- 是[OpenShamrock](https://github.com/whitechi73/OpenShamrock)在C#上的实现，理论支持基于onebot协议的机器人框架（OpenShamrock独有API除外，例如获取设备电池信息。）。
- 目录结构：
  - ShamrockCore-主程序
  - ShamrockCore.Test-测试程序
- 如果此项目对你有用，不妨给它点个Star，如果发现问题或者有不够完善的地方，欢迎大家提交PR和Issues。
## 快速开始
### 安装
- nuget安装下面三个库：ShamrockCore、Manganese和System.Reactive.Linq
### 开始
<details>
  <summary>名称空间引用</summary>
  
```cs
using Manganese.Text;
using ShamrockCore.Reciver;
using ShamrockCore.Reciver.Events;
using ShamrockCore.Reciver.MsgChain;
using ShamrockCore.Reciver.Receivers;
using ShamrockCore.Utils;
using System.Reactive.Linq;
```
</details>

初始化和启动：
```cs
var config = new ConnectConfig("Host", websocket_port, http_port, "token");
using Bot bot = new(config);
await bot.Start();
```
bot常用接口：

```cs
var friends = bot.Friends;//好友列表
var groups = bot.Groups;//群列表
var LoginInfo = bot.LoginInfo;//登录用户信息
var Battery = bot.Battery;//手机电池信息
var StartTime = bot.StartTime;//shamrock启动时间
```
websocket断开事件：
```cs
bot.DisconnectionHappened.Subscribe(e =>
{
    Console.WriteLine("webscoket断开连接：" + e);
});
```
处理消息：
```cs
bot.MessageReceived.OfType<GroupReceiver>().Subscribe(async msg =>
{
    foreach (var item in msg.Message)
    {
        if (item.Type == Data.Model.MessageType.Text)
            var textMessage = item.ConvertTo<TextMessage>();
        if (item.Type == Data.Model.MessageType.Image)
            var imageMessage = item.ConvertTo<ImageMessage>();
    }
    var msgStr = msg.Message.GetPlainText();
    await Console.Out.WriteLineAsync("好友消息：" + msg.ToJsonString());
    //发送消息，被动。下面有主动的方法
    msg.SendMessageAsync("太好辣，我收到消息辣。");
});
bot.MessageReceived.OfType<FriendReceiver>().Subscribe(async msg =>
{
    await Console.Out.WriteLineAsync("好友消息：" + msg.ToJsonString());
});
```
处理事件：
```cs
  bot.EventReceived.OfType<FriendAddEvent>().Subscribe(async msg =>
{
    Console.WriteLine("好友请求事件：" + msg.ToJsonString());
    await msg.Agree("好友备注");
    await msg.Reject();
});
bot.EventReceived.OfType<GroupIncreaseEvent>().Subscribe(msg =>
{
    Console.WriteLine("群成员增加事件：" + msg.ToJsonString());
});
```
未知消息：
```cs
  bot.UnknownMessageReceived.Subscribe(msg =>
{
    Console.WriteLine("未知消息：" + msg);
});
```
发送消息：
消息管理器是静态类，但是必须初始化bot后才可以用。
```cs
await MessageManager.SendGroupMsgAsync(111, "发送群消息");
await MessageManager.SendPrivateMsgAsync(111, "发送私聊消息");
var message = new MessageChain()
{
    new TextMessage("群消息"),
    new ImageMessage(url:"http://localhost/test.png")
};
await MessageManager.SendGroupMsgAsync(111, message);
var msgBuilder = new MessageChainBuilder().Text("私聊消息").Video("/Download/test.mp4");
message = msgBuilder.Build();
await MessageManager.SendPrivateMsgAsync(111, message);
```
阻塞线程：
```cs
while (true)
{
    Thread.Sleep(10);//建议加上，如果单纯死循环的话，最导致cpu占用飙高。
}
```
## 反馈，交流与讨论
- 方式一：仓库提交issue；
- 方式二：🐧群：327443854。
