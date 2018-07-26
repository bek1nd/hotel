using Mzl.Framework.Base;
using Mzl.UIModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Flight
{
    public interface ISearchAirportApplication : IBaseApplication
    {
        /// <summary>
        /// 查询机场
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        SearchCityAirportResponseViewModel SearchAirport(SearchCityAirportRequestViewModel request);
    }
}
