using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Hotel.Order
{
    public class HotelOrderInfoModel : HotelOrderModel
    {
        public List<HotelOrderDetailModel> HotelOrderDetailList { get; set; }
    }
}
