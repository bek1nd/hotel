using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.IApplication.Customer
{
    /// <summary>
    /// 修改网站用户密码
    /// </summary>
    public interface IUpdateCustomerPwdApplication : IBaseApplication
    {
        /// <summary>
        /// 修改差旅网站用户密码
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        bool UpdateMojoryCustomerPwd(UpdateCustomerPwdRequestViewModel request);
    }
}
