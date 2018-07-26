using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.Application.Customer
{
    internal class AddCorpAduitDepartmentRelationApplication: BaseApplicationService,IAddCorpAduitDepartmentRelationApplication
    {
        private readonly IAddCorpAduitDepartmentRelationServiceBll _addCorpAduitDepartmentRelationServiceBll;

        public AddCorpAduitDepartmentRelationApplication(IAddCorpAduitDepartmentRelationServiceBll addCorpAduitDepartmentRelationServiceBll)
        {
            _addCorpAduitDepartmentRelationServiceBll = addCorpAduitDepartmentRelationServiceBll;
        }

        public AddCorpAduitDepartmentRelationResponseViewModel AddCorpAduitDepartmentRelation(
            AddCorpAduitDepartmentRelationRequestViewModel request)
        {
            CorpAduitConfigDepartmentModel query = new CorpAduitConfigDepartmentModel()
            {
                AduitId = request.AduitId
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
                _addCorpAduitDepartmentRelationServiceBll.AddCorpAduitDepartmentRelation(query);

            return new AddCorpAduitDepartmentRelationResponseViewModel() { IsSuccessed = flag };
        }
    }
}
