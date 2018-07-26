using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Flight;
using Mzl.IDAL.Customer.Corporation;
using Mzl.EntityModel.Customer.Corporation.Department;
using AutoMapper;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.IDAL.Customer.ContactInfo;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.DomainModel.Customer.ContactInfo;

namespace Mzl.BLL.Customer.Customer
{
    public class GetCorpPassengerCustomerServiceBll : BaseServiceBll, IGetCorpPassengerCustomerServiceBll
    {
        private readonly ICorpDepartmentDal _corpDepartmentDal;
        private readonly IGetContactBll _getContactBll;
        private readonly IGetCustomerBll _customerBll;

        public GetCorpPassengerCustomerServiceBll(ICorpDepartmentDal corpDepartmentDal,
            IGetContactBll getContactBll, IGetCustomerBll customerBll) : base()
        {
            _corpDepartmentDal = corpDepartmentDal;
            _getContactBll = getContactBll;
            _customerBll = customerBll;
        }


        public List<CorpPassengerCustomerModel> GetCorpPassengerCustomer(List<int> contactList)
        {

            List<ContactInfoModel> contactInfoModels = _getContactBll.GetContactByContactId(contactList);

            List<CustomerModel> customerModels =
                _customerBll.GetCustomerByCidList(contactInfoModels.Select(n => n.Cid ?? 0).ToList());

            List<int> corpDepartIdList = customerModels.Select(x => x.CorpDepartID ?? 0).ToList();
            List<CorpDepartmentEntity> departments =
                _corpDepartmentDal.Query<CorpDepartmentEntity>(
                    n => corpDepartIdList.Contains(n.Id)).ToList();

            List<CorpDepartmentModel> corpDepartmentModels =
                Mapper.Map<List<CorpDepartmentEntity>, List<CorpDepartmentModel>>(departments);

            List<CorpPassengerCustomerModel> corpPassengerCustomerModels = new List<CorpPassengerCustomerModel>();
            foreach (var customer in customerModels)
            {
                CorpPassengerCustomerModel corpPassengerCustomerModel =
                    new CorpPassengerCustomerModel().ConvertFatherToSon(customer);
                corpPassengerCustomerModel.Department =
                    corpDepartmentModels.Find(n => n.Id == (customer.CorpDepartID ?? 0));
                corpPassengerCustomerModels.Add(corpPassengerCustomerModel);
            }

            return corpPassengerCustomerModels;
        }
    }
}
