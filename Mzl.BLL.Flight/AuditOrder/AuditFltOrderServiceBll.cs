using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.AuditOrder;

namespace Mzl.BLL.Flight.AuditOrder
{
    /// <summary>
    /// 审批机票正单 改签申请 退票申请
    /// </summary>
    internal class AuditFltOrderServiceBll : BaseServiceBll, IAuditFltOrderServiceBll
    {
        private readonly IAuditFltOrderBll _auditFltOrderBll;
        private readonly IAuditFltModApplyBll _auditFltModApplyBll;
        private readonly IAuditFltRetApplyBll _auditFltRetApplyBll;

        public AuditFltOrderServiceBll(IAuditFltOrderBll auditFltOrderBll,
            IAuditFltModApplyBll auditFltModApplyBll, IAuditFltRetApplyBll auditFltRetApplyBll) : base()
        {
            _auditFltOrderBll = auditFltOrderBll;
            _auditFltModApplyBll = auditFltModApplyBll;
            _auditFltRetApplyBll = auditFltRetApplyBll;
        }

        /// <summary>
        /// 进行审批
        /// </summary>
        public AuditResultModel RunAudit(AuditTypeQueryModel query)
        {
            int code = 0;
            if (query.OrderSourceType == OrderSourceTypeEnum.Flt)
            {
                AuditFltOrderQueryModel fltOrderQuery = new AuditFltOrderQueryModel().ConvertFatherToSon(query);
                var result=_auditFltOrderBll.RunAudit(fltOrderQuery);
                return result;
            }
            if (query.OrderSourceType == OrderSourceTypeEnum.FltModApply)
            {
                AuditFltModApplyQueryModel fltModApplyQueryModel =
                    new AuditFltModApplyQueryModel().ConvertFatherToSon(query);
                var result = _auditFltModApplyBll.RunAudit(fltModApplyQueryModel);
                return result;
            }
            if (query.OrderSourceType == OrderSourceTypeEnum.FltRetApply)
            {
                AuditFltRetApplyQueryModel fltRetApplyQueryModel =
                    new AuditFltRetApplyQueryModel().ConvertFatherToSon(query);
                var result = _auditFltRetApplyBll.RunAudit(fltRetApplyQueryModel);
                return result;
            }

            throw new Exception("审批类型错误");
        }
    }
}
