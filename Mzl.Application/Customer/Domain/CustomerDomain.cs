using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Customer.Login;
using Mzl.DomainModel.Customer.Passenger;
using Mzl.DomainModel.Events;
using Mzl.IApplication.Customer.Domain;
using Mzl.IBLL.Customer.ContactInfo.BLL;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Customer.Verify.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using Mzl.DomainModel.Customer.Corp;
using Mzl.IBLL.Customer.Customer.BLL;
using Mzl.DomainModel.Customer.Identification;
using Mzl.IBLL.Customer.CorpDepartment.BLL;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.IBLL.Customer.Corp.BLL;

namespace Mzl.Application.Customer.Domain
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly ICustomerVerifyBLL<CustomerInfoModel> _verifyBll;
        private readonly ICustomerBLL<CustomerInfoModel> _customerBll;
        private readonly IContactInfoBLL<ContactInfoModel> _contactBll;
        private readonly IContactIdentificationInfoBLL<IdentificationModel> _identificationInfoBll;
        private readonly ICorpDepartmentBLL<CorpDepartmentModel> _corpDepartmentBll;
        private readonly ICustomerUnionBLL<CustomerUnionInfoModel> _customerUnionBll;
        private readonly ICorporationBLL<CorporationModel> _corporationBll;
        private readonly IAddAppClientIdServiceBll _addAppClientIdServiceBll;


        public CustomerDomain(ICustomerBLL<CustomerInfoModel> customerBll)
        {
            _customerBll = customerBll;
        }

        public CustomerDomain(ICustomerVerifyBLL<CustomerInfoModel> verifyBll, IAddAppClientIdServiceBll addAppClientIdServiceBll, ICorporationBLL<CorporationModel> corporationBll)
        {
            _verifyBll = verifyBll;
            _addAppClientIdServiceBll = addAppClientIdServiceBll;
            _corporationBll = corporationBll;
        }
        public CustomerDomain(ICustomerBLL<CustomerInfoModel> customerBll, IContactInfoBLL<ContactInfoModel> contactBll,
            IContactIdentificationInfoBLL<IdentificationModel> identificationInfoBll, ICorporationBLL<CorporationModel> corporationBll)
        {
            _customerBll = customerBll;
            _contactBll = contactBll;
            _identificationInfoBll = identificationInfoBll;
            _corporationBll = corporationBll;
        }

        public CustomerDomain(ICustomerBLL<CustomerInfoModel> customerBll
            , ICorpDepartmentBLL<CorpDepartmentModel> corpDepartmentBll, ICustomerUnionBLL<CustomerUnionInfoModel> customerUnionBll
            , ICorporationBLL<CorporationModel> corporationBll)
        {
            _customerBll = customerBll;
            _corpDepartmentBll = corpDepartmentBll;
            _customerUnionBll = customerUnionBll;
            _corporationBll = corporationBll;
        }

        

        #region 事件
        public event EventHandler<TokenEventArgs> TokenEvent;
        #endregion

        #region 事件监听
        public void AddContactEventListener(object o, CommonEventArgs<List<ContactInfoModel>> e)
        {
            if (e.Obj.Count > 0 && e.Obj[0].Cid.HasValue && e.Obj[0].Cid.Value > 0)
            {
                foreach (var contact in e.Obj)
                {
                    AddContact(contact);
                }
            }
        }

        #endregion

        #region 公共方法
        /// <summary>
        /// 登录
        /// </summary>
        public CustomerInfoModel DoLogin(CustomerLoginModel loginModel)
        {
            if(string.IsNullOrEmpty(loginModel.CorpId))
                throw new Exception("公司代码不能为空");
            //判断是否是商旅客户
            CorporationModel corporationModel = _corporationBll.GetCorpInfoByCorpId(loginModel.CorpId);
            if (corporationModel == null || string.IsNullOrEmpty(corporationModel.IsAmplitudeCorp) ||
                corporationModel.IsAmplitudeCorp.ToUpper() == "F")
                throw new Exception("没有开通差旅功能，请联系客服开通");

            //1.根据用户名，密码，公司代码，验证身份
            CustomerInfoModel customerInfo = _verifyBll.VerifyCustomer(loginModel);
        

            if (customerInfo == null)
                return null;

            if (!string.IsNullOrEmpty(customerInfo.IsLock) && customerInfo.IsLock.ToUpper() == "T")
                throw new Exception("该客户已经被冻结，请先解冻再登录");
            if (!string.IsNullOrEmpty(customerInfo.IsDel) && customerInfo.IsDel.ToUpper() == "T")
                throw new Exception("该客户已经被删除，无法登录");

            //2.验证通过后，将token,UserId(key-value)保存到Redis中(事件方式)
            TokenEvent?.Invoke(this,
                new TokenEventArgs(loginModel.Token, customerInfo.UserId, customerInfo.Cid, loginModel.ClientType));

            //当前个性化如果设置需要短信验证则IsCheckClientId为true
            if ((corporationModel?.IsNoteVerify ?? 0) == 0)
            {
                loginModel.IsCheckClientId = false;
            }
            else
            {
                loginModel.IsCheckClientId = true;
            }


            if (!(loginModel.IsCheckClientId ?? false) && !string.IsNullOrEmpty(loginModel.ClientId))
            {
                //3.更新设备id
                _addAppClientIdServiceBll.AddAppClientId(new AddAppClientIdModel()
                {
                    Cid = customerInfo.Cid,
                    ClientId = loginModel.ClientId,
                    ClientType = loginModel.ClientType
                });
            }

            //3.获取设备id
            loginModel.ClientId = _addAppClientIdServiceBll.GetAppClientId(customerInfo.Cid);

          

            return customerInfo;
        }


        /// <summary>
        /// 自动登录
        /// </summary>
        /// <param name="cid">用户Cid</param>
        /// <param name="clientId">用户客户</param>
        /// <returns></returns>
        public bool AutoLogin(int cid, string clientId) {
            var c = _addAppClientIdServiceBll.GetAppClientId(cid);
            return c == clientId;
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <param name="token"></param>
        public void DoLoginOut(string token)
        {
            TokenEvent?.Invoke(this, new TokenEventArgs(token, "", 0,""));
        }

        /// <summary>
        /// 获取乘机人/乘车人信息
        /// </summary>
        /// <param name="cid">客户Id</param>
        /// <param name="departId"></param>
        /// <param name="searchArgs">查询参数</param>
        /// <returns></returns>
        public List<PassengerInfoModel> GetPassengerInfoList(int cid, int? departId,string searchArgs="")
        {
            CustomerInfoModel customer = GetCustomerInfo(cid);
            CorporationModel corporationModel = null;
            if (!string.IsNullOrEmpty(customer.CorpId))
            {
                corporationModel = _corporationBll.GetCorpInfoByCorpId(customer.CorpId);
                if (!customer.CorpDepartId.HasValue && corporationModel.IsAmplitudeCorp == "T")
                {
                    throw new Exception("该客户没有所属部门");
                }
            }

            List<PassengerInfoModel> passengerList = new List<PassengerInfoModel>();
            if (corporationModel != null && corporationModel.IsAmplitudeCorp == "T")
            {
                #region 差旅系统客户
                if (departId.HasValue && departId.Value == -1)
                    return passengerList;
                //1.根据Cid判断当前预定人是否有是预定人
                if (!string.IsNullOrEmpty(customer.IsMaster) && customer.IsMaster.ToUpper() == "T")
                {
                    if (!departId.HasValue)
                        throw new Exception("预定人请传入departId参数");

                    #region 是预定人
                    //1.1 根据departId获取对应的Cid
                    List<CustomerInfoModel> customerList = _customerBll.GetCustomerByDepartId(departId.Value, searchArgs);
                    List<int> cidList = new List<int>();
                    if (customerList == null)
                    {
                        customerList = new List<CustomerInfoModel>();
                    }
                    customerList.ForEach(n => cidList.Add(n.Cid));
                    //1.2 然后在通过Cid获取是乘机人信息的联系人信息
                    List<ContactInfoModel> contactList = _contactBll.GetPassengerContactInfoList(cidList) ??
                                                         new List<ContactInfoModel>();
                    passengerList = ConvertContactToPassenger(contactList);
                    #endregion
                }
                else
                {
                    #region 乘车人

                    ContactInfoModel contactInfo = _contactBll.GetPassengerContactInfo(cid);
                    List<IdentificationModel> identificationList =
                        _identificationInfoBll.GetIdentificationInfoByContactId(new List<int>() { contactInfo.ContactId });
                    passengerList.Add(new PassengerInfoModel()
                    {
                        ContactId = contactInfo.ContactId,
                        PassengerName = contactInfo.Name,
                        Mobile = contactInfo.Mobile,
                        IdentificationList = identificationList
                    });

                    #endregion
                }

                #endregion
            }
            else
            {
                #region 非差旅系统客户，从常用联系人中获取
                List<ContactInfoModel> contactList = _contactBll.GetPassengerContactInfoList(cid) ??
                                                             new List<ContactInfoModel>();
                if (!string.IsNullOrEmpty(searchArgs))
                {
                    contactList = contactList.FindAll(
                        n => (!string.IsNullOrEmpty(n.EName) && n.EName.Contains(searchArgs))
                        || (!string.IsNullOrEmpty(n.CName) && n.CName.Contains(searchArgs))
                        || (!string.IsNullOrEmpty(n.Mobile) && n.Mobile == searchArgs));
                }
                if (contactList.Count > 20)
                    contactList = contactList.Take(20).ToList();

                List<ContactInfoModel> contactList2 = new List<ContactInfoModel>();

                contactList.ForEach(n =>
                {
                    if (contactList2.Find(x => x.Name == n.Name) == null)//去除重名
                    {
                        contactList2.Add(n);
                    }
                });

                passengerList = ConvertContactToPassenger(contactList2); 
                #endregion
            }
            return passengerList;
        }
        /// <summary>
        /// 根据Cid获取客户信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public CustomerInfoModel GetCustomerInfo(int cid)
        {
            return _customerBll.GetCustomerByCid(cid);
        }
        /// <summary>
        /// 根据cid，获取查询行程视图
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public BaseQueryTravelModel GetQueryTravelView(int cid)
        {
            BaseQueryTravelModel queryTravelModel = new BaseQueryTravelModel();
            CustomerInfoModel customerInfoModel = _customerBll.GetCustomerByCid(cid);
            queryTravelModel.IsMaster = "F";//默认为该客户非预订员
            queryTravelModel.IsCorpSystemCustomer = "T";//默认是差旅系统客户
            CorporationModel corporationModel = null;
            if (!string.IsNullOrEmpty(customerInfoModel.CorpId))
            {
                corporationModel = _corporationBll.GetCorpInfoByCorpId(customerInfoModel.CorpId);
            }

            if (corporationModel != null && corporationModel.IsAmplitudeCorp == "T")
            {
                #region 如果是预订员，则获取当前预定的部门信息

                if (!string.IsNullOrEmpty(customerInfoModel.IsMaster) && customerInfoModel.IsMaster.ToUpper() == "T")
                {
                    queryTravelModel.IsMaster = "T";
                    queryTravelModel.DepartmentList = new List<CorpDepartmentModel>();
                    List<int> departIds = new List<int>();
                    CustomerUnionInfoModel customerUnionInfoModel =
                        _customerUnionBll.GetCustomerUnionByCid(customerInfoModel.Cid);
                    if (!string.IsNullOrEmpty(customerUnionInfoModel.CorpDepartIDList)) //0:全部 -1外宾部 
                    {
                        string[] departStrings = customerUnionInfoModel.CorpDepartIDList.Split(',');
                        departIds.AddRange(departStrings.Select(departString => Convert.ToInt32(departString)));
                    }
                    else
                    {
                        //如果是NULL，则默认0，-1
                        departIds.Add(0);
                        departIds.Add(-1);
                    }
                    if (departIds.Contains(0)) //全部部门
                    {
                        List<CorpDepartmentModel> departmentModels =
                            _corpDepartmentBll.GetCorpDepartmentByCorpId(customerInfoModel.CorpId);
                        departmentModels.ForEach(
                            n =>
                                queryTravelModel.DepartmentList.Add(new CorpDepartmentModel()
                                {
                                    Id = n.Id,
                                    DepartName = n.DepartName
                                }));
                    }
                    else
                    {
                        List<CorpDepartmentModel> departmentModels =
                            _corpDepartmentBll.GetCorpDepartmentByIds(departIds);
                        departmentModels.ForEach(
                            n =>
                                queryTravelModel.DepartmentList.Add(new CorpDepartmentModel()
                                {
                                    Id = n.Id,
                                    DepartName = n.DepartName
                                }));
                    }

                    if (queryTravelModel.DepartmentList.Count > 0)
                    {
                        //判断部门中是否存在员工，不存在则剔除
                        List<CustomerInfoModel> departCustomerInfoModels = _customerBll.GetCustomerByDepartId(departIds);
                        if (departCustomerInfoModels != null && departCustomerInfoModels.Count > 0)
                        {
                            for (int i = 0; i < queryTravelModel.DepartmentList.Count; i++)
                            {
                                if (
                                    departCustomerInfoModels.FindAll(
                                        n => n.CorpDepartId == queryTravelModel.DepartmentList[i].Id).Count == 0)
                                {
                                    queryTravelModel.DepartmentList.RemoveAt(i);
                                }
                            }
                        }


                    }

                    if (departIds.Contains(-1)) //外宾部门
                    {
                        queryTravelModel.DepartmentList.Add(new CorpDepartmentModel() { Id = -1, DepartName = "外宾部" });
                    }

                    if (departIds.Count==1&& departIds.Contains(0))//只有全部部门的时候，追加外宾，对前端网站维护进行容错处理
                    {
                        queryTravelModel.DepartmentList.Add(new CorpDepartmentModel() { Id = -1, DepartName = "外宾部" });
                    }

                }

                #endregion
            }
            else
            {
                queryTravelModel.IsMaster = "F";
                queryTravelModel.IsCorpSystemCustomer = "F";
            }
            return queryTravelModel;
        }
        /// <summary>
        /// 如果联系人id为0，新增联系人信息；如果不为0，则更新
        /// </summary>
        /// <param name="contactInfo"></param>
        /// <returns></returns>
        public int AddContact(ContactInfoModel contactInfo)
        {
            if (!contactInfo.Cid.HasValue)
                return 0;
            CustomerInfoModel cutCustomerInfoModel = _customerBll.GetCustomerByCid(contactInfo.Cid.Value);
            if (!string.IsNullOrEmpty(cutCustomerInfoModel.CorpId))
            {
                CorporationModel corporationModel = _corporationBll.GetCorpInfoByCorpId(cutCustomerInfoModel.CorpId);
                if (corporationModel.IsAmplitudeCorp == "T")//如果是差旅客户则跳出
                    return 0;
            }

            if (contactInfo.ContactId == 0)//新联系人信息
            {
                //判断是存在相同证件的常用乘客
                bool flag = false;
                List<ContactInfoModel> contactList = _contactBll.GetPassengerContactInfoList(contactInfo.Cid.Value);
                if (contactList != null && contactList.Count > 0)
                {
                    var contact=contactList.Find(n => n.Name == contactInfo.Name);
                    if (contact != null)//存在
                    {
                        List<IdentificationModel> identificationModels =
                            _identificationInfoBll.GetIdentificationInfoByContactId(new List<int>()
                            {
                                contactInfo.ContactId
                            })?.FindAll(n => n.CardNo == contactInfo.CardNo && n.Iid == (contactInfo.CardNoType ?? 0));

                        if (identificationModels != null && identificationModels.Count > 0)
                        {
                            contactInfo.ContactId = contact.ContactId;
                            flag = true;
                        }

                      
                    }
                }

              
                if (flag)
                {
                    //存在同人，更新
                    UpdateContact(contactInfo);
                    
                }
                else
                {
                    //不存在同人，则新增
                    int contactId = _contactBll.AddContact(contactInfo); //新增联系人信息
                    if (contactInfo.CardNoType.HasValue && !string.IsNullOrEmpty(contactInfo.CardNo))
                    {
                        //新增证件信息
                        _identificationInfoBll.AddIdentificationInfo(new IdentificationModel()
                        {
                            ContactId = contactId,
                            Iid = contactInfo.CardNoType.Value,
                            CardNo = contactInfo.CardNo
                        });
                    }
                }
            }
            else
            {
                UpdateContact(contactInfo);
            }

            return 0;
        } 
        #endregion

        #region 私有方法
        /// <summary>
        /// 更新联系人信息和证件信息
        /// </summary>
        /// <param name="contactInfo"></param>
        private void UpdateContact(ContactInfoModel contactInfo)
        {
            if (contactInfo.ContactId == 0)
                return ;
            //更新联系人信息
            _contactBll.UpdateContact(contactInfo);
            //根据联系人Id获取证件信息
            if (contactInfo.CardNoType.HasValue && !string.IsNullOrEmpty(contactInfo.CardNo))
            {
                List<IdentificationModel> identificationModels =
              _identificationInfoBll.GetIdentificationInfoByContactId(new List<int>() { contactInfo.ContactId });
                if (identificationModels == null)
                {
                    _identificationInfoBll.AddIdentificationInfo(new IdentificationModel()
                    {
                        ContactId = contactInfo.ContactId,
                        Iid = contactInfo.CardNoType.Value,
                        CardNo = contactInfo.CardNo
                    });
                }
                else
                {
                    IdentificationModel identificationModel =
                     identificationModels.Find(n => n.Iid == contactInfo.CardNoType.Value);//根据证件类型获取证件信息
                    if (identificationModel != null)
                    {
                        if (identificationModel.CardNo != contactInfo.CardNo)//有该证件类型，但是证件号不一致，则更新
                        {
                            identificationModel.CardNo = contactInfo.CardNo;
                            _identificationInfoBll.UpdateIdentificationInfo(identificationModel);
                        }
                    }
                    else//没有该证件，则新增
                    {
                        _identificationInfoBll.AddIdentificationInfo(new IdentificationModel()
                        {
                            ContactId = contactInfo.ContactId,
                            Iid = contactInfo.CardNoType.Value,
                            CardNo = contactInfo.CardNo
                        });
                    }
                }
               
            }

        }

        /// <summary>
        /// 将联系人信息转成乘车人信息
        /// </summary>
        /// <param name="contactList"></param>
        /// <returns></returns>
        private List<PassengerInfoModel> ConvertContactToPassenger(List<ContactInfoModel> contactList)
        {
            //1.3根据ContactId获取证件信息
            List<PassengerInfoModel> passengerList = new List<PassengerInfoModel>();
            List<int> contactIdList = new List<int>();
            contactList.ForEach(n => contactIdList.Add(n.ContactId));
            List<IdentificationModel> identificationList =
                _identificationInfoBll.GetIdentificationInfoByContactId(contactIdList);

            if (identificationList == null)
            {
                identificationList = new List<IdentificationModel>();
            }


            foreach (ContactInfoModel contactInfo in contactList)
            {
                PassengerInfoModel passengerInfo = new PassengerInfoModel();
                passengerInfo.ContactId = contactInfo.ContactId;
                passengerInfo.PassengerName = contactInfo.Name;
                passengerInfo.Mobile = contactInfo.Mobile;
                passengerInfo.Phone = contactInfo.Phone;
                passengerInfo.Fax = contactInfo.Fax;
                passengerInfo.Email = contactInfo.Email;
                passengerInfo.IdentificationList =
                    identificationList.FindAll(n => n.ContactId == contactInfo.ContactId);
                passengerList.Add(passengerInfo);
            }

            return passengerList;
        } 



        #endregion
    }
}
