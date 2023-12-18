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

    public enum Ball
    {
        /// <summary>
        /// 正中
        /// </summary>
        ZZ = 1,

        /// <summary>
        /// 擦边中
        /// </summary>
        CBZ = 2,

        /// <summary>
        /// 卡框
        /// </summary>
        KK = 3,

        /// <summary>
        /// 擦边没中
        /// </summary>
        CBMZ = 4,

        /// <summary>
        /// 没中
        /// </summary>
        MZ = 5
    }

    public enum Rps
    {
        /// <summary>
        /// 布
        /// </summary>
        B = 1,

        /// <summary>
        /// 见到
        /// </summary>
        JD = 2,

        /// <summary>
        /// 石头
        /// </summary>
        ST = 3,
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