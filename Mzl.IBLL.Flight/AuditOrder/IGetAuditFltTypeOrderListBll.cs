using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Flight;

namespace Mzl.IBLL.Flight.AuditOrder
{
    /// <summary>
    /// 获取机票类型的审核信息
    /// </summary>
    public interface IGetAuditFltTypeOrderListBll
    {
        /// <summary>
        /// 获取机票类型的待审核信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        List<AuditOrderListDataModel> GetAuditFltOrderList(AuditFltOrderListQueryModel query);
        /// <summary>
        /// 获取机票类型的已审核信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        List<AuditOrderListDataModel> GetAlreadyAuditFltOrderList(AuditFltOrderListQueryModel query);
    }
}
