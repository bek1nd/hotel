using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mzl.IApplication.Common;
using System.Web.Http.Controllers;
using System.Web.Http;
using Mzl.IBLL.Token;
using Mzl.DomainModel.Token;
using Mzl.DomainModel.Enum;

namespace Mzl.Application.Common
{
    public class AuthorizationApplication : IAuthorizationApplication
    {
        private readonly ICheckTokenServiceBll _checkTokenServiceBll;

        public AuthorizationApplication(ICheckTokenServiceBll checkTokenServiceBll)
        {
            _checkTokenServiceBll = checkTokenServiceBll;
        }

        public TokenResultModel TokenResult { private set;get; }

        public bool DoAuthorization(HttpActionContext actionContext)
        {
            //匿名属性直接通过验证
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Count != 0
                ||
                actionContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true)
                    .Count != 0)
            {
                string url = actionContext.Request.RequestUri.AbsoluteUri;
                //只要是匿名访问的，都统一设置一个Token
                actionContext.Request.Headers.Remove("MojoryToken");
                actionContext.Request.Headers.Add("MojoryToken", "AllowAnonymous_" + url);
                return true;
            }

            TokenResultModel resultModel = _checkTokenServiceBll.CheckToken(actionContext.Request);
            TokenResult = resultModel;
            if (resultModel.Code == TokenResultEnum.Allow) //允许访问
            {
                actionContext.Request.Headers.Add("Cid", resultModel.Cid.ToString());
                return true;
            }

            if (resultModel.Code == TokenResultEnum.Initial)
            {
                var actionName = actionContext.Request.GetActionDescriptor().ActionName;
                if (actionName == "MojoryLogin")
                {
                    //重写head中的MojoryToken值
                    actionContext.Request.Headers.Remove("MojoryToken");
                    actionContext.Request.Headers.Add("MojoryToken", resultModel.Token);
                    return true;
                }
            }
            return false;
        }
    }
}
