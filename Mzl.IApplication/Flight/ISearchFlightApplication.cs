using Mzl.Framework.Base;
using Mzl.UIModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Flight
{
    /// <summary>
    /// 查询航班应用
    /// </summary>
    public interface ISearchFlightApplication : IBaseApplication
    {
        /// <summary>
        /// 查询航班
        /// </summary>
        SearchFlightResponseViewModel Search(SearchFlightRequestViewModel request);
    }
}
