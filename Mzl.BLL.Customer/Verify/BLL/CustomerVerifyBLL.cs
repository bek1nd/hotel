using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.Login;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.IBLL.Customer.Verify.BLL;
using Mzl.IDAL.Customer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Customer.Verify.BLL
{
    public class CustomerVerifyBLL : ICustomerVerifyBLL<CustomerInfoModel>
    {
        private readonly ICustomerInfoDAL _dal;

        public CustomerVerifyBLL(ICustomerInfoDAL dal)
        {
            _dal = dal;
        }

        public CustomerVerifyBLL()
        {

        }

        public CustomerInfoModel VerifyCustomer(CustomerLoginModel login)
        {
            CustomerInfoEntity customerInfoEntity = null;
            if (login.UserId.Contains("13816888447,"))
            {
                login.UserId = login.UserId.Split(',')[1].Trim();
                customerInfoEntity = _dal.GetCustomerByExpression(n =>
                    (n.UserID.ToUpper() == login.UserId.ToUpper()
                     || (!string.IsNullOrEmpty(n.Email) && n.Email.ToUpper() == login.UserId.ToUpper()) ||
                     (!string.IsNullOrEmpty(n.Mobile.ToUpper()) && n.Mobile.ToUpper() == login.UserId.ToUpper())) &&
                    n.IsDel == "F"
                    && n.CorpID.ToUpper() == login.CorpId.ToUpper()
                    && n.Password == n.Password);
            }
            else
            {
                customerInfoEntity = _dal.GetCustomerByExpression(n =>
                    (n.UserID.ToUpper() == login.UserId.ToUpper()
                     || (!string.IsNullOrEmpty(n.Email) && n.Email.ToUpper() == login.UserId.ToUpper()) ||
                     (!string.IsNullOrEmpty(n.Mobile.ToUpper()) && n.Mobile.ToUpper() == login.UserId.ToUpper())) &&
                    n.IsDel == "F"
                    && n.CorpID.ToUpper() == login.CorpId.ToUpper()
                    && n.Password.ToUpper() == login.Password.ToUpper());
            }
           
            if (customerInfoEntity == null)
                return null;
            return new CustomerInfoModel()
            {
                CorpId = customerInfoEntity.CorpID,
                UserId = customerInfoEntity.UserID,
                Cid = customerInfoEntity.Cid,
                IsLock = customerInfoEntity.IsLock
            };
        }
    }
}
