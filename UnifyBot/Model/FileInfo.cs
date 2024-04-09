namespace UnifyBot.Model
{
    /// <summary>
    /// 文件
    /// </summary>
    public class FileInfoBase
    {
        /// <summary>
        /// 文件id
        /// </summary>
        public string File { get; set; } = "";
    }
    /// <summary>
    /// 文件能否发送
    /// </summary>
    public class FileCanSend
    {
        /// <summary>
        /// 文件能否发送
        /// </summary>
        public bool Yes { get; set; }
    }

    /// <summary>
    /// 文件
    /// </summary>
    public class FileInfo
    {
        /// <summary>
        /// 文件id
        /// </summary>
        public string Id { get; set; } = "";

        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// 文件大小
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// busid（目前不清楚有什么作用）
        /// </summary>
        public long Busid { get; set; }
    }
}
