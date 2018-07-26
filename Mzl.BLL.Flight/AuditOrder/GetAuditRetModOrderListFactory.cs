using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.AuditOrder
{
    internal class GetAuditRetModOrderListFactory
    {
        private readonly IFltRetModApplyDal _fltRetModApplyDal;
        private readonly IGetFlightRetModApplyBll _getFlightRetModApplyBll;
        private readonly AuditFltOrderListQueryModel _query;

        public GetAuditRetModOrderListFactory(IFltRetModApplyDal fltRetModApplyDal,
            IGetFlightRetModApplyBll getFlightRetModApplyBll, AuditFltOrderListQueryModel query)
        {
            _fltRetModApplyDal = fltRetModApplyDal;
            _getFlightRetModApplyBll = getFlightRetModApplyBll;
            _query = query;

        }
        /// <summary>
        /// 获取待审批的申请信息
        /// </summary>
        /// <param name="orderSourceType"></param>
        /// <returns></returns>
        public List<AuditOrderListDataModel> GetAuditList(OrderSourceTypeEnum orderSourceType)
        {
            if (orderSourceType == OrderSourceTypeEnum.FltModApply || orderSourceType == OrderSourceTypeEnum.FltRetApply)
                return Get(orderSourceType);
            return null;
        }
        /// <summary>
        /// 获取已经审批的申请信息
        /// </summary>
        /// <param name="orderSourceType"></param>
        /// <returns></returns>
        public List<AuditOrderListDataModel> GetAlreadyAuditList(OrderSourceTypeEnum orderSourceType)
        {
            if (orderSourceType == OrderSourceTypeEnum.FltModApply || orderSourceType == OrderSourceTypeEnum.FltRetApply)
                return GetAlready(orderSourceType);
            return null;
        }

        #region 私有方法
        private List<AuditOrderListDataModel> Get(OrderSourceTypeEnum orderSourceType)
        {
            return null;
        }

        private List<AuditOrderListDataModel> GetAlready(OrderSourceTypeEnum orderSourceType)
        {
            return null;
        }

        private List<AuditOrderListDataModel> ConvertList(List<FltRetModApplyEntity> retModApplyEntities, OrderSourceTypeEnum orderSourceType,string auditStatus="")
        {
            return null;
        }

        #endregion
    }
}
