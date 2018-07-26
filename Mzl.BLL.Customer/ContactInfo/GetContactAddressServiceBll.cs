using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.EntityModel.Customer.Contact;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.IDAL.Customer.ContactInfo;

namespace Mzl.BLL.Customer.ContactInfo
{
    internal class GetContactAddressServiceBll: BaseServiceBll,IGetContactAddressServiceBll
    {
        private readonly IContactAddressDal _contactAddressDal;

        public GetContactAddressServiceBll(IContactAddressDal contactAddressDal)
        {
            _contactAddressDal = contactAddressDal;
        }

        public List<ContactAddressModel> GetContactAddressByCid(int cid)
        {
            List<ContactAddressEntity> contactAddressEntities =
                _contactAddressDal.Query<ContactAddressEntity>(n => n.Cid == cid && !string.IsNullOrEmpty(n.Address),
                    true).ToList();

            return Mapper.Map<List<ContactAddressEntity>, List<ContactAddressModel>>(contactAddressEntities);
        }
    }
}
