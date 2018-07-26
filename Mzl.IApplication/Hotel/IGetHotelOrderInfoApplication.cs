using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Hotel.GetOrderInfo;

namespace Mzl.IApplication.Hotel
{
    public interface IGetHotelOrderInfoApplication : IBaseApplication
    {
        GetHotelOrderInfoResponseViewModel GetHotelOrderInfoByOrderId(GetHotelOrderInfoRequestViewModel request);
    }
}
