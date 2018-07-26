using Microsoft.Practices.Unity;
using Mzl.Application.Token.Domain;
using Mzl.Application.Token.Factory;
using Mzl.Common.Ioc;
using Mzl.DomainModel.Enum;
using Mzl.DomainModel.Token;
using Mzl.IApplication.Common;
using Mzl.IApplication.Token.Domain;
using Mzl.IApplication.Token.Factory;
using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Mzl.Mojory.WebApi.Config
{
    /// <summary>
    /// Token权限验证
    /// </summary>
    public class TokenAuthentication : AuthorizeAttribute
    {
        /// <summary>
        /// 重写拦截层
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            IUnityContainer unityContainer = new IocHelper("AuthorizationApi").GetUnityContainer();
            IAuthorizationApplication  authorizationApplication= unityContainer.Resolve<IAuthorizationApplication>();

            bool flag=authorizationApplication.DoAuthorization(actionContext);
            var resultModel = authorizationApplication.TokenResult;
            if (flag)
            {
                IsAuthorized(actionContext);
                return;
            }
            ResponseBaseViewModel<string> responseView=new ResponseBaseViewModel<string>();
            responseView.Flag = new ResponseCodeViewModel()
            {
                Code = (int) resultModel.Code,
                Message = "",
                MojoryToken = resultModel.Token
            };

            actionContext.Response = new HttpResponseMessage
            {
                Content = new StringContent(Json.Encode(responseView), Encoding.UTF8, "application/json")
            };

           
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            base.IsAuthorized(actionContext);
            return true;
        }
    }
}