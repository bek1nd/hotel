using System.Collections.Generic;
using System.Data.Entity;
using Mzl.DomainModel.Customer.Passenger;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Customer;
using Mzl.IDAL.Customer.Corporation;
using Mzl.IDAL.Customer.ContactInfo;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.Corp;
using System;
using System.Linq;
using Mzl.EntityModel.Customer.Contact;

namespace Mzl.BLL.Customer.Customer
{
    public class GetPassengerServiceBll : BaseServiceBll, IGetPassengerServiceBll
    {
        private readonly ICustomerDal _customerDal;
        private readonly ICorporationDal _corporationDal;
        private readonly IContactDal _contactDal;
        private readonly IContactIdentificationDal _contactIdentificationDal;
        private readonly ICorpDepartmentDal _corpDepartmentDal;
        private readonly ICustomerUnionDal _customerUnionDal;

        public GetPassengerServiceBll(ICustomerDal customerDal, ICorporationDal corporationDal,
            IContactDal contactDal, IContactIdentificationDal contactIdentificationDal,
            ICorpDepartmentDal corpDepartmentDal, ICustomerUnionDal customerUnionDal)
        {
            _customerDal = customerDal;
            _corporationDal = corporationDal;
            _contactDal = contactDal;
            _contactIdentificationDal = contactIdentificationDal;
            _corpDepartmentDal = corpDepartmentDal;
            _customerUnionDal = customerUnionDal;
        }

        public List<PassengerInfoModel> GetPassenger(int cid, bool isTemporary ,string searchArgs = "", int isOnline = 0)
        {
            CustomerInfoEntity customer = _customerDal.Find<CustomerInfoEntity>(cid);
            BaseCustomerBll customerBll = null;
            if (!string.IsNullOrEmpty(customer.CorpID))
            {
                CorporationEntity corporationEntity = _corporationDal.Find<CorporationEntity>(customer.CorpID);
                if (corporationEntity.IsAmplitudeCorp == "T" && !isTemporary) //是差旅公司，并且不是查询临客
                {
                    if (customer.IsMaster == "T") //预订员
                    {
                        CustomerUnionInfoEntity customerUnionInfoEntity=
                        _customerUnionDal.Query<CustomerUnionInfoEntity>(n => n.Cid == cid, true).FirstOrDefault();
                        string corpDepartIdList = customerUnionInfoEntity?.CorpDepartIDList;
                        if (!customer.CorpDepartID.HasValue)
                            throw new Exception("当前预定员部门信息异常");

                        if (string.IsNullOrEmpty(corpDepartIdList))
                            corpDepartIdList = customer.CorpDepartID.Value.ToString();

                        customerBll = new TripDepartBookingCustomerBll(customer, corporationEntity.CorpId,
                            corpDepartIdList);
                    }
                    else
                    {
                        customerBll = new TripNotBookingCustomerBll(customer); //非预订员，普通差旅客户
                    }
                }
                else
                {
                    customerBll = new CommonCustomerBll(customer); //临客
                }
            }
            else
            {
                customerBll = new CommonCustomerBll(customer); //临客
            }

            ICustomerVisitor customerVisitor = new CustomerVisitor(_contactDal, _contactIdentificationDal, _customerDal,
                _corpDepartmentDal, searchArgs, base.Context, isOnline);
            List<PassengerInfoModel> passengerInfoModels = customerBll.GetPassenger(customerVisitor);

            return passengerInfoModels;
        }
    }
}
