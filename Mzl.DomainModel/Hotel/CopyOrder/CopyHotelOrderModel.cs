using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Hotel.CopyOrder
{
    public class CopyHotelOrderModel
    {
        public string CreateOid { get; set; }
        /// <summary>
        /// 复制来源订单Id
        /// </summary>
        public int CopyFromOrderId { get; set; }
        /// <summary>
        /// 复制类型
        /// </summary>
        public string CopyType { get; set; } = "C";

        public List<CopyHotelOrderDetailModel> HotelOrderDetailList { get; set; }
    }
}
