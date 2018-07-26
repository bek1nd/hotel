using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.ServiceFee.BLL
{
    public interface IServiceFeeConfigDetailsBLL<T> where T : class
    {
        List<T> GetServiceFeeConfigDetailsBySfcId(int sfcId);
    }
}
