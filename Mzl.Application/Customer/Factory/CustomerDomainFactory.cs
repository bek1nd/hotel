using Mzl.IApplication.Customer.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Application.Customer.Domain;
using Mzl.IApplication.Customer.Domain;
using Mzl.IBLL.Customer.Verify.BLL;
using Mzl.DomainModel.Customer.Base;
using Mzl.IBLL.Customer.Verify.Factory;
using Mzl.BLL.Customer.Verify.Factory;
using Mzl.IBLL.Customer.Customer.Factory;
using Mzl.BLL.Customer.Customer.Factory;
using Mzl.IBLL.Customer.Customer.BLL;
using Mzl.IBLL.Customer.ContactInfo.Factory;
using Mzl.BLL.Customer.ContactInfo.Factory;
using Mzl.IBLL.Customer.ContactInfo.BLL;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Customer.Identification;
using Mzl.IBLL.Customer.CorpDepartment.BLL;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.IBLL.Customer.CorpDepartment.Factory;
using Mzl.BLL.Customer.CorpDepartment.Factory;
using Mzl.DomainModel.Customer.Corp;
using Mzl.IBLL.Customer.Corp.BLL;
using Mzl.IBLL.Customer.Corp.Factory;
using Mzl.BLL.Customer.Corp.Factory;
using Mzl.IBLL.Customer.Customer;

namespace Mzl.Application.Customer.Factory
{
    public class CustomerDomainFactory : ICustomerDomainFactory
    {
        public ICustomerDomain CreateDomainObj()
        {
            ICustomerBLLFactory factory = new CustomerBLLFactory();
            ICustomerBLL<CustomerInfoModel> bll = factory.CreateBllObj();
            return new CustomerDomain(bll);
        }

        public ICustomerDomain CreateVerifyCustomerDomainObj()
        {
            ICustomerVerifyBLLFactory factory = new CustomerVerifyBLLFactory();
            ICustomerVerifyBLL<CustomerInfoModel> verifyBll = factory.CreateBllObj();
            IAddAppClientIdServiceBll addAppClientIdServiceBll= CustomerFactory.CreateObj();
            ICorporationBLLFactory corporationBllFactory = new CorporationBLLFactory();
            ICorporationBLL<CorporationModel> corporationBll = corporationBllFactory.CreateBllObj();
            return new CustomerDomain(verifyBll, addAppClientIdServiceBll, corporationBll);
        }

        public ICustomerDomain CreatePassengerInfoDomainObj()
        {
            ICustomerBLLFactory factory = new CustomerBLLFactory();
            ICustomerBLL<CustomerInfoModel> bll = factory.CreateBllObj();
            IContactInfoBLLFactory contactInfoBllFactory = new ContactInfoBLLFactory();
            IContactInfoBLL<ContactInfoModel> contactInfoBll = contactInfoBllFactory.CreateBllObj();
            IContactIdentificationInfoBLLFactory identificationInfoBllFactory =
                new ContactIdentificationInfoBLLFactory();
            IContactIdentificationInfoBLL < IdentificationModel > identificationInfoBll = identificationInfoBllFactory.CreateBllObj();
            ICorporationBLLFactory corporationBllFactory = new CorporationBLLFactory();
            ICorporationBLL<CorporationModel> corporationBll = corporationBllFactory.CreateBllObj();
            return new CustomerDomain(bll, contactInfoBll, identificationInfoBll, corporationBll);
        }

        public ICustomerDomain CreateQueryTravelViewDomainObj()
        {
            ICustomerBLLFactory customerBllFactory = new CustomerBLLFactory();
            ICustomerBLL<CustomerInfoModel> customerBll = customerBllFactory.CreateBllObj();
            ICorpDepartmentBLLFactory corpDepartmentBllFactory = new CorpDepartmentBLLFactory();
            ICorpDepartmentBLL<CorpDepartmentModel> corpDepartmentBll = corpDepartmentBllFactory.CreateBllObj();
            ICustomerUnionBLLFactory customerUnionBllFactory=new CustomerBLLFactory();
            ICustomerUnionBLL<CustomerUnionInfoModel> customerUnionBll = customerUnionBllFactory.CreateBllObj();
            ICorporationBLLFactory corporationBllFactory = new CorporationBLLFactory();
            ICorporationBLL<CorporationModel> corporationBll = corporationBllFactory.CreateBllObj();
            return new CustomerDomain(customerBll, corpDepartmentBll, customerUnionBll, corporationBll);
        }
    }
}
