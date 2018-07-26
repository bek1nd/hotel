using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight.CopyOrder
{
    public class CopyFltOrderModel
    {
        public string CreateOid { get; set; }
        /// <summary>
        /// 复制来源订单Id
        /// </summary>
        public int CopyFromOrderId { get; set; }

        public decimal PayAmount { get; set; }

        public decimal CreditCardfeeamount { get; set; }
        public decimal Voucheramount { get; set; }
        public decimal SendTicketamount { get; set; }

        /// <summary>
        /// 复制类型
        /// </summary>
        public string CopyType { get; set; } = "C";
        /// <summary>
        /// 行程信息
        /// </summary>
        public List<CopyFltFlightModel> FlightList { get; set; }
    }
}
