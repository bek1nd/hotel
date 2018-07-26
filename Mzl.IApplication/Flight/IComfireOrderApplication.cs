using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Flight;
using Mzl.Framework.Base;

namespace Mzl.IApplication.Flight
{
    public interface IComfireOrderApplication : IBaseApplication
    {
        /// <summary>
        /// 机票订单创建视图
        /// </summary>
        /// <returns></returns>
        ComfireFlightOrderResponseViewModel ComfireOrderViewApplicationService(
            ComfireFlightOrderRequestViewModel request);
    }
}
