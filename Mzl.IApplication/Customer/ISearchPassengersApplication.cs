using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.IApplication.Customer
{
    /// <summary>
    /// 搜索订单待预定乘客信息
    /// </summary>
    public interface ISearchPassengersApplication : IBaseApplication
    {
        SearchPassengersResponseViewModel SearchPassengers(SearchPassengersRequestViewModel request);
    }
}
