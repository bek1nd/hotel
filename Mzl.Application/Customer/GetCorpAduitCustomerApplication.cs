using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.UIModel.Customer.CorpAduit;
using Mzl.UIModel.Customer.CorpPolicy;

namespace Mzl.Application.Customer
{
    public class GetCorpAduitCustomerApplication: BaseApplicationService,IGetCorpAduitCustomerApplication
    {
        private readonly IGetCorpAduitCustomerServiceBll _getCorpAduitCustomerServiceBll;

        public GetCorpAduitCustomerApplication(IGetCorpAduitCustomerServiceBll getCorpAduitCustomerServiceBll)
        {
            _getCorpAduitCustomerServiceBll = getCorpAduitCustomerServiceBll;
        }

        public GetCorpAduitCustomerResponseViewModel GetCorpAduitCustomer(GetCorpAduitCustomerRequestViewModel request)
        {
            List<CorpAduitCustomerModel> customerModels =
                 _getCorpAduitCustomerServiceBll.GetCorpAduitCustomer(request.CorpId, request.AduitId);

            GetCorpAduitCustomerResponseViewModel viewModel = new GetCorpAduitCustomerResponseViewModel();
            viewModel.CustomerList =
                Mapper.Map<List<CorpAduitCustomerModel>, List<CorpAduitCustomerViewModel>>(customerModels);

            return viewModel;
        }
    }
}
