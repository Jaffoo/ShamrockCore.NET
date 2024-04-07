namespace UniBot.Model
{
    /// <summary>
    /// 请求响应类型
    /// </summary>
    internal record ApiResult
    {
        /// <summary>
        /// 状态，ok 为成功|failed 为失败
        /// </summary>
        public string Status { get; set; } = "";

        /// <summary>
        /// 返回码，0 为成功，非 0 为失败
        /// </summary>
        public int Retcode { get; set; }

        /// <summary>
        /// 错误信息，仅在 API 调用失败时出现
        /// </summary>
        public string Message { get; set; } = "";

        /// <summary>
        /// 数据
        /// </summary>
        public string? Data { get; set; }
    }
}
