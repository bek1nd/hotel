using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.Order;

namespace Mzl.BLL.Train.Order
{
    internal class GetTraOrderServiceBll : BaseServiceBll, IGetTraOrderServiceBll
    {
        private readonly IGetTraOrderBll _getTraOrderBll;

        public GetTraOrderServiceBll(IGetTraOrderBll getTraOrderBll)
        {
            _getTraOrderBll = getTraOrderBll;
        }

        public TraOrderInfoModel GetTraOrderByOrderId(int orderId)
        {
            return _getTraOrderBll.GetTraOrderByOrderId(orderId);
        }
    }
}
