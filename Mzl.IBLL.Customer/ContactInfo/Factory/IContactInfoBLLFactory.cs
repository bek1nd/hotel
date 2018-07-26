using Mzl.Common.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IBLL.Customer.ContactInfo.BLL;
using Mzl.DomainModel.Customer.ContactInfo;

namespace Mzl.IBLL.Customer.ContactInfo.Factory
{
    public interface IContactInfoBLLFactory : IBaseBLLFactory<IContactInfoBLL<ContactInfoModel>>
    {
    }
}
