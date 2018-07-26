using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Hotel.Order
{
    public class HotelOrderDetailModel
    {
        public int DetailId { get; set; }

        public int OrderId { get; set; }

        public DateTime Date { get; set; }

        public string PriceType { get; set; }

        public decimal DPayAmount { get; set; }

        public decimal DLowAmount { get; set; }

        public decimal BedAmount { get; set; }

        public int BedCount { get; set; }

        public decimal BreakfastAmount { get; set; }

        public int BreakfastCount { get; set; }

        public decimal AdslAmount { get; set; }

        public int AdslCount { get; set; }

        public string Status { get; set; }

    }
}
