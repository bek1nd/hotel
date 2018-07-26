using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Flight
{
    public interface IQueryFlightOrderListServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 查询机票订单列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        QueryFlightOrderListModel QueryFlightOrderList(QueryFlightOrderListDataQueryModel query);
    }
}
