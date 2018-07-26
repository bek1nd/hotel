using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.BLL.Flight.AuditOrder.AuditVisitor;
using Mzl.Common.EnumHelper;
using Mzl.Common.Exceptions;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.AuditOrder;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.AuditOrder
{
    internal class AuditFltOrderBll: BaseBll,IAuditFltOrderBll
    {
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltOrderLogDal _fltOrderLogDal;

        private readonly IValidataFltOrderAuditBll _validataAuditInfoBll;

        public AuditFltOrderBll(IFltOrderDal fltOrderDal, IFltOrderLogDal fltOrderLogDal,
            IValidataFltOrderAuditBll validataAuditInfoBll) : base()
        {
            _fltOrderDal = fltOrderDal;
            _fltOrderLogDal = fltOrderLogDal;
            _validataAuditInfoBll = validataAuditInfoBll;
        }


        public AuditResultModel RunAudit(AuditFltOrderQueryModel query)
        {
            FltOrderEntity orderEntity = _fltOrderDal.Find<FltOrderEntity>(query.Id);
            FltOrderModel orderModel = Mapper.Map<FltOrderEntity, FltOrderModel>(orderEntity);
            if (orderModel == null)
                throw new MojoryException(MojoryApiResponseCode.NoFindOrder);
            query.FltOrder = orderModel;
            //进行验证
            _validataAuditInfoBll.Validata(query);


            //进行审批
            AuditResultModel code = new AuditResultModel();
            IRunAuditVisitor visitor = new RunAuditVisitor(_fltOrderDal, _fltOrderLogDal, query);

            if (query.AuditStep == FltOrderCheckStatusEnum.T.ToString())//待一级审批
            {
                AuditOrderAbstract auditOrderFirst = new AuditOrderFirst();
                code = auditOrderFirst.RunAudit(visitor);
            }
            else if (query.AuditStep == FltOrderCheckStatusEnum.S.ToString())//待二级审批
            {
                AuditOrderAbstract auditOrderSecond = new AuditOrderSecond();
                code = auditOrderSecond.RunAudit(visitor);
            }

            return code;
        }

     
    }
}
