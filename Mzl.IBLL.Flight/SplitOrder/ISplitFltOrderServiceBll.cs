using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Flight.SplitOrder
{
    public interface ISplitFltOrderServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 按照乘机人拆分订单
        /// </summary>
        /// <returns></returns>
        List<int> SplitFltOrderByPassenger(int orderId, string oid);
    }
}
