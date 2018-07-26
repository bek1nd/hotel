using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Customer.Contact;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.IDAL.Customer.ContactInfo;

namespace Mzl.BLL.Customer.ContactInfo
{
    internal class AddContactAddressServiceBll : BaseServiceBll, IAddContactAddressServiceBll
    {
        private readonly IContactAddressDal _contactAddressDal;

        public AddContactAddressServiceBll(IContactAddressDal contactAddressDal)
        {
            _contactAddressDal = contactAddressDal;
        }

        public bool AddAddress(string address, int cid, string oid)
        {
            ContactAddressEntity entity = _contactAddressDal.Insert<ContactAddressEntity>(new ContactAddressEntity()
            {
                Cid = cid,
                Address = address,
                Oid = oid,
                LastUpdateTime = DateTime.Now,
                Status = "T"
            });

            if (entity.Aid == 0)
                return false;

            return true;
        }
    }
}
