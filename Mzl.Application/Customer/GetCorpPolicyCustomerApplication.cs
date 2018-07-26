using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Customer.CorpPolicy;
using Mzl.DomainModel.Customer.CorpPolicy;

namespace Mzl.Application.Customer
{
    public class GetCorpPolicyCustomerApplication : BaseApplicationService, IGetCorpPolicyCustomerApplication
    {
        private readonly IGetCorpPolicyCustomerServiceBll _getCorpPolicyCustomerServiceBll;

        public GetCorpPolicyCustomerApplication(IGetCorpPolicyCustomerServiceBll getCorpPolicyCustomerServiceBll)
        {
            _getCorpPolicyCustomerServiceBll = getCorpPolicyCustomerServiceBll;
        }

        public GetCorpPolicyCustomerResponseViewModel GetCorpPolicyCustomer(
            GetCorpPolicyCustomerRequestViewModel request)
        {
            List<CorpPolicyCustomerModel> customerModels =
                _getCorpPolicyCustomerServiceBll.GetCorpPolicyCustomer(request.CorpId, request.PolicyId);

            GetCorpPolicyCustomerResponseViewModel viewModel = new GetCorpPolicyCustomerResponseViewModel();
            viewModel.CustomerList =
                Mapper.Map<List<CorpPolicyCustomerModel>, List<CorpPolicyCustomerViewModel>>(customerModels);

            return viewModel;
        }
    }
}
