using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Customer.Identification;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Customer.Customer;
using Mzl.UIModel.Customer.Identification;

namespace Mzl.Application.Customer
{
    internal class GetCustomerInfoApplication: BaseApplicationService,IGetCustomerInfoApplication
    {
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetContactServiceBll _getContactServiceBll;

        public GetCustomerInfoApplication(IGetCustomerServiceBll getCustomerServiceBll, IGetContactServiceBll getContactServiceBll)
        {
            _getCustomerServiceBll = getCustomerServiceBll;
            _getContactServiceBll = getContactServiceBll;
        }

        public GetCustomerInfoResponseViewModel GetCustomerInfoByCid(GetCustomerInfoRequestViewModel request)
        {
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);

            GetCustomerInfoResponseViewModel viewMode =
                Mapper.Map<CustomerModel, GetCustomerInfoResponseViewModel>(customerModel);
            if (customerModel.Corporation != null)
            {
                viewMode.CorpName = customerModel.Corporation?.CorpName;
                viewMode.IsCorpSystemCustomer = customerModel.Corporation?.IsAmplitudeCorp;
                viewMode.IsAllowUserInsurance = customerModel.Corporation.IsAllowUserInsurance;
                //赋值公司个性化信息
                viewMode.IsHeightSeat = customerModel.Corporation.IsHeightSeat;
                viewMode.IsShareFly = customerModel.Corporation.IsShareFly;
                viewMode.IsXYPrice = customerModel.Corporation.IsXYPrice;
                viewMode.IsAllSeat = customerModel.Corporation.IsAllSeat;
                viewMode.IsTravelReason = customerModel.Corporation.IsTravelReason;
                viewMode.IsNoteVerify = customerModel.Corporation.IsNoteVerify;
                viewMode.IsTraAllSeat = customerModel.Corporation.IsTraAllSeat;
            }
            GetContactInfoModel contactInfoModel = _getContactServiceBll.GetCorpContactByCid(viewMode.Cid);
            viewMode.ContactId = contactInfoModel?.ContactId;
            if (contactInfoModel?.IdentificationList != null)
            {
                viewMode.IdentificationList = Mapper
                    .Map<List<IdentificationModel>, List<IdentificationViewModel>>(contactInfoModel.IdentificationList);
            }
            
            //读取默认的证件信息
            if (contactInfoModel !=null && (contactInfoModel.DefaultIdentificationId ?? 0) >0 && viewMode.IdentificationList != null)
            {
                foreach (
                    var identificationViewModel in
                        viewMode.IdentificationList.Where(
                            identificationViewModel =>
                                identificationViewModel.Iid == (contactInfoModel.DefaultIdentificationId ?? 0)))
                {
                    identificationViewModel.IsDefault = 1;
                }

            }

            return viewMode;
        }
    }
}
