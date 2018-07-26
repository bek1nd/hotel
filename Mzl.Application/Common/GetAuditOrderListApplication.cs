using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Common.Insurance;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.DomainModel.Flight;
using Mzl.DomainModel.Train.Order;
using Mzl.Framework.Base;
using Mzl.IApplication.Common;
using Mzl.IBLL.Common.BaseInfo;
using Mzl.IBLL.Common.Insurance;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Customer.ProjectName;
using Mzl.IBLL.Flight;
using Mzl.IBLL.Flight.AuditOrder;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.IBLL.Train.Order;
using Mzl.UIModel.Common.AuditOrder;
using Mzl.UIModel.Flight;

namespace Mzl.Application.Common
{
    public class GetAuditOrderListApplication : BaseApplicationService, IGetAuditOrderListApplication
    {
        private readonly IGetCityForFlightServiceBll _getCityForFlightServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetCorpAduitOrderListServiceBll _getCorpAduitOrderListServiceBll;
        private readonly IGetFltOrderBll _getFltOrderBll;
        private readonly IGetFlightRetModApplyBll _getFlightRetModApplyBll;
        private readonly IGetTraOrderServiceBll _getTraOrderServiceBll;
        private readonly IGetCustomerCorpPolicyServiceBll _getCustomerCorpPolicyServiceBll;



        public GetAuditOrderListApplication(
            IGetCityForFlightServiceBll getCityForFlightServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll,
            IGetCorpAduitOrderListServiceBll getCorpAduitOrderListServiceBll,
            IGetFltOrderBll getFltOrderBll, IGetFlightRetModApplyBll getFlightRetModApplyBll,
            IGetTraOrderServiceBll getTraOrderServiceBll,
            IGetCustomerCorpPolicyServiceBll getCustomerCorpPolicyServiceBll)
        {
            _getCityForFlightServiceBll = getCityForFlightServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _getCorpAduitOrderListServiceBll = getCorpAduitOrderListServiceBll;
            _getFltOrderBll = getFltOrderBll;
            _getFlightRetModApplyBll = getFlightRetModApplyBll;
            _getTraOrderServiceBll = getTraOrderServiceBll;
            _getCustomerCorpPolicyServiceBll = getCustomerCorpPolicyServiceBll;
        }




        public GetAuditOrderListResponseViewModel GetAuditOrderList(GetAuditOrderListRequestViewModel request)
        {
          
            //1.根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);
            if (string.IsNullOrEmpty(customerModel.IsCheckPerson) || customerModel.IsCheckPerson.ToUpper() != "T")
                throw new Exception("当前用户无权审批");

       

            AuditOrderListModel list = null;

            if (request.AuditType == 1)//待审批信息
            {
                #region 待审批信息

                list = _getCorpAduitOrderListServiceBll.GetWaitCorpAduitOrderList(new AuditOrderListQueryModel()
                {
                    AuditCid = request.Cid,
                    PageSize = request.PageSize,
                    PageIndex = request.PageIndex,
                    Customer = customerModel
                });

                #endregion
            }
            else if (request.AuditType == 2)//审批通过
            {
                #region 审批通过
                list = _getCorpAduitOrderListServiceBll.GetPassCorpAduitOrderList(new AuditOrderListQueryModel()
                {
                    AuditCid = request.Cid,
                    PageSize = request.PageSize,
                    PageIndex = request.PageIndex,
                    Customer = customerModel
                }); 
                #endregion
            }
            else if (request.AuditType == 3)//审批不通过
            {
                #region 审批不通过
                list = _getCorpAduitOrderListServiceBll.GetNoPassCorpAduitOrderList(new AuditOrderListQueryModel()
                {
                    AuditCid = request.Cid,
                    PageSize = request.PageSize,
                    PageIndex = request.PageIndex,
                    Customer = customerModel
                }); 
                #endregion
            }



            #region 组装审批内容
            if (list != null && list.DataList != null && list.DataList.Count > 0)
            {

                //查询机场信息
                _getFltOrderBll.AportInfo = _getCityForFlightServiceBll.SearchAirport(new List<string>() { "N" });
                _getFlightRetModApplyBll.AportInfo = _getCityForFlightServiceBll.SearchAirport(new List<string>() { "N" });
                //调用查询该客户的差旅政策服务
                List<ChoiceReasonModel> reasonModels = _getCustomerCorpPolicyServiceBll.GetCorpReasonByCorpId(customerModel.CorpID);
                _getFlightRetModApplyBll.PolicyReasonList = reasonModels;

                foreach (var data in list.DataList)
                {
                    foreach (var detail in data.DetailList)
                    {
                        if (detail.OrderType == OrderSourceTypeEnum.Flt)
                        {
                            FltOrderInfoModel fltOrderInfoModel = _getFltOrderBll.GetFltOrderById(detail.OrderId);
                            if (fltOrderInfoModel == null)
                                continue;
                            detail.ChoiceReason = fltOrderInfoModel.ChoiceReason;
                            detail.CorpPolicy = fltOrderInfoModel.CorpPolicy;
                            detail.OrderAmount = fltOrderInfoModel.Payamount;
                            detail.PassengerNameList = fltOrderInfoModel.PassengerNameList;
                            detail.TackOffTimeList = fltOrderInfoModel.TackOffTimeList;
                            detail.TravelList = fltOrderInfoModel.TravelList;
                            detail.OrderIdDes = fltOrderInfoModel.OrderId.ToString();
                        }
                        else if (detail.OrderType == OrderSourceTypeEnum.FltModApply || detail.OrderType == OrderSourceTypeEnum.FltRetApply)
                        {
                            FltRetModApplyModel fltRetModApplyModel =
                                _getFlightRetModApplyBll.GetRetModApply(detail.OrderId);
                            if (fltRetModApplyModel == null)
                                continue;
                            detail.ChoiceReason = fltRetModApplyModel.ChoiceReason;
                            detail.CorpPolicy = fltRetModApplyModel.CorpPolicy;
                            detail.OrderAmount = fltRetModApplyModel.TotalAuditPrice;
                            detail.PassengerNameList = fltRetModApplyModel.PassengerNameList;
                            detail.TackOffTimeList = fltRetModApplyModel.TackOffTimeList;
                            detail.TravelList = fltRetModApplyModel.TravelList;
                            detail.OrderIdDes = fltRetModApplyModel.OrderId.ToString();
                        }
                        else if (detail.OrderType == OrderSourceTypeEnum.Tra)
                        {
                            TraOrderInfoModel traOrderInfoModel =
                                _getTraOrderServiceBll.GetTraOrderByOrderId(detail.OrderId);
                            if (traOrderInfoModel == null)
                                continue;
                            detail.ChoiceReason = traOrderInfoModel.ChoiceReason;
                            detail.CorpPolicy = traOrderInfoModel.CorpPolicy;
                            detail.OrderAmount = traOrderInfoModel.Order.TotalMoney;
                            detail.PassengerNameList = traOrderInfoModel.PassengerNameList;
                            detail.TackOffTimeList = traOrderInfoModel.TackOffTimeList;
                            detail.TravelList = traOrderInfoModel.TravelList;
                            detail.OrderIdDes = traOrderInfoModel.Order.OrderId.ToString();
                        }

                    }
                }
            } 
            #endregion


            GetAuditOrderListResponseViewModel responseViewModel =
                Mapper.Map<AuditOrderListModel, GetAuditOrderListResponseViewModel>(list);
            return responseViewModel;
        }
    }
}
