using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    public class TraAddOrderResultModel
    {
        public int OrderId { get; set; }
        public TraAddOrderModel AddOrderModel { get; set; }
    }
}
