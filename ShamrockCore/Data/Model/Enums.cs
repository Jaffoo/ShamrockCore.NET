using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 群内权限
    /// </summary>
    public enum Permissions
    {
        /// <summary>
        /// 群主
        /// </summary>
        [EnumMember(Value = "OWNER")]
        [Description("OWNER")]
        Owner,

        /// <summary>
        /// 管理员
        /// </summary>
        [EnumMember(Value = "ADMINISTRATOR")]
        [Description("ADMINISTRATOR")]
        Administrator,

        /// <summary>
        /// 群员
        /// </summary>
        [EnumMember(Value = "MEMBER")]
        [Description("MEMBER")]
        Member
    }

    public enum MessageType
    {
        At,
        Text,
        Face,
        Image,
        Json,
        Reply,
        Record,
        Video,
        Basketball,
        New_rps,
        New_dice,
        Poke,
        Touch,
        Music,
        Weather,
        Location,
        Share,
        Gift
    }
    public class LowercaseStringEnumConverter : StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is Enum)
            {
                string enumString = value!.ToString()!.ToLower();
                writer.WriteValue(enumString);
            }
            else
            {
                base.WriteJson(writer, value, serializer);
            }
        }
    }
}