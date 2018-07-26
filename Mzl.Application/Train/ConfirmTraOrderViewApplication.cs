using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Customer.Corp;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.DomainModel.Customer.ServiceFee;
using Mzl.DomainModel.Train.BaseMaintenance;
using Mzl.Framework.Base;
using Mzl.IApplication.Train;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.IBLL.Customer.Corp;
using Mzl.IBLL.Customer.CostCenter;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Customer.ProjectName;
using Mzl.IBLL.Customer.ServiceFee;
using Mzl.IBLL.Train.TrainWebAccount;
using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.Corporation;
using Mzl.UIModel.Flight;
using Mzl.UIModel.Train.Order;

namespace Mzl.Application.Train
{
    internal class ConfirmTraOrderViewApplication: BaseApplicationService,IConfirmTraOrderViewApplication
    {
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetProjectNameServiceBll _getProjectNameServiceBll;
        private readonly IGetCorpServiceBll _getCorpServiceBll;
        private readonly IGet12306AccountServiceBll _get12306AccountServiceBll;
        private readonly IGetServiceFeeServiceBll _getServiceFeeServiceBll;
        private readonly IGetCostCenterServiceBll _getCostCenterServiceBll;
        private readonly IGetContactAddressServiceBll _getContactAddressServiceBll;

        public ConfirmTraOrderViewApplication(IGetProjectNameServiceBll getProjectNameServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll,
            IGetCorpServiceBll getCorpServiceBll, IGet12306AccountServiceBll get12306AccountServiceBll,
            IGetServiceFeeServiceBll getServiceFeeServiceBll,
            IGetCostCenterServiceBll getCostCenterServiceBll,
            IGetContactAddressServiceBll getContactAddressServiceBll)
        {
            _getProjectNameServiceBll = getProjectNameServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _getCorpServiceBll = getCorpServiceBll;
            _get12306AccountServiceBll = get12306AccountServiceBll;
            _getServiceFeeServiceBll = getServiceFeeServiceBll;
            _getCostCenterServiceBll = getCostCenterServiceBll;
            _getContactAddressServiceBll = getContactAddressServiceBll;
        }

        public ConfirmTraOrderResponseViewModel GetTraComfireOrderView(ConfirmTraOrderRequestViewModel request)
        {
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);

            ConfirmTraOrderResponseViewModel v = new ConfirmTraOrderResponseViewModel();
            v.CName = customerModel.RealName;
            v.EMail = customerModel.Email;
            v.IsMaster = customerModel.IsMaster;
            v.Mobile = customerModel.Mobile;
            if (!string.IsNullOrEmpty(customerModel.CorpID))
            {
                CorporationModel corporationModel = _getCorpServiceBll.GetCorp(customerModel.CorpID);
                v.IsPrint = corporationModel.IsPrint ?? 0;

                //服务费
                ServiceFeeInfoModel serviceFeeInfoModel= _getServiceFeeServiceBll.GetServiceFeeByCorpId(customerModel.CorpID, corporationModel.SfcId ?? 0);
                v.ServiceFee = serviceFeeInfoModel.TrainServiceFee;
                v.TrainGrabTicketServiceFee = serviceFeeInfoModel.TrainGrabTicketServiceFee;

                //获取成本中心
                List<CostCenterModel> costCenterModels =
                    _getCostCenterServiceBll.GetCostCenterByNoDelete(customerModel.CorpID);
                v.CostCenterList = Mapper.Map<List<CostCenterModel>, List<CostCenterViewModel>>(costCenterModels);
            }
            else
            {
                ServiceFeeInfoModel serviceFeeInfoModel = _getServiceFeeServiceBll.GetServiceFeeBySfcid(customerModel.SfcId ?? 0);
                v.ServiceFee = serviceFeeInfoModel.TrainServiceFee;
                v.TrainGrabTicketServiceFee = serviceFeeInfoModel.TrainGrabTicketServiceFee;
            }

            #region 项目名称
            List<ProjectNameModel> projectNameModels = _getProjectNameServiceBll.GetProjectNameByNotDelete(request.Cid);
            v.ProjectNameList = Mapper.Map<List<ProjectNameModel>, List<ProjectNameViewModel>>(projectNameModels);
            #endregion

            #region 证件类型
            v.CardTypeList = (from n in EnumConvert.QueryEnum<CardTypeEnum>()
                              select new SortedListViewModel()
                              {
                                  Key = n.Key,
                                  Value = n.Value
                              }).ToList();
            #endregion

            #region 配送方式
            v.SendTicketTypeList = (from sendTicket in EnumConvert.QueryEnum<SendTicketTypeEnum>()
                                    where sendTicket.Key != (int)SendTicketTypeEnum.Air
                                    select new SortedListViewModel()
                                    {
                                        Key = sendTicket.Key,
                                        Value = sendTicket.Value
                                    }).ToList(); 
            #endregion

            #region 12306帐号
            List<Tra12306AccountModel> accountModels = _get12306AccountServiceBll.GetTra12306Account();
            v.AccountList = (from n in accountModels
                select new SortedListViewModel()
                {
                    Key = n.PassId,
                    Value = n.UserName
                }).ToList();
            #endregion

            #region 支付方式

            v.PayTypeList = new List<SortedListViewModel>
            {
                new SortedListViewModel()
                {
                    Key = PayTypeEnum.Cas.ToString(),
                    Value = PayTypeEnum.Cas.ToDescription()
                },
                new SortedListViewModel()
                {
                    Key = PayTypeEnum.Chk.ToString(),
                    Value = PayTypeEnum.Chk.ToDescription()
                }
            };
            if (!string.IsNullOrEmpty(customerModel.CorpID))
            {
                v.PayTypeList.Add(new SortedListViewModel()
                {
                    Key = PayTypeEnum.Cro.ToString(),
                    Value = PayTypeEnum.Cro.ToDescription()
                });
            }

            #endregion

            List<ContactAddressModel> contactAddressModels =
                _getContactAddressServiceBll.GetContactAddressByCid(request.Cid);
            if (contactAddressModels != null && contactAddressModels.Count > 0)
            {
                v.AddressList = contactAddressModels.Select(n => n.Address).ToList();
            }

            return v;
        }
    }
}
