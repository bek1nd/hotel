using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.BLL.Flight.AuditOrder.AuditVisitor;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.AuditOrder;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.AuditOrder
{
    internal class AuditFltModApplyBll: BaseBll,IAuditFltModApplyBll
    {
        private readonly IFltRetModApplyDal _fltRetModApplyDal;
        private readonly IFltRetModFlightApplyDal _fltRetModFlightApplyDal;
        private readonly IFltRetModApplyLogDal _fltRetModApplyLogDal;
        private readonly IValidataFltOrderAuditBll _validataAuditInfoBll;

        public AuditFltModApplyBll(IFltRetModApplyDal fltRetModApplyDal,
            IFltRetModFlightApplyDal fltRetModFlightApplyDal, IFltRetModApplyLogDal fltRetModApplyLogDal, IValidataFltOrderAuditBll validataAuditInfoBll) : base()
        {
            _fltRetModApplyDal = fltRetModApplyDal;
            _fltRetModFlightApplyDal = fltRetModFlightApplyDal;
            _fltRetModApplyLogDal = fltRetModApplyLogDal;
            _validataAuditInfoBll = validataAuditInfoBll;
        }

        public AuditResultModel RunAudit(AuditFltModApplyQueryModel query)
        {
           throw new Exception("无效方法");
        }
    }
}
