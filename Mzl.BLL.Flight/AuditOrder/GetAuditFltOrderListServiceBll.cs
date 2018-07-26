using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.AuditOrder;

namespace Mzl.BLL.Flight.AuditOrder
{
    /// <summary>
    /// 获取机票待审核信息 :正单 改签申请 退票申请
    /// </summary>
    internal class GetAuditFltOrderListServiceBll: BaseServiceBll, IGetAuditFltOrderListServiceBll
    {
        private readonly IGetAuditFltOrderListBll _getAuditFltOrderListBll;
        private readonly IGetAuditFltModApplyListBll _getAuditFltModApplyListBll;
        private readonly IGetAuditFltRetApplyListBll _getAuditFltRetApplyListBll;

        public GetAuditFltOrderListServiceBll(IGetAuditFltOrderListBll getAuditFltOrderListBll,
            IGetAuditFltModApplyListBll getAuditFltModApplyListBll, IGetAuditFltRetApplyListBll getAuditFltRetApplyListBll) : base()
        {
            _getAuditFltOrderListBll = getAuditFltOrderListBll;
            _getAuditFltModApplyListBll = getAuditFltModApplyListBll;
            _getAuditFltRetApplyListBll = getAuditFltRetApplyListBll;
        }

        public AuditOrderListModel GetAuditFltOrderList(AuditFltOrderListQueryModel query)
        {
            AuditOrderListModel result = new AuditOrderListModel {DataList = new List<AuditOrderListDataModel>()};

            if (!query.IsAudit)//待审核信息
            {
                List<AuditOrderListDataModel> fltList = _getAuditFltOrderListBll.GetAuditFltOrderList(query);
                List<AuditOrderListDataModel> modList = _getAuditFltModApplyListBll.GetAuditFltOrderList(query);
                List<AuditOrderListDataModel> retList = _getAuditFltRetApplyListBll.GetAuditFltOrderList(query);
                if (fltList != null && fltList.Count > 0)
                    result.DataList.AddRange(fltList);
                if (modList != null && modList.Count > 0)
                    result.DataList.AddRange(modList);
                if (retList != null && retList.Count > 0)
                    result.DataList.AddRange(retList);
            }
            else//已审核信息
            {
                List<AuditOrderListDataModel> fltList = _getAuditFltOrderListBll.GetAlreadyAuditFltOrderList(query);
                List<AuditOrderListDataModel> modList = _getAuditFltModApplyListBll.GetAlreadyAuditFltOrderList(query);
                List<AuditOrderListDataModel> retList = _getAuditFltRetApplyListBll.GetAlreadyAuditFltOrderList(query);
                if (fltList != null && fltList.Count > 0)
                    result.DataList.AddRange(fltList);
                if (modList != null && modList.Count > 0)
                    result.DataList.AddRange(modList);
                if (retList != null && retList.Count > 0)
                    result.DataList.AddRange(retList);

                //result.DataList = result.DataList.OrderByDescending(n => n.AuditTime).ToList();
            }

            return result;
        }
    }
}
