using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Flight;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.AuditOrder.AuditVisitor
{
    public interface IRunAuditVisitor
    {
        /// <summary>
        /// 进行一级审核(机票订单)
        /// </summary>
        /// <param name="firstAudit"></param>
        /// <returns></returns>
        AuditResultModel DoFirstAudit(AuditOrderFirst firstAudit);
        /// <summary>
        /// 进行二级审核(机票订单)
        /// </summary>
        /// <param name="secondAudit"></param>
        /// <returns></returns>
        AuditResultModel DoSecondAudit(AuditOrderSecond secondAudit);

        /// <summary>
        /// 进行一级审核(机票改签申请)
        /// </summary>
        /// <param name="firstAudit"></param>
        /// <returns></returns>
        AuditResultModel DoFirstAudit(AuditModApplyFirst firstAudit);
        /// <summary>
        /// 进行二级审核(机票改签申请)
        /// </summary>
        /// <param name="secondAudit"></param>
        /// <returns></returns>
        AuditResultModel DoSecondAudit(AuditModApplySecond secondAudit);

        /// <summary>
        /// 进行一级审核(机票退票申请)
        /// </summary>
        /// <param name="firstAudit"></param>
        /// <returns></returns>
        AuditResultModel DoFirstAudit(AuditRetApplyFirst firstAudit);
        /// <summary>
        /// 进行二级审核(机票退票申请)
        /// </summary>
        /// <param name="secondAudit"></param>
        /// <returns></returns>
        AuditResultModel DoSecondAudit(AuditRetApplySecond secondAudit);
    }
}
