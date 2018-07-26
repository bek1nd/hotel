using Mzl.Common.Exceptions;
using Mzl.Common.LogHelper;
using Mzl.UIModel.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Filters;
using Mzl.Common.EnumHelper;

namespace Mzl.Mojory.WebApi.Config
{
    /// <summary>
    /// 自定义异常捕获Attribute
    /// </summary>
    public class MojoryExceptionFilterAttribute: ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            IEnumerable<string> tokenobj = context.Request.Headers.GetValues("MojoryToken");
            string token = tokenobj.First();
            ResponseBaseViewModel<string> responseView = new ResponseBaseViewModel<string>();
            string stackTrace = string.Empty;
            if (context.Exception is MojoryException && context.Exception != null)
            {
                MojoryException returnEx = context.Exception as MojoryException;

                responseView.Flag = new ResponseCodeViewModel()
                {
                    Code = (int) returnEx.Code,
                    Message =
                        string.IsNullOrEmpty(returnEx.CodeMessage)
                            ? returnEx.Code.ToDescription()
                            : returnEx.CodeMessage,
                    MojoryToken = token
                };
            }
            else
            {
                responseView.Flag = new ResponseCodeViewModel()
                {
                    Code = (int) MojoryApiResponseCode.Error,
                    Message = context.Exception.Message,
                    MojoryToken = token
                };

                stackTrace = context.Exception.StackTrace;
            }

            LogHelper.WriteLog("Api异常信息:" + Json.Encode(responseView) + "||||||报错路径:" + stackTrace, "MojoryException");
            context.Response = new HttpResponseMessage() { Content = new StringContent(Json.Encode(responseView), Encoding.UTF8, "application/json") };
            base.OnException(context);
        }
    }
}