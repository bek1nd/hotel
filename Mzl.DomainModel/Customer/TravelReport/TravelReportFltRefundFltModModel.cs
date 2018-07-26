using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.TravelReport
{
    public class TravelReportFltRefundFltModModel
    {
        /// <summary>
        /// 产品中心
        /// </summary>
        public string CostCenter
        {
            get;
            set;
        }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal PriceSum
        {
            get;
            set;
        }
    }
}
