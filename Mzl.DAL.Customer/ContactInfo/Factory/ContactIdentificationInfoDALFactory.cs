using Mzl.IDAL.Customer.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IDAL.Customer.DAL;
using Mzl.DAL.Customer.ContactInfo.DAL;

namespace Mzl.DAL.Customer.ContactInfo.Factory
{
    public class ContactIdentificationInfoDALFactory : IContactIdentificationInfoDALFactory
    {
        public IContactIdentificationInfoDAL CreateSampleDalObj()
        {
            return new ContactIdentificationInfoDAL();
        }
    }
}
