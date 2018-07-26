using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order;

namespace Mzl.IBLL.Train.Order
{
    public interface IGetTraOrderBll
    {
        /// <summary>
        /// 根据订单Id获取订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        TraOrderInfoModel GetTraOrderByOrderId(int orderId);
    }
}
