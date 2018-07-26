using Mzl.Framework.Base;
using Mzl.UIModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Flight
{
    public interface IQueryFlightOrderListApplication : IBaseApplication
    {
        /// <summary>
        /// 查询机票订单列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        QueryFltOrderListResponseViewModel QueryFltOrderList(QueryFltOrderListRequestViewModel request);
    }
}
