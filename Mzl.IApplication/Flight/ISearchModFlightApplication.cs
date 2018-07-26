using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Flight;

namespace Mzl.IApplication.Flight
{
    public interface ISearchModFlightApplication: IBaseApplication
    {
        /// <summary>
        /// 查询改签航班
        /// </summary>
        SearchModFlightResponseViewModel Search(SearchModFlightRequestViewModel request);
    }
}
