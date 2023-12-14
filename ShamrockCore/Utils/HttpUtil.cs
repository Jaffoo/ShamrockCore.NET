using Flurl.Http;
using Manganese.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShamrockCore.Data.HttpAPI;

namespace ShamrockCore.Utils
{
    /// <summary>
    /// 请求响应
    /// </summary>
    public record Result
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
        public string Msg { get; set; } = "";

        /// <summary>
        ///  对错误信息的描述，仅在 API 调用失败时出现
        /// </summary>
        public string Wording { get; set; } = "";

        /// <summary>
        /// 用户自定义请求中的回显字段
        /// </summary>
        public string Echo { get; set; } = "";

        /// <summary>
        /// 数据
        /// </summary>
        public object? Data { get; set; }
    }

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
        public static async Task<Result?> GetAsync(string url, bool withToken = true)
        {
            try
            {
                var result = withToken
                    ? await url
                        .WithHeader("Authorization", $"Bearer {Bot.Instance!.Config.Token}")
                        .GetAsync()
                    : await url.GetAsync();

                var re = await result.GetJsonAsync<Result>();
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
                return null;
            }
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="url">提交内容</param>
        /// <param name="withToken">是否携带token</param>
        /// <returns></returns>
        public static async Task<Result?> PostAsync(string url, object body, bool withToken = true)
        {
            try
            {
                var result = withToken
                    ? await url
                        .WithHeader("Authorization", $"Bearer {Bot.Instance!.Config.Token}")
                        .PostAsync()
                    : await url.PostJsonAsync(body);

                var re = await result.GetJsonAsync<Result>();
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
                return null;
            }
        }

        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="withToken">是否携带token</param>
        /// <returns></returns>
        public static async Task<T?> GetAsync<T>(this HttpEndpoints endpoints, bool withToken = true)
        {
            var url = Bot.Instance!.Config.HttpUrl + endpoints.Description();
            try
            {
                var result = withToken
                    ? await url
                        .WithHeader("Authorization", $"Bearer {Bot.Instance!.Config.Token}")
                        .GetAsync()
                    : await url.GetAsync();
                var re = await result.GetJsonAsync<Result>();
                if (re.Status != "ok") throw new Exception("请求失败：" + re.Msg);
                if (re.Retcode != 0) throw new Exception("请求失败：" + re.Msg);
                if (re.Data == null) throw new InvalidDataException("数据请求错误");
                var dataStr = JsonConvert.SerializeObject(re.Data);
                var res = JsonConvert.DeserializeObject<T>(dataStr);
                return res;
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
                return default;
            }
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="url">提交内容</param>
        /// <param name="withToken">是否携带token</param>
        /// <returns></returns>
        public static async Task<T?> PostAsync<T>(this HttpEndpoints endpoints, object body, bool withToken = true)
        {
            var url = Bot.Instance!.Config.HttpUrl + endpoints.Description();
            try
            {
                var result = withToken
                    ? await url
                        .WithHeader("Authorization", $"Bearer {Bot.Instance!.Config.Token}")
                        .PostAsync()
                    : await url.PostJsonAsync(body);

                var re = await result.GetJsonAsync<Result>();
                if (re.Status != "ok") throw new Exception("请求失败：" + re.Msg);
                if (re.Retcode != 0) throw new Exception("请求失败：" + re.Msg);
                if (re.Data == null) throw new InvalidDataException("数据请求错误");
                var dataStr = JsonConvert.SerializeObject(re.Data);
                var res = JsonConvert.DeserializeObject<T>(dataStr);
                return res;
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
                return default;
            }
        }
    }
}
