using Mzl.Common.Factory;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.IBLL.Customer.CostCenter.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.CostCenter.Factory
{
    public interface ICostCenterBLLFactory : IBaseBLLFactory<ICostCenterBLL<CostCenterModel>>
    {
    }
}
