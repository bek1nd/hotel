using Mzl.Common.Factory;
using Mzl.DomainModel.Customer.Identification;
using Mzl.IBLL.Customer.ContactInfo.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.ContactInfo.Factory
{
    public interface IContactIdentificationInfoBLLFactory :
        IBaseBLLFactory<IContactIdentificationInfoBLL<IdentificationModel>>
    {
    }
}
