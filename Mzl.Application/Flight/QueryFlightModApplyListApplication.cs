using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Common.BaseInfo;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.UIModel.Flight;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.UIModel.Base;

namespace Mzl.Application.Flight
{
    internal class QueryFlightModApplyListApplication: BaseApplicationService, IQueryFlightModApplyListApplication
    {
        private readonly IQueryFlightModApplyListServiceBll _queryFlightModApplyListServiceBll;
        private readonly IGetCityForFlightServiceBll _getCityForFlightServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetCorpAduitOrderServiceBll _getCorpAduitOrderServiceBll;


        public QueryFlightModApplyListApplication(
            IQueryFlightModApplyListServiceBll queryFlightModApplyListServiceBll,
            IGetCityForFlightServiceBll getCityForFlightServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll, IGetCorpAduitOrderServiceBll getCorpAduitOrderServiceBll) 
        {
            _queryFlightModApplyListServiceBll = queryFlightModApplyListServiceBll;
            _getCityForFlightServiceBll = getCityForFlightServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _getCorpAduitOrderServiceBll = getCorpAduitOrderServiceBll;
        }

        public QueryFltModApplyListResponseViewModel QueryFltModApplyList(QueryFltModApplyListRequestViewModel request)
        {
            //1.查询机场信息
            SearchCityAportModel aportModel = _getCityForFlightServiceBll.SearchAirport(new List<string>() { "N" });
            //2.根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);
            QueryFlightModApplyListDataQueryModel query = Mapper.Map<QueryFltModApplyListRequestViewModel, QueryFlightModApplyListDataQueryModel>(request);
            query.AportInfo = aportModel;
            query.CorpId = customerModel.CorpID;
            query.Customer = customerModel;
            //判断是否显示全部订单
            if ((request.IsShowAllOrder ?? 0) == 1)
            {
                //判断客户是否有查看全部订单权限
                if ((customerModel.IsShowAllOrder ?? 0) == 1)
                {
                    query.Cid = null;
                }
            }
            //3.1判断是否是administrator帐号，如果是则获取当前公司下所有订单
            if (customerModel.UserID.ToLower() == "administrator")
            {
                query.Cid = null;
            }
            if (!string.IsNullOrEmpty(customerModel.CorpID))
            {
                query.CorpCustomerList = _getCustomerServiceBll.GetCustomerByCorpId(customerModel.CorpID);
            }
            QueryFlightModApplyListModel result = _queryFlightModApplyListServiceBll.QueryFlightModApplyList(query);

            if (result.ApplyDataList != null && result.ApplyDataList.Count > 0)
            {
                foreach (var order in result.ApplyDataList)
                {
                    List<CorpAduitOrderInfoModel> corpAduitOrderInfoModels =
                        _getCorpAduitOrderServiceBll.GetAduitOrderInfoByOrderId(order.Rmid);

                    if (corpAduitOrderInfoModels != null && corpAduitOrderInfoModels.Count > 0)
                    {
                        order.AduitOrderStatus = corpAduitOrderInfoModels[0].Status;
                        if (!string.IsNullOrEmpty(corpAduitOrderInfoModels[0].NextAduitName))
                            order.AuditStatus = string.Format("待{0}审批", corpAduitOrderInfoModels[0].NextAduitName);
                    }
                }
            }

            QueryFltModApplyListResponseViewModel viewModel = Mapper.Map<QueryFlightModApplyListModel, QueryFltModApplyListResponseViewModel>(result);

            SortedList<string, string> sortedList = EnumConvert.QueryEnumStr<FltModApplyStatusEnum>();
            viewModel.QueryOrderStatusList = (from status in sortedList
                                              select new SortedListViewModel()
                                              {
                                                  Key = status.Key,
                                                  Value = status.Value
                                              }).ToList();

            return viewModel;
        }
    }
}
