using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Hotel.CopyOrder
{
    public class CopyHotelOrderDetailViewModel
    {
        public DateTime Date { get; set; }
        /// <summary>
        /// 房间销售价(单价)
        /// </summary>
        public decimal DPayAmount { get; set; }
        /// <summary>
        /// 房间底价(单价)
        /// </summary>
        public decimal DLowAmount { get; set; }

        public decimal BedAmount { get; set; }
        public int BedCount { get; set; }
        public decimal BedTotaAmount => BedAmount * BedCount;


        public decimal BreakfastAmount { get; set; }
        public int BreakfastCount { get; set; }
        public decimal BreakfastTotaAmount => BreakfastAmount * BreakfastCount;


        public decimal AdslAmount { get; set; }
        public int AdslCount { get; set; }
        public decimal AdslTotaAmount => AdslAmount * AdslCount;
    }
}
