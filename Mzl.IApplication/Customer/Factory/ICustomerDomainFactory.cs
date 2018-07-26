using Mzl.IApplication.Base;
using Mzl.IApplication.Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Customer.Factory
{
    public interface ICustomerDomainFactory : IBaseDomainFactory<ICustomerDomain>
    {
        /// <summary>
        /// 创建获取乘机人/乘车人信息的Domain对象
        /// </summary>
        /// <returns></returns>
        ICustomerDomain CreatePassengerInfoDomainObj();
        /// <summary>
        /// 创建验证客户登录的对象
        /// </summary>
        /// <returns></returns>
        ICustomerDomain CreateVerifyCustomerDomainObj();
        /// <summary>
        /// 创建查询行程视图的对象
        /// </summary>
        /// <returns></returns>
        ICustomerDomain CreateQueryTravelViewDomainObj();
    }
}
