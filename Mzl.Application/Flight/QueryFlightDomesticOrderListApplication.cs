using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.UIModel.Flight;
using Mzl.IBLL.Flight;
using AutoMapper;
using Mzl.DomainModel.Flight;
using Mzl.Common.EnumHelper;
using Mzl.UIModel.Base;
using Mzl.IBLL.Common.BaseInfo;
using Mzl.IBLL.Customer.Customer;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.IBLL.Customer.CorpAduit;

namespace Mzl.Application.Flight
{
    internal class QueryFlightDomesticOrderListApplication : BaseApplicationService, IQueryFlightOrderListApplication 
    {
        private readonly IQueryFlightOrderListServiceBll _queryFlightOrderListServiceBll;
        private readonly IGetCityForFlightServiceBll _getCityForFlightServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetCorpAduitOrderServiceBll _getCorpAduitOrderServiceBll;

        public QueryFlightDomesticOrderListApplication(
            IQueryFlightOrderListServiceBll queryFlightOrderListServiceBll,
            IGetCityForFlightServiceBll getCityForFlightServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll, IGetCorpAduitOrderServiceBll getCorpAduitOrderServiceBll)
        {
            _queryFlightOrderListServiceBll = queryFlightOrderListServiceBll;
            _getCityForFlightServiceBll = getCityForFlightServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _getCorpAduitOrderServiceBll= getCorpAduitOrderServiceBll;
        }

        public QueryFltOrderListResponseViewModel QueryFltOrderList(QueryFltOrderListRequestViewModel request)
        {
           
            //1.查询机场信息
            SearchCityAportModel aportModel = _getCityForFlightServiceBll.SearchAirport(new List<string>() {"N"});
            //2.根据Cid查询客户信息
            CustomerModel customerModel= _getCustomerServiceBll.GetCustomerByCid(request.Cid);

            //3.查询机票订单
            QueryFlightOrderListDataQueryModel  query= Mapper.Map<QueryFltOrderListRequestViewModel, QueryFlightOrderListDataQueryModel>(request);
            query.AportInfo = aportModel;
            query.CorpId = customerModel.CorpID;
            query.Customer = customerModel;
            //判断是否显示全部订单
            if((query.IsShowAllOrder??0) == 1)
            {
                //判断客户是否有查看全部订单权限
                if((customerModel.IsShowAllOrder??0)==1)
                {
                    query.Cid = null;
                }
            }
            //3.1判断是否是administrator帐号，如果是则获取当前公司下所有订单 //administrator  administator
            if (customerModel.UserID.ToLower() == "administrator")
            {
                query.Cid = null;
            }
            if (!string.IsNullOrEmpty(customerModel.CorpID))
            {
                query.CorpCustomerList = _getCustomerServiceBll.GetCustomerByCorpId(customerModel.CorpID);
            }
            QueryFlightOrderListModel result = _queryFlightOrderListServiceBll.QueryFlightOrderList(query);

            if (result.OrderDataList != null && result.OrderDataList.Count > 0)
            {
                foreach (var order in result.OrderDataList)
                {
                    List<CorpAduitOrderInfoModel> corpAduitOrderInfoModels =
                        _getCorpAduitOrderServiceBll.GetAduitOrderInfoByOrderId(order.OrderId);

                    if (corpAduitOrderInfoModels != null && corpAduitOrderInfoModels.Count > 0)
                    {
                        order.AduitOrderStatus = corpAduitOrderInfoModels[0].Status;
                        if (!string.IsNullOrEmpty(corpAduitOrderInfoModels[0].NextAduitName))
                            order.AuditStatus = string.Format("待{0}审批", corpAduitOrderInfoModels[0].NextAduitName);
                    }
                }
            }
            
           
           

            QueryFltOrderListResponseViewModel viewModel= Mapper.Map<QueryFlightOrderListModel, QueryFltOrderListResponseViewModel>(result);

            SortedList<int, string> fltOrderStatusSortedList = EnumConvert.QueryEnum<FltOrderListOrderStatusEnum>();
            viewModel.QueryOrderStatusList = (from status in fltOrderStatusSortedList
                select new SortedListViewModel()
                {
                    Key = status.Key,
                    Value = status.Value
                }).ToList();

            return viewModel;

        }

        
    }
}
