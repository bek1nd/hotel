using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.Login;

namespace Mzl.IApplication.Customer
{
    public interface ICustomerLoginApplication : IBaseApplication
    {
        /// <summary>
        /// 差旅网站客户登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        LoginResponseViewModel MojoryLogin(LoginRequestViewModel request);
        /// <summary>
        /// 添加设备Id信息
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="clientId"></param>
        /// <param name="clientType"></param>
        /// <returns></returns>
        int AddAppClientId(int cid, string clientId, string clientType);
    }
}
