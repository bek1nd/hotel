using Mzl.DomainModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Common.BaseInfo
{
    /// <summary>
    ///获取带机场的城市信息
    /// </summary>
    public interface IGetCityForFlightServiceBll
    {
        /// <summary>
        /// 查询机场
        /// </summary>
        /// <param name="isInterList">N国内 I国际</param>
        /// <returns></returns>
        SearchCityAportModel SearchAirport(List<string> isInterList);
    }
}
