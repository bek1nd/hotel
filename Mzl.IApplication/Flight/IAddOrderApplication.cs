using Mzl.Framework.Base;
using Mzl.UIModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IApplication.Flight
{
    public interface IAddOrderApplication : IBaseApplication
    {
        /// <summary>
        /// 添加国内机票订单
        /// </summary>
        /// <param name="orderViewModel"></param>
        /// <returns></returns>
        AddOrderResponseViewModel AddDomesticOrderApplicationService(AddOrderRequestViewModel orderViewModel);

      
    }
}
