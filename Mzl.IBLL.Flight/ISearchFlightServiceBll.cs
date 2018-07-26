using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Flight
{
    /// <summary>
    /// 查询航班服务
    /// </summary>
    public interface ISearchFlightServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 查询航班
        /// </summary>
        List<SearchFlightModel> SearchFlight(SearchFlightQueryModel query);
    }
}
