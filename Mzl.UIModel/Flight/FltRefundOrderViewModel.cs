using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class FltRefundOrderViewModel
    {
        public int RefundId { get; set; }

        public int OrderId { get; set; }

        public decimal? RefundMoney { get; set; }
      
        public DateTime? RcDate { get; set; }

        public DateTime? RefundDate { get; set; }

        public string NumberIdentity { get; set; }

        public List<FltRefundDetailOrderViewModel> DetailList { get; set; }
    }
}
