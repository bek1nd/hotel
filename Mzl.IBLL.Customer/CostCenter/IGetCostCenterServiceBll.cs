using Mzl.DomainModel.Customer.CostCenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.CostCenter
{
    public interface IGetCostCenterServiceBll
    {
        /// <summary>
        /// 获取公司对应的成本中心
        /// </summary>
        /// <param name="corpId"></param>
        /// <returns></returns>
        List<CostCenterModel> GetCostCenter(string corpId);
        /// <summary>
        /// 获取未删除的成本中心
        /// </summary>
        /// <param name="corpId"></param>
        /// <returns></returns>
        List<CostCenterModel> GetCostCenterByNoDelete(string corpId);

        List<CostCenterModel> GetCostCenter(int cid);
    }
}
