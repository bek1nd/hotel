using Mzl.IBLL.Customer.ContactInfo.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.IBLL.Customer.ContactInfo.BLL;
using Mzl.IDAL.Customer.Factory;
using Mzl.DAL.Customer.ContactInfo.Factory;
using Mzl.BLL.Customer.ContactInfo.BLL;

namespace Mzl.BLL.Customer.ContactInfo.Factory
{
    public class ContactInfoBLLFactory : IContactInfoBLLFactory
    {
        public IContactInfoBLL<ContactInfoModel> CreateBllObj()
        {
            IContactInfoDALFactory factory = new ContactInfoDALFactory();
            return new ContactInfoBLL(factory.CreateSampleDalObj());
        }

        public IContactInfoBLL<ContactInfoModel> CreateSampleBllObj()
        {
            return null;
        }
    }
}
