using Mzl.IDAL.Customer.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DAL.Customer.ContactInfo.DAL;
using Mzl.IDAL.Customer.DAL;

namespace Mzl.DAL.Customer.ContactInfo.Factory
{
    public class ContactInfoDALFactory: IContactInfoDALFactory
    {
        public IContactInfoDAL CreateSampleDalObj()
        {
            return new ContactInfoDAL();
        }
    }
}
