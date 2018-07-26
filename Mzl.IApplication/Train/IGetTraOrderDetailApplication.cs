using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Train.Order.OrderDetail;

namespace Mzl.IApplication.Train
{
    public interface IGetTraOrderDetailApplication : IBaseApplication
    {
        /// <summary>
        /// 获取订单详情信息（app）
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        GetTraOrderDetailResponseViewModel GetTraOrderDetailFromAppByOrderId(GetTraOrderDetailRequestViewModel request);
    }
}
