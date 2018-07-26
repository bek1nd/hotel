using Mzl.UIModel.Customer.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order
{
    public class TraOrderInfoViewModel
    {
        public TraOrderViewModel Order { get; set; }
        public List<TraOrderDetailViewModel> OrderDetailList { get; set; }
        public CustomerInfoViewModel CustomerInfo { get; set; }
    }
}
