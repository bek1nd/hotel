using System.Collections.Generic;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Customer.CorpPolicy;

namespace Mzl.Application.Customer
{
    public class AddPolicyDepartmentRelationApplication : BaseApplicationService, IAddPolicyDepartmentRelationApplication
    {
        private readonly IAddPolicyDepartmentRelationServiceBll _addPolicyDepartmentRelationServiceBll;

        public AddPolicyDepartmentRelationApplication(IAddPolicyDepartmentRelationServiceBll addPolicyDepartmentRelationServiceBll)
        {
            _addPolicyDepartmentRelationServiceBll = addPolicyDepartmentRelationServiceBll;
        }

        public AddPolicyDepartmentRelationResponseViewModel AddPolicyDepartmentRelation(
            AddPolicyDepartmentRelationRequestViewModel request)
        {
            CorpPolicyConfigDepartmentModel query = new CorpPolicyConfigDepartmentModel()
            {
                PolicyId = request.PolicyId
            };

            if (request.DepartmentIdList != null)
            {
                query.DepartmentIdList = new List<KeyValueModel<int, bool>>();
                foreach (var keyValueViewModel in request.DepartmentIdList)
                {
                    query.DepartmentIdList.Add(new KeyValueModel<int, bool>()
                    {
                        Key = keyValueViewModel.Key,
                        Value = keyValueViewModel.Value
                    });
                }
            }

            bool flag =
                _addPolicyDepartmentRelationServiceBll.AddPolicyDepartmentRelation(query);

            return new AddPolicyDepartmentRelationResponseViewModel() { IsSuccessed = flag };
        }
    }
}
