using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    public class TraModOrderListQueryModel: TraOrderListQueryModel
    {
        /// <summary>
        /// 改签订单号
        /// </summary>
        public string Coid { get; set; }
    }
}
