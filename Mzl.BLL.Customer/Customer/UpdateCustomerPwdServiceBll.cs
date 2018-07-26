using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Customer;

namespace Mzl.BLL.Customer.Customer
{
    public class UpdateCustomerPwdServiceBll : BaseServiceBll, IUpdateCustomerPwdServiceBll
    {
        private readonly ICustomerDal _customerDal;

        public UpdateCustomerPwdServiceBll(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public bool UpdateCustomerPwd(UpdateCustomerPwdModel query)
        {
            CustomerInfoEntity customerInfoEntity = _customerDal.Find<CustomerInfoEntity>(query.Cid);
            if(string.IsNullOrEmpty(customerInfoEntity.Password))
                throw new Exception("密码异常");
            if (customerInfoEntity.Password.ToUpper() != query.OriginalPwd.ToUpper())
                throw new Exception("密码错误");
            customerInfoEntity.Password = query.AfterUpdatePwd;
            _customerDal.Update(customerInfoEntity, new string[] {"Password"});
            return true;
        }
    }
}
