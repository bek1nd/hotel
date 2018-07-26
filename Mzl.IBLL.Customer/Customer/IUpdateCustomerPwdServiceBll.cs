using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.Customer
{
    /// <summary>
    /// 修改客户密码
    /// </summary>
    public interface IUpdateCustomerPwdServiceBll : IBaseServiceBll
    {
        bool UpdateCustomerPwd(UpdateCustomerPwdModel query);
    }
}
