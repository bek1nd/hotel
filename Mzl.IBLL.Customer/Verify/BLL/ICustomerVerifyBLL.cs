using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.Verify.BLL
{
    public interface ICustomerVerifyBLL< T> where T : class
    {
        T VerifyCustomer(CustomerLoginModel login);
    }
}
