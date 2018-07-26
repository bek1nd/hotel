using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Train.Order;

namespace Mzl.IApplication.Train
{
    public interface IConfirmTraOrderViewApplication : IBaseApplication
    {
        /// <summary>
        /// 获取火车下单页面信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ConfirmTraOrderResponseViewModel GetTraComfireOrderView(ConfirmTraOrderRequestViewModel request);
    }
}
