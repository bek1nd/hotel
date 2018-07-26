using Mzl.Framework.Base;
using Mzl.UIModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Flight
{
    public interface IQueryFlightOrderApplication : IBaseApplication
    {
        /// <summary>
        /// 查询订单详情
        /// </summary>
        /// <returns></returns>
        QueryFltOrderResponseViewModel QueryOrder(QueryFltOrderRequestViewModel request);
    }
}
