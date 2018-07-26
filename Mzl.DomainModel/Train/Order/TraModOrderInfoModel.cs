using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    public class TraModOrderInfoModel
    {
        public TraModOrderModel Order { get; set; }
        public List<TraModOrderDetailModel> OrderDetailList { get; set; }
    }
}
