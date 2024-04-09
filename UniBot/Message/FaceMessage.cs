using UniBot.Model;

namespace UniBot.Message
{
    /// <summary>
    /// 表情消息
    /// </summary>
    public class FaceMessage : MessageBase
    {
        public override Messages Type => Messages.Face;

        public FaceMessage() { }
        public FaceMessage(int id)
        {
            base.Data = new Body()
            {
                Id = id
            };
        }

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
            /// <summary>
            /// 表情id
            /// </summary>
            public int Id { get; set; }
        }
    }
}
