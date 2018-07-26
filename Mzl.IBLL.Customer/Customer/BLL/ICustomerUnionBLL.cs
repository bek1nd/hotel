using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.Customer.BLL
{
    public interface ICustomerUnionBLL<T> where T : class
    {
        T GetCustomerUnionByCid(int cid);
    }
}
