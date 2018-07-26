using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order.CopyOrder
{
    public class CopyTraOrderModel
    {
        public string CreateOid { get; set; }

        /// <summary>
        /// 复制来源订单Id
        /// </summary>
        public int CopyFromOrderId { get; set; }

        /// <summary>
        /// 复制类型 X虚退 C普通
        /// </summary>
        public string CopyType { get; set; } = "C";

        public decimal PayAmount { get; set; }

        public List<CopyTraPassengerModel> PassengerList { get; set; }
    }
}
