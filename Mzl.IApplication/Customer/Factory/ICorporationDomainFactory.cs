using Mzl.IApplication.Base;
using Mzl.IApplication.Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Customer.Factory
{
    public interface ICorporationDomainFactory : IBaseDomainFactory<ICorporationDomain>
    {
        ICorporationDomain CreateDomainCostCenterObj();
        ICorporationDomain CreateDomainProjectNameObj();
        ICorporationDomain CreateDomainProjectNameAndCostCenterObj();

        /// <summary>
        /// 创建确认订单视图对象
        /// </summary>
        /// <returns></returns>
        ICorporationDomain CreateComfireOrderViewObj();

    }
}
