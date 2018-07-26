using Mzl.IBLL.Customer.ContactInfo.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Identification;
using Mzl.IBLL.Customer.ContactInfo.BLL;
using Mzl.IDAL.Customer.Factory;
using Mzl.DAL.Customer.ContactInfo.Factory;
using Mzl.BLL.Customer.ContactInfo.BLL;

namespace Mzl.BLL.Customer.ContactInfo.Factory
{
    public class ContactIdentificationInfoBLLFactory : IContactIdentificationInfoBLLFactory
    {
        public IContactIdentificationInfoBLL<IdentificationModel> CreateBllObj()
        {
            IContactIdentificationInfoDALFactory factory = new ContactIdentificationInfoDALFactory();
            return new ContactIdentificationInfoBLL(factory.CreateSampleDalObj());
        }

        public IContactIdentificationInfoBLL<IdentificationModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
