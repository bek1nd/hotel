using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    internal class QueryFlightModApplyServiceBll: BaseServiceBll,IQueryFlightModApplyServiceBll
    {
        private readonly IGetFlightRetModApplyBll _getFlightRetModApplyBll;
        private readonly IGetFlightModOrderBll _getFlightModOrderBll;


        public QueryFlightModApplyServiceBll(IGetFlightRetModApplyBll getFlightRetModApplyBll,
            IGetFlightModOrderBll getFlightModOrderBll) : base()
        {
            _getFlightRetModApplyBll = getFlightRetModApplyBll;
            _getFlightModOrderBll = getFlightModOrderBll;
        }

        public QueryFlightModApplyDataModel QueryModApply(QueryFlightModApplyQueryModel query)
        {

            QueryFlightModApplyDataModel queryFlightModApplyDataModel =new QueryFlightModApplyDataModel();

            _getFlightRetModApplyBll.AportInfo = query.AportInfo;
            _getFlightRetModApplyBll.PolicyReasonList = query.PolicyReasonList;
            FltRetModApplyModel  fltRetModApplyModel= _getFlightRetModApplyBll.GetRetModApply(query.Rmid);

            if ((query.Customer.IsShowAllOrder ?? 0) == 0)//如果没有查看全部订单的权限
            {
                if (!query.IsFromAduitQuery) //不是来自审批人查询
                {
                    if (!string.IsNullOrEmpty(query.Customer?.UserID) && query.Customer.UserID.ToLower() != "administrator" &&
                        query.Customer.Cid != fltRetModApplyModel.Cid)
                        throw new Exception("查无此改签申请");
                }
            }

            if (!string.IsNullOrEmpty(query.Customer?.UserID) && query.Customer.UserID.ToLower() == "administrator" )
            {
                if ((query.CidList != null && !query.CidList.Contains(fltRetModApplyModel.Cid)) || query.CidList == null)
                    throw new Exception("查无此改签申请");
            }

            fltRetModApplyModel.ApplyCustomer = query.CorpCustomerList?.Find(n => n.Cid == fltRetModApplyModel.Cid);

            _getFlightModOrderBll.AportInfo = query.AportInfo;
            FltModOrderModel fltModOrderModel = _getFlightModOrderBll.GetModOrderByRmid(query.Rmid);

            queryFlightModApplyDataModel = queryFlightModApplyDataModel.ConvertFatherToSon(fltRetModApplyModel);
            queryFlightModApplyDataModel.FltModOrder = fltModOrderModel;

           

            //如果存在改签订单，并且已经出票，则提取改签面价，和改签票号
            if (fltModOrderModel != null && (fltModOrderModel.ProcessStatus & 8) == 8)
            {
                queryFlightModApplyDataModel.ModPrice = fltModOrderModel.ModPrice;
                queryFlightModApplyDataModel.PassengerList.ForEach(n =>
                {
                    n.ModTicketNoList =
                        fltModOrderModel.FltModTicketNoList.FindAll(x => x.PassengerName == n.Name)
                            .Select(x => x.AirlineNo + x.TicketNo)
                            .ToList();
                    n.IsMod = true;
                });
            }


            return queryFlightModApplyDataModel;
        }

      
    }
}
