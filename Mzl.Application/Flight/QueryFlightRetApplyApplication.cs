using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Common.BaseInfo;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.UIModel.Base;
using Mzl.UIModel.Flight;

namespace Mzl.Application.Flight
{
    internal class QueryFlightRetApplyApplication : BaseApplicationService, IQueryFlightRetApplyApplication
    {
        private readonly IQueryFlightRetApplyServiceBll _queryFlightRetApplyServiceBll;
        private readonly IGetCityForFlightServiceBll _getCityForFlightServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetCustomerCorpPolicyServiceBll _getCustomerCorpPolicyServiceBll;
        private readonly ICheckAduitOrderServiceBll _checkAduitOrderServiceBll;
        private readonly IGetCorpAduitOrderServiceBll _getCorpAduitOrderServiceBll;
        public QueryFlightRetApplyApplication(
            IQueryFlightRetApplyServiceBll queryFlightRetApplyServiceBll,
            IGetCityForFlightServiceBll getCityForFlightServiceBll, IGetCustomerServiceBll getCustomerServiceBll,
            IGetCustomerCorpPolicyServiceBll getCustomerCorpPolicyServiceBll,
            ICheckAduitOrderServiceBll checkAduitOrderServiceBll, IGetCorpAduitOrderServiceBll getCorpAduitOrderServiceBll)
        {
            _queryFlightRetApplyServiceBll = queryFlightRetApplyServiceBll;
            _getCityForFlightServiceBll = getCityForFlightServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _getCustomerCorpPolicyServiceBll = getCustomerCorpPolicyServiceBll;
            _checkAduitOrderServiceBll = checkAduitOrderServiceBll;
            _getCorpAduitOrderServiceBll = getCorpAduitOrderServiceBll;
        }

        public QueryFlightRetApplyResponseViewModel QueryFlightRetApply(QueryFltRetModApplyRequestViewModel request)
        {
            if (!request.Rmid.HasValue)
                throw new Exception("请传入Rmid参数");


            //1.查询机场信息
            SearchCityAportModel aportModel = _getCityForFlightServiceBll.SearchAirport(new List<string>() { "N" });
            //2.根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);
            //调用查询该客户的差旅政策服务
            List<ChoiceReasonModel> reasonModels =
                _getCustomerCorpPolicyServiceBll.GetCorpReasonByCorpId(customerModel.CorpID)?
                    .FindAll(n => n.PolicyType == "N");

            QueryFlightRetApplyQueryModel query =
                Mapper.Map<QueryFltRetModApplyRequestViewModel, QueryFlightRetApplyQueryModel>(request);
            query.AportInfo = aportModel;
            query.CorpId = customerModel.CorpID;
            query.Customer = customerModel;
            if (!string.IsNullOrEmpty(query.CorpId))
            {
                query.CorpCustomerList = _getCustomerServiceBll.GetCustomerByCorpId(query.CorpId);
            }
            query.PolicyReasonList = reasonModels;

            //判断当前客户是该订单的审批人
            query.IsFromAduitQuery = _checkAduitOrderServiceBll.CheckAduitCidHasOrderId(request.Cid,
                request.Rmid??0);

            QueryFlightRetApplyModel queryFlightRetApplyModel = _queryFlightRetApplyServiceBll.QueryRetApply(query);

            if (queryFlightRetApplyModel != null && customerModel.Corporation != null && customerModel.Corporation.AllowShowDataBeginTime.HasValue)
            {
                if (customerModel.Corporation.AllowShowDataBeginTime > queryFlightRetApplyModel.CreateTime)
                {
                    throw new Exception("查无此退票申请");
                }
            }

            List<CorpAduitOrderInfoModel> corpAduitOrderInfoModels =
                       _getCorpAduitOrderServiceBll.GetAduitOrderInfoByOrderId(queryFlightRetApplyModel.Rmid);

            if (corpAduitOrderInfoModels != null && corpAduitOrderInfoModels.Count > 0)
            {
                queryFlightRetApplyModel.AduitOrderId = corpAduitOrderInfoModels[0].AduitOrderId;
                queryFlightRetApplyModel.AduitOrderStatus = corpAduitOrderInfoModels[0].Status;
                if (!string.IsNullOrEmpty(corpAduitOrderInfoModels[0].NextAduitName))
                {
                    queryFlightRetApplyModel.AuditStatus = string.Format("待{0}审批", corpAduitOrderInfoModels[0].NextAduitName);
                    if (corpAduitOrderInfoModels[0].NextAduitCidList.Contains(request.Cid))
                        queryFlightRetApplyModel.IsCurrentCustomerAduitOrder = true;
                }
            }
            QueryFlightRetApplyResponseViewModel responseViewModel = Mapper.Map<QueryFlightRetApplyModel, QueryFlightRetApplyResponseViewModel>(
                    queryFlightRetApplyModel);


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
