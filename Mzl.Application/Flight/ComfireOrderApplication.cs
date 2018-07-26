using AutoMapper;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.DomainModel.Customer.Identification;
using Mzl.DomainModel.Customer.Passenger;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Customer.CostCenter;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Customer.ProjectName;
using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.Corporation;
using Mzl.UIModel.Customer.Identification;
using Mzl.UIModel.Flight;
using Mzl.UIModel.Passenger;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.Insurance;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Customer.Corp;
using Mzl.IBLL.Common.Insurance;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.IBLL.Customer.Corp;

namespace Mzl.Application.Flight
{
    internal class ComfireOrderApplication: BaseApplicationService, IComfireOrderApplication
    {
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetProjectNameServiceBll _getProjectNameServiceBll;
        private readonly IGetInsuranceCompanyServiceBll _getInsuranceCompanyServiceBll;
        private readonly IGetCorpServiceBll _getCorpServiceBll;
        private readonly IGetCostCenterServiceBll _getCostCenterServiceBll;
        private readonly IGetContactAddressServiceBll _getContactAddressServiceBll;


        public ComfireOrderApplication(IGetProjectNameServiceBll getProjectNameServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll, IGetInsuranceCompanyServiceBll getInsuranceCompanyServiceBll,
             IGetCorpServiceBll getCorpServiceBll, IGetCostCenterServiceBll getCostCenterServiceBll, IGetContactAddressServiceBll getContactAddressServiceBll)
        {
            _getProjectNameServiceBll = getProjectNameServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _getInsuranceCompanyServiceBll = getInsuranceCompanyServiceBll;
            _getCorpServiceBll = getCorpServiceBll;
            _getCostCenterServiceBll = getCostCenterServiceBll;
            _getContactAddressServiceBll = getContactAddressServiceBll;
        }

        /// <summary>
        /// 显示创建订单页面
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ComfireFlightOrderResponseViewModel ComfireOrderViewApplicationService(
            ComfireFlightOrderRequestViewModel request)
        {
            CustomerModel  customerModel= _getCustomerServiceBll.GetCustomerByCid(request.Cid);
            List<ProjectNameModel> projectNameModels = _getProjectNameServiceBll.GetProjectNameByNotDelete(request.Cid);

            List<InsuranceCompanyModel> insuranceCompanyModels = _getInsuranceCompanyServiceBll.GetInsuranceCompany();
            if (request.OrderSource != "O")
            {
                insuranceCompanyModels = insuranceCompanyModels?.FindAll(n => n.UpOnLine == "T");
            }

            ComfireFlightOrderResponseViewModel v = new ComfireFlightOrderResponseViewModel();
            v.CName = customerModel.RealName;
            v.EMail = customerModel.Email;
            v.IsMaster = customerModel.IsMaster;
            v.Mobile = customerModel.Mobile;
            if (!string.IsNullOrEmpty(customerModel.CorpID))
            {
                CorporationModel corporationModel= _getCorpServiceBll.GetCorp(customerModel.CorpID);
                v.IsPrint = corporationModel.IsPrint ?? 0;
                //获取成本中心
                List<CostCenterModel> costCenterModels =
                    _getCostCenterServiceBll.GetCostCenterByNoDelete(customerModel.CorpID);
                v.CostCenterList = Mapper.Map<List<CostCenterModel>, List<CostCenterViewModel>>(costCenterModels);
            }

            v.ProjectNameList = Mapper.Map<List<ProjectNameModel>, List<ProjectNameViewModel>>(projectNameModels);
            v.InsuranceList = (from n in insuranceCompanyModels
                select new FltInsuranceViewModel()
                {
                    ProductId = n.CompanyID,
                    ProductName = n.ProductName,
                    SalePrice = n.FacePrice
                }).ToList();

            v.CardTypeList = (from n in EnumConvert.QueryEnum<CardTypeEnum>()
                                                      select new SortedListViewModel()
                                                      {
                                                          Key = n.Key,
                                                          Value = n.Value
                                                      }).ToList();

            v.SendTicketTypeList = (from sendTicket in EnumConvert.QueryEnum<SendTicketTypeEnum>()
                where
                    sendTicket.Key != (int) SendTicketTypeEnum.TraAfter &&
                    sendTicket.Key != (int) SendTicketTypeEnum.TraBefore
                select new SortedListViewModel()
                {
                    Key = sendTicket.Key,
                    Value = sendTicket.Value
                }).ToList();

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
