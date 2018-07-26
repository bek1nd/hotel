using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.CorpDepartment;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.Application.Customer
{
    internal class GetCorpBookingDepartListApplication: BaseApplicationService,IGetCorpBookingDepartListApplication
    {
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetCorpBookingDepartListServiceBll _getCorpBookingDepartListServiceBll;

        public GetCorpBookingDepartListApplication(IGetCustomerServiceBll getCustomerServiceBll, IGetCorpBookingDepartListServiceBll getCorpBookingDepartListServiceBll)
        {
            _getCustomerServiceBll = getCustomerServiceBll;
            _getCorpBookingDepartListServiceBll = getCorpBookingDepartListServiceBll;
        }

        public GetCorpBookingDepartListResponseViewModel GetCorpBookingDepartList(GetCorpBookingDepartListRequestViewModel request)
        {
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);
            if (string.IsNullOrEmpty(customerModel?.CorpID))
                throw new Exception("该客户信息异常");

            List<CorpBookingDepartModel> corpBookingDepartModels =
                _getCorpBookingDepartListServiceBll.GetCorpBookingDepartList(request.CustomerCid, customerModel.CorpID);
            GetCorpBookingDepartListResponseViewModel viewModel = new GetCorpBookingDepartListResponseViewModel();
            viewModel.BookingDepartList =
                Mapper.Map<List<CorpBookingDepartModel>, List<CorpBookingDepartViewModel>>(corpBookingDepartModels);
            viewModel.IsAll = _getCorpBookingDepartListServiceBll.IsAll;

            return viewModel;
        }
    }
}
