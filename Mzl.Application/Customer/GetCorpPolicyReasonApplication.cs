using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.Corporation;
using Mzl.Common.EnumHelper;

namespace Mzl.Application.Customer
{
    internal class GetCorpPolicyReasonApplication: BaseApplicationService,IGetCorpPolicyReasonApplication
    {
        private readonly IGetCustomerCorpPolicyServiceBll _getCustomerCorpPolicyServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;

        public GetCorpPolicyReasonApplication(IGetCustomerCorpPolicyServiceBll getCustomerCorpPolicyServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll)
        {
            _getCustomerCorpPolicyServiceBll = getCustomerCorpPolicyServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
        }

        public GetCorpPolicyReasonResponseViewModel GetCorpPolicyReasonByCorpId(GetCorpPolicyReasonRequestViewModel request)
        {
            CustomerModel customerModel= _getCustomerServiceBll.GetCustomerByCid(request.Cid);
            if (string.IsNullOrEmpty(customerModel.CorpID))
                return null;

            List<ChoiceReasonModel> reasonModels =
                _getCustomerCorpPolicyServiceBll.GetCorpReasonByCorpId(customerModel.CorpID)?
                    .FindAll(n => n.PolicyType == request.ReasonType);

            if (reasonModels == null || reasonModels.Count == 0)
                return null;

            List<KeyValueViewModel<string, string>> viewModels = new List<KeyValueViewModel<string, string>>();
            foreach (var choiceReasonModel in reasonModels)
            {
                KeyValueViewModel<string, string> v = new KeyValueViewModel<string, string>()
                {
                    Key= choiceReasonModel.Reason, Value = choiceReasonModel.Reason
                };
                viewModels.Add(v);
            }
            return new GetCorpPolicyReasonResponseViewModel()
            {
                PolicyReason= viewModels
            };
        }
    }
}
