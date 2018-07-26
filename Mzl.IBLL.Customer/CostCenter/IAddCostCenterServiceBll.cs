using Mzl.DomainModel.Customer.CostCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.CostCenter
{
    /// <summary>
    /// 添加成本中心
    /// </summary>
    public interface IAddCostCenterServiceBll
    {
        int AddCostCenter(CostCenterModel costCenterModel);
    }
}
