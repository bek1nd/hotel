using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight.AuditOrder.AuditValidate
{
    /// <summary>
    /// 审批人判断
    /// </summary>
    public class AuditeCidValidate : AuditAbstractValidate
    {
        public override bool ActionValidate(ValidataAuditContext context)
        {
            int? auditCid = null;
            if (context.AuditStep == "T") //待一级审核
            {
                auditCid = context.FltOrder.CPId;
            }
            if (context.AuditStep == "S") //待二级审核
            {
                auditCid = context.FltOrder.CPIdSecond;
            }
            if (!auditCid.HasValue)
                throw new Exception("当前订单没有设置审批人，不能审批");
            if (context.AuditCid != auditCid.Value)
                throw new Exception("无权审批该订单");

            this.NextNode?.ActionValidate(context);
            return true;
        }
    }
}
