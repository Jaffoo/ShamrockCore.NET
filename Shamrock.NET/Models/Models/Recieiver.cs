using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shamrock.NET.Models
{
    public record RecieiverBase : IEquatable<RecieiverBase>
    {
    }
    public record GroupMessageReceiver : RecieiverBase, IEquatable<GroupMessageReceiver>
    {
    }
    public record FriendMessageReceiver : RecieiverBase, IEquatable<FriendMessageReceiver>
    {
    }
    public record TempMessageReceiver : RecieiverBase, IEquatable<TempMessageReceiver>
    {
    }
}
