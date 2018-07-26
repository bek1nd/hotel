using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.ServiceFee.BLL
{
    public interface IServiceFeeConfigBLL<T> where T : class
    {
        T GetServiceFeeConfigBySfcId(int sfcId);
    }
}
