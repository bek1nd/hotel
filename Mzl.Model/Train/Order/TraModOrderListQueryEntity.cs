using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Train.Order
{
    public class TraModOrderListQueryEntity : TraOrderListQueryEntity
    {
        /// <summary>
        /// 改签订单号
        /// </summary>
        public string Coid { get; set; }
    }
}
