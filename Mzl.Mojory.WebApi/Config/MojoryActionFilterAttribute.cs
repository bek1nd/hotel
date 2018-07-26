using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Mzl.Common.EnumHelper;
using Mzl.Common.LogHelper;
using Mzl.Common.PostHelper;
using Mzl.Common.ConfigHelper;

namespace Mzl.Mojory.WebApi.Config
{
    /// <summary>
    /// 请求
    /// </summary>
    public class MojoryActionFilterAttribute: ActionFilterAttribute
    {
        /// <summary>
        /// 请求之前
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //记录请求信息 request
            string requestUrl = actionContext.Request.RequestUri.ToString();
            IDictionary<string, object> routeDictionary = actionContext.RequestContext.RouteData.Values;
            string controller = routeDictionary["controller"].ToString();
            string action = routeDictionary["action"].ToString();
            string fromHost = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            string requestStr =string.Empty;
            if (actionContext.ActionArguments != null && actionContext.ActionArguments.Count > 0)
            {
                if (actionContext.ActionArguments.Keys.Contains("request"))
                {
                    requestStr = Json.Encode(actionContext.ActionArguments["request"]);
                }
            }
            string requestHeader = actionContext.Request.Headers.ToString();
            string logInfo = string.Format("api请求地址:{0};\r\t请求内容:{1};\r\t请求header:{2}\r\t来自地址:{3}\r\t", requestUrl, requestStr, requestHeader, fromHost);

            if (controller.ToLower() == "Customer".ToLower() && action.ToLower() == "MojoryLogin".ToLower())
            {
                LogHelper.WriteLog(logInfo, "MojoryApiLogin");
            }
            else
            {
                LogHelper.WriteLog(logInfo, "MojoryApiRequest");
            }


            #region 验证请求实体是否合法
            bool isNeedNotValid = false;//是否不需要验证
            List<string> blackList = AppSettingsHelper.GetAppSettings(AppSettingsEnum.ValidBlackList).Split(',').ToList();
            foreach (var black in blackList)
            {
                List< string> blackInfo =black.Split('|').ToList();
                if (blackInfo[0] == controller)
                {
                    if (blackInfo[1] == "*")
                    {
                        isNeedNotValid = true;
                        break;
                    }
                    if (blackInfo[1].Contains(action))
                    {
                        isNeedNotValid = true;
                        break;
                    }
                }
            }

            //验证请求实体是否合法
            if (!isNeedNotValid)
            {
                if (!actionContext.ModelState.IsValid)
                {
                    ResponseBaseViewModel<string> responseView = new ResponseBaseViewModel<string>();
                    var tokenobj = actionContext.Request.Headers.GetValues("MojoryToken");
                    string token = string.Empty;
                    if (tokenobj != null)
                    {
                        token = tokenobj.First();
                    }
                    string keyStr = string.Empty;
                    foreach (var key in actionContext.ModelState.Keys)
                    {
                        keyStr += "," + key;
                    }

                    responseView.Flag = new ResponseCodeViewModel()
                    {
                        Code = (int)MojoryApiResponseCode.NoValid,
                        Message = MojoryApiResponseCode.NoValid.ToDescription()+ keyStr,
                        MojoryToken = token
                    };

                    actionContext.Response = new HttpResponseMessage()
                    {
                        Content = new StringContent(Json.Encode(responseView), Encoding.UTF8, "application/json")
                    };

                    base.OnActionExecuting(actionContext);
                }
            }
            #endregion
        }
        
    }
}