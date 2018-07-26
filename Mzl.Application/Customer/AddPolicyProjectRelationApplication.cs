using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Customer.CorpPolicy;

namespace Mzl.Application.Customer
{
    internal class AddPolicyProjectRelationApplication : BaseApplicationService,IAddPolicyProjectRelationApplication
    {
        private readonly IAddPolicyProjectRelationServiceBll _addPolicyProjectRelationServiceBll;
        public AddPolicyProjectRelationApplication(IAddPolicyProjectRelationServiceBll addPolicyProjectRelationServiceBll)
        {
            _addPolicyProjectRelationServiceBll = addPolicyProjectRelationServiceBll;
        }
        public AddPolicyProjectRelationResponseViewModel AddPolicyProjectRelation(
            AddPolicyProjectRelationRequestViewModel request)
        {
            CorpPolicyConfigProjectModel query = new CorpPolicyConfigProjectModel()
            {
                PolicyId = request.PolicyId
            };

            if (request.ProjectIdList != null)
            {
                query.ProjectIdList = new List<KeyValueModel<int, bool>>();
                foreach (var keyValueViewModel in request.ProjectIdList)
                {
                    query.ProjectIdList.Add(new KeyValueModel<int, bool>()
                    {
                        Key = keyValueViewModel.Key,
                        Value = keyValueViewModel.Value
                    });
                }
            }

            bool flag =
                _addPolicyProjectRelationServiceBll.AddPolicyProjectRelation(query);

            return new AddPolicyProjectRelationResponseViewModel() {IsSuccessed = flag};
        }
    }
}
