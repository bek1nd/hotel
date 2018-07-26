using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Server;

namespace Mzl.IBLL.Train.RequestInterface
{
    /// <summary>
    /// 取消订单请求
    /// </summary>
    public interface IRequestCancelOrderBll
    {
        TraOrderCancelResponseModel RequestCancelOrder(TraOrderCancelModel model);
    }
}
