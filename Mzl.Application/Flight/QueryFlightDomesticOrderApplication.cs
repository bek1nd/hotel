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
using Mzl.DomainModel.Common.Insurance;
using Mzl.DomainModel.Flight;
using Mzl.IBLL.Common.BaseInfo;
using Mzl.IBLL.Customer.Customer;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.IBLL.Common.Insurance;
using Mzl.IBLL.Customer.ProjectName;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.IBLL.Customer.CorpAduit;

namespace Mzl.Application.Flight
{
    /// <summary>
    /// 查询国内订单信息
    /// </summary>
    internal class QueryFlightDomesticOrderApplication : BaseApplicationService, IQueryFlightOrderApplication
    {
        private readonly IQueryFlightOrderServiceBll _queryFlightOrderServiceBll;
        private readonly IGetCityForFlightServiceBll _getCityForFlightServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetInsuranceCompanyServiceBll _getInsuranceCompanyServiceBll;
        private readonly IGetProjectNameServiceBll _getProjectNameServiceBll;
        private readonly ICheckAduitOrderServiceBll _checkAduitOrderServiceBll;
        private readonly IGetCorpAduitOrderServiceBll _getCorpAduitOrderServiceBll;


        public QueryFlightDomesticOrderApplication(
            IQueryFlightOrderServiceBll queryFlightOrderServiceBll,
            IGetCityForFlightServiceBll getCityForFlightServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll, IGetInsuranceCompanyServiceBll getInsuranceCompanyServiceBll,
             IGetProjectNameServiceBll getProjectNameServiceBll, ICheckAduitOrderServiceBll checkAduitOrderServiceBll, IGetCorpAduitOrderServiceBll getCorpAduitOrderServiceBll)
        {
            _queryFlightOrderServiceBll = queryFlightOrderServiceBll;
            _getCityForFlightServiceBll = getCityForFlightServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _getInsuranceCompanyServiceBll = getInsuranceCompanyServiceBll;
            _getProjectNameServiceBll = getProjectNameServiceBll;
            _checkAduitOrderServiceBll = checkAduitOrderServiceBll;
            _getCorpAduitOrderServiceBll = getCorpAduitOrderServiceBll;
        }

        public QueryFltOrderResponseViewModel QueryOrder(QueryFltOrderRequestViewModel request)
        {
            if (!request.OrderId.HasValue)
                throw new Exception("请传入订单Id");
            //1.查询机场信息
            SearchCityAportModel aportModel = _getCityForFlightServiceBll.SearchAirport(new List<string>() { "N" });
            //2.根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);
            //3.获取保险产品信息
            List<InsuranceCompanyModel> insuranceCompanyModels = _getInsuranceCompanyServiceBll.GetInsuranceCompany();
            //4.获取项目名称
            List<ProjectNameModel> projectNameModels = _getProjectNameServiceBll.GetProjectName(request.Cid);
            QueryFlightOrderQueryModel  query= Mapper.Map<QueryFltOrderRequestViewModel, QueryFlightOrderQueryModel>(request);
            query.AportInfo = aportModel;
            query.Customer = customerModel;
            query.CorpId = customerModel.CorpID;
            query.InsuranceCompany = insuranceCompanyModels;
            query.ProjectName = projectNameModels;
            if (!string.IsNullOrEmpty(customerModel.CorpID))
            {
                query.CorpCustomerList = _getCustomerServiceBll.GetCustomerByCorpId(customerModel.CorpID);
            }


            //判断当前客户是该订单的审批人
            query.IsFromAduitQuery = _checkAduitOrderServiceBll.CheckAduitCidHasOrderId(request.Cid,
                request.OrderId.Value);

            QueryFlightOrderDataModel dataModel = _queryFlightOrderServiceBll.QueryFlightOrder(query);
            if (dataModel != null && customerModel.Corporation != null && customerModel.Corporation.AllowShowDataBeginTime.HasValue)
            {
                if (customerModel.Corporation.AllowShowDataBeginTime > dataModel.OrderDate)
                {
                    throw new Exception("查无此订单");
                }
            }

            if (dataModel != null && dataModel.IsOnlineShow != 1)
            {
                List<CorpAduitOrderInfoModel> corpAduitOrderInfoModels =
                    _getCorpAduitOrderServiceBll.GetAduitOrderInfoByOrderId(dataModel.OrderId);

                if (corpAduitOrderInfoModels != null && corpAduitOrderInfoModels.Count > 0)
                {
                    dataModel.AduitOrderId = corpAduitOrderInfoModels[0].AduitOrderId;
                    dataModel.AduitOrderStatus = corpAduitOrderInfoModels[0].Status;
                    if (!string.IsNullOrEmpty(corpAduitOrderInfoModels[0].NextAduitName))
                    {
                        dataModel.AuditStatus = string.Format("待{0}审批", corpAduitOrderInfoModels[0].NextAduitName);
                        if (corpAduitOrderInfoModels[0].NextAduitCidList.Contains(request.Cid))
                            dataModel.IsCurrentCustomerAduitOrder = true;
                    }
                }
                else
                {
                    if ((dataModel.ProcessStatus & 8) != 8 && dataModel.OrderStatus != "C")
                        dataModel.IsShowCancelButton = true; //没有审批的，并且还没有出票的，显示取消按钮
                }
            }

            QueryFltOrderResponseViewModel  viewModel= Mapper.Map<QueryFlightOrderDataModel, QueryFltOrderResponseViewModel>(dataModel);
            return viewModel;
        }
    }
}
