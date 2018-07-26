using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.UIModel.Flight;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Flight;
using Mzl.IBLL.Common.BaseInfo;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Base;

namespace Mzl.Application.Flight
{
    public class QueryFlightModApplyApplication: BaseApplicationService,IQueryFlightModApplyApplication
    {
        private readonly IQueryFlightModApplyServiceBll _queryFlightModApplyServiceBll;
        private readonly IGetCityForFlightServiceBll _getCityForFlightServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetCustomerCorpPolicyServiceBll _getCustomerCorpPolicyServiceBll;
        private readonly ICheckAduitOrderServiceBll _checkAduitOrderServiceBll;
        private readonly IGetCorpAduitOrderServiceBll _getCorpAduitOrderServiceBll;


        public QueryFlightModApplyApplication(
            IQueryFlightModApplyServiceBll queryFlightModApplyServiceBll,
            IGetCityForFlightServiceBll getCityForFlightServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll, IGetCustomerCorpPolicyServiceBll getCustomerCorpPolicyServiceBll,
            ICheckAduitOrderServiceBll checkAduitOrderServiceBll, IGetCorpAduitOrderServiceBll getCorpAduitOrderServiceBll)
        {
            _queryFlightModApplyServiceBll = queryFlightModApplyServiceBll;
            _getCityForFlightServiceBll = getCityForFlightServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _getCustomerCorpPolicyServiceBll = getCustomerCorpPolicyServiceBll;
            _checkAduitOrderServiceBll = checkAduitOrderServiceBll;
            _getCorpAduitOrderServiceBll = getCorpAduitOrderServiceBll;
        }


        public QueryFlightModApplyResponseViewModel QueryFlightModApply(QueryFltRetModApplyRequestViewModel request)
        {
            if(!request.Rmid.HasValue)
                throw new Exception("请传入Rmid参数");
            //1.查询机场信息
            SearchCityAportModel aportModel = _getCityForFlightServiceBll.SearchAirport(new List<string>() { "N" });
            //2.根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);
            //调用查询该客户的差旅政策服务
            List<ChoiceReasonModel> reasonModels =
                _getCustomerCorpPolicyServiceBll.GetCorpReasonByCorpId(customerModel.CorpID)?
                    .FindAll(n => n.PolicyType == "N");

            QueryFlightModApplyQueryModel query =
                Mapper.Map<QueryFltRetModApplyRequestViewModel, QueryFlightModApplyQueryModel>(request);
            query.AportInfo = aportModel;
            query.CorpId = customerModel.CorpID;
            query.Customer = customerModel;
            if (!string.IsNullOrEmpty(query.CorpId))
            {
                query.CorpCustomerList = _getCustomerServiceBll.GetCustomerByCorpId(query.CorpId);
            }
            query.PolicyReasonList = reasonModels;
            query.IsFromAduitQuery = _checkAduitOrderServiceBll.CheckAduitCidHasOrderId(request.Cid,
               request.Rmid??0);

            QueryFlightModApplyDataModel queryFlightModApplyDataModel =
                _queryFlightModApplyServiceBll.QueryModApply(query);

            if (queryFlightModApplyDataModel != null && customerModel.Corporation != null && customerModel.Corporation.AllowShowDataBeginTime.HasValue)
            {
                if (customerModel.Corporation.AllowShowDataBeginTime > queryFlightModApplyDataModel.CreateTime)
                {
                    throw new Exception("查无此改签申请");
                }
            }

            List<CorpAduitOrderInfoModel> corpAduitOrderInfoModels =
                       _getCorpAduitOrderServiceBll.GetAduitOrderInfoByOrderId(queryFlightModApplyDataModel.Rmid);

            if (corpAduitOrderInfoModels != null && corpAduitOrderInfoModels.Count > 0)
            {
                queryFlightModApplyDataModel.AduitOrderId = corpAduitOrderInfoModels[0].AduitOrderId;
                queryFlightModApplyDataModel.AduitOrderStatus = corpAduitOrderInfoModels[0].Status;
                if (!string.IsNullOrEmpty(corpAduitOrderInfoModels[0].NextAduitName))
                {
                    queryFlightModApplyDataModel.AuditStatus = string.Format("待{0}审批", corpAduitOrderInfoModels[0].NextAduitName);
                    if (corpAduitOrderInfoModels[0].NextAduitCidList.Contains(request.Cid))
                        queryFlightModApplyDataModel.IsCurrentCustomerAduitOrder = true;
                }
            }

            QueryFlightModApplyResponseViewModel responseViewModel = Mapper
                .Map<QueryFlightModApplyDataModel, QueryFlightModApplyResponseViewModel>(
                    queryFlightModApplyDataModel);


            responseViewModel.PolicyReason = (from n in reasonModels
                                              select new SortedListViewModel()
                                              {
                                                  Key = n.Id,
                                                  Value = n.Reason
                                              }).ToList();

            return responseViewModel;
        }

     

    }
}
