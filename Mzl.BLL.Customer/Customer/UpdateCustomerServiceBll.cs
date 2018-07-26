using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Contact;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.ContactInfo;
using Mzl.IDAL.Customer.Customer;

namespace Mzl.BLL.Customer.Customer
{
    internal class UpdateCustomerServiceBll : BaseServiceBll, IUpdateCustomerServiceBll
    {
        private readonly ICustomerDal _customerDal;
        private readonly IContactDal _contactDal;
        private readonly ICustomerUnionDal _customerUnionDal;

        public UpdateCustomerServiceBll(ICustomerDal customerDal, IContactDal contactDal, ICustomerUnionDal customerUnionDal)
        {
            _customerDal = customerDal;
            _contactDal = contactDal;
            _customerUnionDal = customerUnionDal;
        }


        public bool UpdateCustomerHeadPicture(int cid, string pictureUri)
        {
            CustomerInfoEntity customerInfoEntity = _customerDal.Find<CustomerInfoEntity>(cid);
            if(customerInfoEntity==null)
                throw new Exception("当前客户信息异常");
            if (string.IsNullOrEmpty(pictureUri))
                throw new Exception("上传路径不能为空");
            customerInfoEntity.HeadPictureUri = pictureUri;
            _customerDal.Update(customerInfoEntity, new string[] { "HeadPictureUri" });
            return true;
        }

        public bool UpdateCustomerInfo(UpdateCustomerInfoModel up)
        {
            CustomerInfoEntity customerInfoEntity = _customerDal.Find<CustomerInfoEntity>(up.Cid);
            if (customerInfoEntity == null)
                throw new Exception("当前客户信息异常");

            ContactInfoEntity contactInfoEntity = null;
            if (!string.IsNullOrEmpty(customerInfoEntity.CorpID))
            {
                 contactInfoEntity =
                    _contactDal.Query<ContactInfoEntity>(n => n.PCid == customerInfoEntity.Cid).FirstOrDefault();

                if (contactInfoEntity == null)
                    throw new Exception("当前客户信息异常，不能修改");
            }

            List<string> upArgsList = new List<string>();
            List<string> upArgsList2 = new List<string>();

            if (!string.IsNullOrEmpty(up.Email))
            {
                int emailCount =
                    _customerDal.Query<CustomerInfoEntity>(
                        n => n.Email == up.Email && n.Cid != up.Cid && n.CorpID == customerInfoEntity.CorpID, true)
                        .Count();

                if(emailCount>0)
                    throw new Exception("当前邮箱已经存在，不能修改");

                customerInfoEntity.Email = up.Email;
                upArgsList.Add("Email");

                if (contactInfoEntity != null)
                {
                    contactInfoEntity.Email = up.Email;
                    upArgsList2.Add("Email");
                }

            }

            if (!string.IsNullOrEmpty(up.Gender))
            {
                List<string> genderList = new List<string>() {"M","F"};
                if (!genderList.Contains(up.Gender))
                    throw new Exception("性别参数异常，请使用M/F");
                customerInfoEntity.Gender = up.Gender;
                upArgsList.Add("Gender");

                if (contactInfoEntity != null)
                {
                    contactInfoEntity.Gender = up.Gender;
                    upArgsList2.Add("Gender");
                }
            }

            if (!string.IsNullOrEmpty(up.RealName))
            {
                customerInfoEntity.RealName = up.RealName;
                upArgsList.Add("RealName");

                if (contactInfoEntity != null)
                {
                    if (up.RealName.Contains("/"))
                    {
                        contactInfoEntity.Ename = up.RealName;
                        upArgsList2.Add("Ename");
                    }
                    else
                    {
                        contactInfoEntity.Cname = up.RealName;
                        upArgsList2.Add("Cname");
                    }
                }
            }

            if (!string.IsNullOrEmpty(up.Mobile))
            {
                //这里要判断手机号，userid是否唯一
                int mobileCount =
                    _customerDal.Query<CustomerInfoEntity>(
                        n => n.Mobile == up.Mobile && n.Cid != up.Cid && n.CorpID == customerInfoEntity.CorpID, true)
                        .Count();
                if (mobileCount > 0)
                    throw new Exception("当前手机号存在，不能修改");

                int userIdCount =
                    _customerDal.Query<CustomerInfoEntity>(
                        n => n.UserID == up.Mobile && n.Cid != up.Cid && n.CorpID == customerInfoEntity.CorpID, true)
                        .Count();
                if(userIdCount>0)
                    throw new Exception("当前UserId存在，不能修改");
              
                customerInfoEntity.Mobile = up.Mobile;
                customerInfoEntity.UserID = up.Mobile;
                upArgsList.Add("Mobile");
                upArgsList.Add("UserID");
                upArgsList2.Add("Mobile");

                if (contactInfoEntity != null)
                {
                    contactInfoEntity.Mobile = up.Mobile;
                    upArgsList2.Add("Mobile");
                }
            }


            _customerDal.Update(customerInfoEntity, upArgsList.ToArray());

            if (contactInfoEntity != null)
            {
                _contactDal.Update(contactInfoEntity, upArgsList2.ToArray());
            }



            return true;
        }

        public bool UpdateCustomerCorpDepartIdList(int cid, List<int> corpDepartIdList,bool isAll)
        {
            CustomerUnionInfoEntity customerUnionInfoEntity =
                _customerUnionDal.Query<CustomerUnionInfoEntity>(n => n.Cid == cid).FirstOrDefault();

            string d = string.Empty;
            corpDepartIdList.ForEach(n =>
            {
                d += "," + n;
            });

            if (string.IsNullOrEmpty(d) && !isAll)
            {
                return true;
            }
            
            if(!string.IsNullOrEmpty(d))
                d = d.Substring(1);


            if (customerUnionInfoEntity != null)
            {
                customerUnionInfoEntity.CorpDepartIDList = d;
                if (isAll)
                {
                    customerUnionInfoEntity.CorpDepartIDList = "0";
                }
              
                _customerUnionDal.Update(customerUnionInfoEntity, new string[] { "CorpDepartIDList" });
                
            }
            else
            {
                customerUnionInfoEntity = new CustomerUnionInfoEntity()
                {
                    Cid = cid,
                    CorpDepartIDList = d
                };

                if (isAll)
                {
                    customerUnionInfoEntity.CorpDepartIDList = "0";
                }

                _customerUnionDal.Insert(customerUnionInfoEntity);
            }

            return true;

        }
    }
}
