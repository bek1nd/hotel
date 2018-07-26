using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Train.Order
{
    /// <summary>
    /// 获取火车订单列表信息
    /// </summary>
    public interface IGetTraOrderListServiceBll : IBaseServiceBll
    {
        TraOrderResultListModel GetTraOrderList(TraOrderListQueryModel query);
    }
}
