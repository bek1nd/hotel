using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.AuditOrder;

namespace Mzl.BLL.Flight.AuditOrder.AuditValidate
{
    internal class ValidataFltOrderAuditBll : BaseBll, IValidataFltOrderAuditBll
    {
        


        public bool Validata(AuditFltOrderQueryModel auditFltOrderQuery)
        {
            ValidataAuditContext context = new ValidataAuditContext()
            {
                FltOrder = auditFltOrderQuery.FltOrder,
                AuditStep = auditFltOrderQuery.AuditStep,
                AuditCid = auditFltOrderQuery.AuditCustomer.Cid
            };


            AuditAbstractValidate alreadyAuditedValidate = new AlreadyAuditedValidate();
            AuditAbstractValidate auditeCidValidate = new AuditeCidValidate();

            alreadyAuditedValidate.SetNextNode(auditeCidValidate);


            return alreadyAuditedValidate.ActionValidate(context);
        }

        public bool Validata(AuditFltModApplyQueryModel auditFltModApplyQuery)
        {
            ValidataAuditContext context = new ValidataAuditContext()
            {
                FltRetModApply = auditFltModApplyQuery.FltModApply,
                AuditStep = auditFltModApplyQuery.AuditStep,
                AuditCid = auditFltModApplyQuery.AuditCustomer.Cid,
                ApplyType = 0
            };

            AuditAbstractValidate alreadyAuditedValidate = new AlreadyRetModApplyAuditedValidate();
            AuditAbstractValidate auditeCidValidate = new AuditeRetModApplyCidValidate();

            alreadyAuditedValidate.SetNextNode(auditeCidValidate);

            return alreadyAuditedValidate.ActionValidate(context);
        }

        public bool Validata(AuditFltRetApplyQueryModel auditFltRetApplyQuery)
        {
            ValidataAuditContext context = new ValidataAuditContext()
            {
                FltRetModApply = auditFltRetApplyQuery.FltRetApply,
                AuditStep = auditFltRetApplyQuery.AuditStep,
                AuditCid = auditFltRetApplyQuery.AuditCustomer.Cid,
                ApplyType = 1
            };

            AuditAbstractValidate alreadyAuditedValidate = new AlreadyRetModApplyAuditedValidate();
            AuditAbstractValidate auditeCidValidate = new AuditeRetModApplyCidValidate();

            alreadyAuditedValidate.SetNextNode(auditeCidValidate);

            return alreadyAuditedValidate.ActionValidate(context);
        }
    }
}
