using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Hotel.CopyOrder
{
    public class CopyHotelOrderRequestViewModel : RequestBaseViewModel
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

        public List<CopyHotelOrderDetailViewModel> HotelOrderDetailList { get; set; }
    }
}
