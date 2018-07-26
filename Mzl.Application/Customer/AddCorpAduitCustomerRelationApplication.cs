using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.Application.Customer
{
    public class AddCorpAduitCustomerRelationApplication: BaseApplicationService, IAddCorpAduitCustomerRelationApplication
    {
        private readonly IAddCorpAduitCustomerRelationServiceBll _addCorpAduitCustomerRelationServiceBll;

        public AddCorpAduitCustomerRelationApplication(IAddCorpAduitCustomerRelationServiceBll addCorpAduitCustomerRelationServiceBll)
        {
            _addCorpAduitCustomerRelationServiceBll = addCorpAduitCustomerRelationServiceBll;
        }

        public AddCorpAduitCustomerRelationResponseViewModel AddCorpAduitCustomerRelation(
            AddCorpAduitCustomerRelationRequestViewModel request)
        {
            bool flag =
               _addCorpAduitCustomerRelationServiceBll.AddCorpAduitCustomerRelation(new CorpAduitConfigCustomerModel()
               {
                   CidList = request.CidList,
                   AduitId = request.AduitId
               });
            return new AddCorpAduitCustomerRelationResponseViewModel() { IsSuccessed = flag };
        }
    }
}
