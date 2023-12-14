using Flurl.Http;

namespace ShamrockCore.Utils
{
    /// <summary>
    /// 用户自定义错误处理
    /// </summary>
    public delegate void ErrorHandler(Exception ex);
    public static class HttpUtil
    {
        /// <summary>
        /// 用户自定义错误处理器
        /// </summary>
        public static ErrorHandler? HttpErrorHandler { get; set; }

        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="withToken">是否携带token</param>
        /// <returns></returns>
        public static async Task<string> GetAsync(string url, bool withToken = true)
        {
            try
            {
                var result = withToken
                    ? await url
                        .WithHeader("Authorization", $"Bearer {Bot.Instance!.Config.Token}")
                        .GetAsync()
                    : await url.GetAsync();

                var re = await result.GetStringAsync();
                return re;
            }
            catch (Exception e)
            {
                if (HttpErrorHandler != null)
                {
                    e.Data["method"] = "get";
                    e.Data["url"] = url;
                    HttpErrorHandler.Invoke(e); // 如果错误处理器不为 null，则调用
                }
                else
                    throw; // 否则，重新抛出异常
                return "";
            }
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="withToken">是否携带token</param>
        /// <returns></returns>
        public static async Task<string> PostAsync(string url, bool withToken = true)
        {
            try
            {
                var result = withToken
                    ? await url
                        .WithHeader("Authorization", $"Bearer {Bot.Instance!.Config.Token}")
                        .PostAsync()
                    : await url.PostAsync();

                var re = await result.GetStringAsync();
                return re;
            }
            catch (Exception e)
            {
                if (HttpErrorHandler != null)
                {
                    e.Data["method"] = "get";
                    e.Data["url"] = url;
                    HttpErrorHandler.Invoke(e); // 如果错误处理器不为 null，则调用
                }
                else
                    throw; // 否则，重新抛出异常
                return "";
            }
        }
    }
}
