using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Train.Order
{
    public interface IAddTraOrderServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 添加火车订单
        /// </summary>
        /// <param name="traAddOrder"></param>
        /// <returns></returns>
        TraAddOrderResultModel AddTraOrder(TraAddOrderModel traAddOrder);
    }
}
