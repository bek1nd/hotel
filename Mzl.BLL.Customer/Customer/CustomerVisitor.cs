using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Identification;
using Mzl.DomainModel.Customer.Passenger;
using Mzl.IDAL.Customer.ContactInfo;
using Mzl.EntityModel.Customer.Contact;
using AutoMapper;
using Mzl.IDAL.Customer.Customer;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.Department;
using Mzl.Framework.Base;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.Customer
{
    public class CustomerVisitor: ICustomerVisitor
    {
        private readonly IContactDal _contactDal;
        private readonly IContactIdentificationDal _contactIdentificationDal;
        private readonly ICustomerDal _customerDal;
        private readonly ICorpDepartmentDal _corpDepartmentDal;
        private readonly string _searchArgs;
        private readonly DbContext _context;
        private readonly int _isOnline;

        public CustomerVisitor(IContactDal contactDal, IContactIdentificationDal contactIdentificationDal,
            ICustomerDal customerDal, ICorpDepartmentDal corpDepartmentDal, string searchArgs, DbContext context, int isOnline=0)
        {
            _contactDal = contactDal;
            _contactIdentificationDal = contactIdentificationDal;
            _customerDal = customerDal;
            _searchArgs = searchArgs;
            _corpDepartmentDal = corpDepartmentDal;
            _context = context;
            _isOnline = isOnline;
        }

        /// <summary>
        /// 非差旅客户获取乘客信息
        /// </summary>
        /// <param name="customerBll"></param>
        /// <returns></returns>
        public List<PassengerInfoModel> GetPassenger(CommonCustomerBll customerBll)
        {
            var customer=customerBll.Customer;
            IQueryable<ContactInfoEntity> contactInfoEntitieses =
                _contactDal.Query<ContactInfoEntity>(
                    n => n.Cid == customer.Cid && n.IsPassenger == "T" && (n.IsDel ?? "F") == "F" && !n.PCid.HasValue, true);
            contactInfoEntitieses = SearchContact(contactInfoEntitieses);

            if (_isOnline == 1)//如果是线上查询临客，则只显示线上新增的临客；线下查询不做限制
            {
                contactInfoEntitieses = contactInfoEntitieses.Where(n => n.IsOnline == 1);
            }

            List<ContactInfoEntity> contactList = contactInfoEntitieses.ToList();
            return ConvertContactToPassenger(contactList, null);
        }
        /// <summary>
        /// 差旅预订员客户获取乘客信息
        /// </summary>
        /// <param name="customerBll"></param>
        /// <returns></returns>
        public List<PassengerInfoModel> GetPassenger(TripBookingCustomerBll customerBll)
        {
            if(!customerBll.DepartId.HasValue)
                throw new Exception("请传入departId参数");
            //获取部门Id对应的客户信息
            List<CustomerInfoEntity> departCustomerList =
                _customerDal.Query<CustomerInfoEntity>(
                    n => n.CorpDepartID == customerBll.DepartId && (n.IsDel ?? "F") == "F" && n.IsLock == "F").ToList();

            List<int> cidList = new List<int>();
            if (departCustomerList == null)
            {
                departCustomerList = new List<CustomerInfoEntity>();
            }
            departCustomerList.ForEach(n => cidList.Add(n.Cid));

            IQueryable<ContactInfoEntity> contactInfoEntitieses =
                _contactDal.Query<ContactInfoEntity>(n => cidList.Contains(n.PCid??0));
            contactInfoEntitieses = SearchContact(contactInfoEntitieses);//按条件查询乘客信息
            List<ContactInfoEntity>  contactList = contactInfoEntitieses.ToList();
            return ConvertContactToPassenger(contactList, departCustomerList);
        }

        /// <summary>
        /// 差旅预订员客户获取所有公司的乘客信息
        /// </summary>
        /// <param name="customerBll"></param>
        /// <returns></returns>
        public List<PassengerInfoModel> GetPassenger(TripDepartBookingCustomerBll customerBll)
        {
            if (string.IsNullOrEmpty(customerBll.CorpId))
                throw new Exception("请传入CorpId参数");
            _context.Configuration.LazyLoadingEnabled = false;

            //int corpDepartId = (customerBll.Customer?.CorpDepartID ?? 0);
            List<string> corpDepartIdStrList = customerBll.CorpDepartIdList.Split(',').ToList();
            List<int> corpDepartIdList = new List<int>();
            foreach (var s in corpDepartIdStrList)
            {
                corpDepartIdList.Add(Convert.ToInt32(s));
            }


            IQueryable<PassengerInfoModel> select = from contact in
                _context.Set<ContactInfoEntity>().AsNoTracking()
                join customer in _context.Set<CustomerInfoEntity>().AsNoTracking() on contact.PCid equals
                    customer.Cid into c
                from customer in c.DefaultIfEmpty()
                where
                    customer.CorpID == customerBll.CorpId && (customer.IsDel ?? "F") == "F" && customer.IsLock == "F" &&
                    !string.IsNullOrEmpty(customer.DepartmentName) && customer.CorpDepartID.HasValue

                select new PassengerInfoModel()
                {
                    ContactId = contact.Contactid,
                    PassengerName = customer.RealName,
                    Mobile = customer.Mobile,
                    Phone = customer.Phone,
                    Fax = customer.Fax,
                    Email = customer.Email,
                    DepartmentName = customer.DepartmentName,
                    Cid = customer.Cid,
                    DefaultIdentificationId = contact.DefaultIdentificationId,
                    CorpDepartId = customer.CorpDepartID
                };
            if (!corpDepartIdList.Contains(0))
                select = select.Where(n => corpDepartIdList.Contains(n.CorpDepartId ?? 0));

            //if (customerBll.Customer?.CorpID.ToUpper() == "TTL" || customerBll.Customer?.CorpID.ToUpper() == "MZL")
            //{
            //    int cid = (customerBll.Customer?.Cid ?? 0);
            //    if (cid != 5718)
            //    {
            //        select = select.Where(n => n.CorpDepartId == corpDepartId);
            //    }
            //}


            if (!string.IsNullOrEmpty(_searchArgs))
            {
                select =
                    select.Where(n => n.PassengerName.Contains(_searchArgs)
                                      || n.Mobile == _searchArgs);
            }

            select = select.Take(50).OrderBy(n => n.PassengerName);


            List<PassengerInfoModel> passengerInfoModels = select.ToList();

            List<int> contactIdList = passengerInfoModels.Select(n => n.ContactId).ToList();
            List<ContactIdentificationInfoEntity> identificationList =
                _contactIdentificationDal.Query<ContactIdentificationInfoEntity>(
                    n => contactIdList.Contains(n.Contactid)).ToList();
            if (identificationList == null || identificationList.Count == 0)
            {
                identificationList = new List<ContactIdentificationInfoEntity>();
            }

            foreach (PassengerInfoModel passengerInfoModel in passengerInfoModels)
            {
                var tempCardList =
                    identificationList.FindAll(n => n.Contactid == passengerInfoModel.ContactId);

                #region 将默认证件放在首位

                int defaultCardType = passengerInfoModel.DefaultIdentificationId ?? 0;
                var tempCard = tempCardList.Find(n => n.Iid == defaultCardType);
                if (tempCard != null)
                {
                    tempCardList.RemoveAll(n => n.Iid == defaultCardType);
                    tempCardList = tempCardList.OrderBy(n => n.Iid).ToList();
                    tempCardList.Add(tempCard);
                    tempCardList.Reverse();
                }

                #endregion

                passengerInfoModel.IdentificationList = Mapper
                    .Map<List<ContactIdentificationInfoEntity>, List<IdentificationModel>>(tempCardList);
            }


            return passengerInfoModels;
        }


        /// <summary>
        /// 差旅非预订员客户获取乘客信息
        /// </summary>
        /// <param name="customerBll"></param>
        /// <returns></returns>
        public List<PassengerInfoModel> GetPassenger(TripNotBookingCustomerBll customerBll)
        {
            IQueryable<ContactInfoEntity> contactInfoEntitieses =
                _contactDal.Query<ContactInfoEntity>(n => n.PCid == customerBll.Customer.Cid && n.IsPassenger == "T");
            contactInfoEntitieses = SearchContact(contactInfoEntitieses);
            List<ContactInfoEntity>  contactList = contactInfoEntitieses.ToList();
            return ConvertContactToPassenger(contactList, new List<CustomerInfoEntity>() {customerBll.Customer});
        }

        #region 私有方法
        /// <summary>
        /// 将联系人信息转成乘客信息
        /// </summary>
        /// <returns></returns>
        private List<PassengerInfoModel> ConvertContactToPassenger(List<ContactInfoEntity> contactInfoList, List<CustomerInfoEntity> customerList)
        {
            if (contactInfoList == null || contactInfoList.Count == 0)
            {
                return null;
            }
            if (contactInfoList.Count > 50)
                contactInfoList = contactInfoList.Take(50).ToList();

            List<PassengerInfoModel> passengerList = new List<PassengerInfoModel>();

            List<int> contactIdList = new List<int>();
            contactInfoList.ForEach(n => contactIdList.Add(n.Contactid));
            List<ContactIdentificationInfoEntity> identificationList =
                _contactIdentificationDal.Query<ContactIdentificationInfoEntity>(
                    n => contactIdList.Contains(n.Contactid)).ToList();

            if (identificationList == null || identificationList.Count == 0)
            {
                identificationList = new List<ContactIdentificationInfoEntity>();
            }

            foreach (ContactInfoEntity contactInfo in contactInfoList)
            {
                PassengerInfoModel passengerInfo = new PassengerInfoModel();
                passengerInfo.ContactId = contactInfo.Contactid;
                passengerInfo.PassengerName = !string.IsNullOrEmpty(contactInfo.Cname)
                    ? contactInfo.Cname
                    : contactInfo.Ename;
                passengerInfo.Mobile = contactInfo.Mobile;
                passengerInfo.Phone = contactInfo.Phone;
                passengerInfo.Fax = contactInfo.Fax;
                passengerInfo.Email = contactInfo.Email;

                CustomerInfoEntity customerInfoEntity = null;
                if (customerList != null&& contactInfo.PCid.HasValue)
                {
                    customerInfoEntity = customerList.Find(n => n.Cid == contactInfo.PCid.Value);
                }
                else
                {
                    customerInfoEntity = customerList?.Find(n => n.Cid == contactInfo.Cid);
                }
              
                if (customerInfoEntity != null)
                {
                    CorpDepartmentEntity  corpDepartmentEntity= _corpDepartmentDal.Find<CorpDepartmentEntity>(customerInfoEntity.CorpDepartID ?? 0);
                    passengerInfo.DepartmentName = corpDepartmentEntity?.DepartName;
                    passengerInfo.Cid = customerInfoEntity.Cid;
                }
                
               
                var tempCardList =
                    identificationList.FindAll(n => n.Contactid == contactInfo.Contactid);
                #region 将默认证件放在首位
                int defaultCardType = contactInfo.DefaultIdentificationId ?? 0;
                var tempCard = tempCardList.Find(n => n.Iid == defaultCardType);
                if (tempCard != null)
                {
                    tempCardList.RemoveAll(n => n.Iid == defaultCardType);
                    tempCardList = tempCardList.OrderBy(n => n.Iid).ToList();
                    tempCardList.Add(tempCard);
                    tempCardList.Reverse();
                } 
                #endregion
                passengerInfo.IdentificationList = Mapper
                    .Map<List<ContactIdentificationInfoEntity>, List<IdentificationModel>>(tempCardList);

                passengerList.Add(passengerInfo);
            }

            return passengerList;
        }
        /// <summary>
        /// 查询联系人
        /// </summary>
        /// <param name="contactInfoEntitieses"></param>
        /// <returns></returns>
        private IQueryable<ContactInfoEntity> SearchContact(IQueryable<ContactInfoEntity> contactInfoEntitieses)
        {
            if (!string.IsNullOrEmpty(_searchArgs))
            {
                contactInfoEntitieses =
                    contactInfoEntitieses.Where(n => (!string.IsNullOrEmpty(n.Ename) && n.Ename.Contains(_searchArgs))
                                                     ||
                                                     (!string.IsNullOrEmpty(n.Cname) && n.Cname.Contains(_searchArgs))
                                                     || (!string.IsNullOrEmpty(n.Mobile) && n.Mobile == _searchArgs));
            }
            contactInfoEntitieses = contactInfoEntitieses.OrderByDescending(n => n.LastUpdateTime);
            return contactInfoEntitieses;
        } 
        #endregion
    }
}
