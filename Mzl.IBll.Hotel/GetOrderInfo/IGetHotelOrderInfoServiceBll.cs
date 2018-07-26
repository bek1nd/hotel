using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Hotel.Order;
using Mzl.Framework.Base;

namespace Mzl.IBll.Hotel.GetOrderInfo
{
    public interface IGetHotelOrderInfoServiceBll : IBaseServiceBll
    {
        HotelOrderInfoModel GetHotelOrderInfoByOrderId(int orderId);
    }
}
