using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using Mzl.DomainModel.Token;
using Mzl.Framework.Base;

namespace Mzl.IApplication.Common
{
    public interface IAuthorizationApplication : IBaseApplication
    {
        /// <summary>
        /// Token信息
        /// </summary>
        TokenResultModel TokenResult { get; }

        /// <summary>
        /// 授权检查
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        bool DoAuthorization(HttpActionContext actionContext);
    }
}
