using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order.OrderDetail;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Train.Order
{
    public interface IGetTraOrderDetailServiceBll : IBaseServiceBll
    {
        GetTraOrderDetailInfoModel GetTraOrderDetailFromAppByOrderId(GetTraOrderDetailInfoQueryModel query);
    }
}
