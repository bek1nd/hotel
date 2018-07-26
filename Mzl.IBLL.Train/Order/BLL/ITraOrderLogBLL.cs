using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.Order.BLL
{
    public interface ITraOrderLogBLL<T> where T : class
    {
        int AddLog(T t);
        List<T> GetLogByOrderId(int orderId);
    }
}
