using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.DomesticRetMod;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    internal class QueryFlightRetApplyServiceBll: BaseServiceBll,IQueryFlightRetApplyServiceBll
    {
        private readonly IGetFlightRetModApplyBll _getFlightRetModApplyBll;
        private readonly IGetFlighRefundOrderBll _getFlighRefundOrderBll;
        public QueryFlightRetApplyServiceBll(IGetFlightRetModApplyBll getFlightRetModApplyBll, IGetFlighRefundOrderBll getFlighRefundOrderBll) : base()
        {
            _getFlightRetModApplyBll = getFlightRetModApplyBll;
            _getFlighRefundOrderBll = getFlighRefundOrderBll;
        }

        public QueryFlightRetApplyModel QueryRetApply(QueryFlightRetApplyQueryModel query)
        {
            QueryFlightRetApplyModel queryFlightRetApplyModel = new QueryFlightRetApplyModel();

            _getFlightRetModApplyBll.AportInfo = query.AportInfo;
            _getFlightRetModApplyBll.PolicyReasonList = query.PolicyReasonList;

            FltRetModApplyModel fltRetModApplyModel = _getFlightRetModApplyBll.GetRetModApply(query.Rmid);

            if ((query.Customer.IsShowAllOrder ?? 0) == 0)//没有查看全部订单权限
            {
                if (!query.IsFromAduitQuery) //不是来自审批人查询
                {
                    if (!string.IsNullOrEmpty(query.Customer?.UserID) && query.Customer.UserID.ToLower() != "administrator" &&
                        query.Customer.Cid != fltRetModApplyModel.Cid)
                        throw new Exception("查无此退票申请");
                }
            }
           

            if (!string.IsNullOrEmpty(query.Customer?.UserID) && query.Customer.UserID.ToLower() == "administrator")
            {
                if ((query.CidList != null && !query.CidList.Contains(fltRetModApplyModel.Cid)) || query.CidList == null)
                    throw new Exception("查无此退票申请");
            }

            fltRetModApplyModel.ApplyCustomer = query.CorpCustomerList?.Find(n => n.Cid == fltRetModApplyModel.Cid);

            _getFlightRetModApplyBll.AportInfo = query.AportInfo;
            queryFlightRetApplyModel = queryFlightRetApplyModel.ConvertFatherToSon(fltRetModApplyModel);
            if (!string.IsNullOrEmpty(queryFlightRetApplyModel.Remark) &&
                queryFlightRetApplyModel.Remark.Contains("航空公司收"))
            {
                int d = queryFlightRetApplyModel.Remark.IndexOf("航空公司收", StringComparison.Ordinal);
                queryFlightRetApplyModel.Remark = queryFlightRetApplyModel.Remark.Substring(0, d);
            }

            FltRefundOrderModel refundOrderModel = _getFlighRefundOrderBll.GetFlighRefundOrderByRmid(query.Rmid);
            if (refundOrderModel != null)
            {
                queryFlightRetApplyModel.RefundOrder = refundOrderModel;
                queryFlightRetApplyModel.PassengerList.ForEach(n =>
                {
                    n.IsRet = true;
                });
            }


            List<int> sequenceList = fltRetModApplyModel.DetailList.Select(n => n.Sequence).Distinct().ToList();
            List<FltRetFlightModel> fltRetFlightModels = new List<FltRetFlightModel>();
            foreach (var sequence in sequenceList)
            {
                List< FltRetModFlightApplyModel> fltRetModFlightApplyModels =
                    fltRetModApplyModel.DetailList.FindAll(n => n.Sequence == sequence);
                FltRetFlightModel fltRetFlightModel =
                    Mapper.Map<FltRetModFlightApplyModel, FltRetFlightModel>(fltRetModFlightApplyModels[0]);
                fltRetFlightModel.PassengerList = fltRetModFlightApplyModels.Select(n => n.PassengerModel).ToList();
                fltRetFlightModels.Add(fltRetFlightModel);
            }

            queryFlightRetApplyModel.FltRetFlightList = fltRetFlightModels;
            return queryFlightRetApplyModel;
        }
    }
}
