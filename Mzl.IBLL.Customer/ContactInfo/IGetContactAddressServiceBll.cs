using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.ContactInfo
{
    public interface IGetContactAddressServiceBll : IBaseServiceBll
    {
        List<ContactAddressModel> GetContactAddressByCid(int cid);
    }
}
