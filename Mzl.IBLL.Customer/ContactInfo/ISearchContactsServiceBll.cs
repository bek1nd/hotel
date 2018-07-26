using System.Collections.Generic;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.ContactInfo
{
    public interface ISearchContactsServiceBll : IBaseServiceBll
    {
        List<ContactInfoModel> SearchContacts(string args, int cid);
    }
}
