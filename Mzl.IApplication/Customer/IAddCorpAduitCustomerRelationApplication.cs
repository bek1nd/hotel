using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.CorpAduit;
using Mzl.UIModel.Customer.CorpPolicy;

namespace Mzl.IApplication.Customer
{
    public interface IAddCorpAduitCustomerRelationApplication : IBaseApplication
    {
        AddCorpAduitCustomerRelationResponseViewModel AddCorpAduitCustomerRelation(
            AddCorpAduitCustomerRelationRequestViewModel request);
    }
}
