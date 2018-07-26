using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.Application.Customer
{
    public class AddCorpAduitProjectRelationApplication : BaseApplicationService,
        IAddCorpAduitProjectRelationApplication
    {
        private readonly IAddCorpAduitProjectRelationServiceBll _addCorpAduitProjectRelationServiceBll;

        public AddCorpAduitProjectRelationApplication(IAddCorpAduitProjectRelationServiceBll addCorpAduitProjectRelationServiceBll)
        {
            _addCorpAduitProjectRelationServiceBll = addCorpAduitProjectRelationServiceBll;
        }

        public AddCorpAduitProjectRelationResponseViewModel AddCorpAduitProjectRelation(
            AddCorpAduitProjectRelationRequestViewModel request)
        {
            CorpAduitConfigProjectModel query = new CorpAduitConfigProjectModel()
            {
                AduitId = request.AduitId
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
                _addCorpAduitProjectRelationServiceBll.AddCorpAduitProjectRelation(query);

            return new AddCorpAduitProjectRelationResponseViewModel() {IsSuccessed = flag};
        }
    }
}
