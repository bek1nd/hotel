using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Mzl.Mojory.WebApi.Config.MojoryDelegatingHandler
{
    /// <summary>
    /// 自定义HttpMessageHandler，用于注册api消息管道中
    /// </summary>
    public class HttpMethodChangeHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method == HttpMethod.Options)
            {
                //request.Method = HttpMethod.Post;
                return Do();
            }
            Task<HttpResponseMessage> responseMessage = base.SendAsync(request, cancellationToken);

            return responseMessage;
        }

        private async Task<HttpResponseMessage> Do()
        {
            HttpResponseMessage message = new HttpResponseMessage();
            await new TaskFactory().StartNew(() =>
            {
                message = new HttpResponseMessage(HttpStatusCode.OK);
            });
            return message;
        }
    }

}