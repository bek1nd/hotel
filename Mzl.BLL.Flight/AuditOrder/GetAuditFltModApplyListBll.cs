using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.AuditOrder;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.AuditOrder
{
    internal class GetAuditFltModApplyListBll : BaseBll, IGetAuditFltModApplyListBll
    {
        private readonly IFltRetModApplyDal _fltRetModApplyDal;
        private readonly IGetFlightRetModApplyBll _getFlightRetModApplyBll;

        public GetAuditFltModApplyListBll(IFltRetModApplyDal fltRetModApplyDal,
            IGetFlightRetModApplyBll getFlightRetModApplyBll) : base()
        {
            _fltRetModApplyDal = fltRetModApplyDal;
            _getFlightRetModApplyBll = getFlightRetModApplyBll;
        }

        public List<AuditOrderListDataModel> GetAuditFltOrderList(AuditFltOrderListQueryModel query)
        {
            GetAuditRetModOrderListFactory factory = new GetAuditRetModOrderListFactory(_fltRetModApplyDal,
                _getFlightRetModApplyBll, query);

            return factory.GetAuditList(OrderSourceTypeEnum.FltModApply);
        }

        public List<AuditOrderListDataModel> GetAlreadyAuditFltOrderList(AuditFltOrderListQueryModel query)
        {
            GetAuditRetModOrderListFactory factory = new GetAuditRetModOrderListFactory(_fltRetModApplyDal,
               _getFlightRetModApplyBll, query);

            return factory.GetAlreadyAuditList(OrderSourceTypeEnum.FltModApply);
        }
    }
}
