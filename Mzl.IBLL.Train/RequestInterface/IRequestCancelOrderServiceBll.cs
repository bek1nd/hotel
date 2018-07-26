using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Server;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Train.RequestInterface
{
    public interface IRequestCancelOrderServiceBll : IBaseServiceBll
    {
        TraOrderCancelResponseModel RequestCancelOrder(int orderId);
    }
}
