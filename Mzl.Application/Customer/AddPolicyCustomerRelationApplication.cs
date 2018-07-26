using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Customer.CorpPolicy;

namespace Mzl.Application.Customer
{
    public class AddPolicyCustomerRelationApplication : BaseApplicationService, IAddPolicyCustomerRelationApplication
    {
        private readonly IAddPolicyCustomerRelationServiceBll _addPolicyCustomerRelationServiceBll;

        public AddPolicyCustomerRelationApplication(IAddPolicyCustomerRelationServiceBll addPolicyCustomerRelationServiceBll)
        {
            _addPolicyCustomerRelationServiceBll = addPolicyCustomerRelationServiceBll;
        }

        public AddPolicyCustomerRelationResponseViewModel AddPolicyCustomerRelation(
            AddPolicyCustomerRelationRequestViewModel request)
        {

            bool flag =
                _addPolicyCustomerRelationServiceBll.AddPolicyCustomerRelation(new CorpPolicyConfigCustomerModel()
                {
                    CidList = request.CidList,
                    PolicyId = request.PolicyId
                });
            return new AddPolicyCustomerRelationResponseViewModel() {IsSuccessed = flag};
        }
    }
}
