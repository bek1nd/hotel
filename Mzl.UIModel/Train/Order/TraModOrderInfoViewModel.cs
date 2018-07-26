using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order
{
    public class TraModOrderInfoViewModel
    {
        public TraModOrderViewModel Order { get; set; }
        public List<TraModOrderDetailViewModel> OrderDetailList { get; set; }
    }
}
