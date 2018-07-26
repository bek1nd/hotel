using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.TravelReport
{
    public class TravelReportCountDataModel
    {
        ///总条数
        ///
        public int CountNum
        {
            get;
            set;
        }
        /// <summary>
        /// 平均价格
        /// </summary>
        public decimal avgPrice
        {
            get;
            set;
        }
    }
}
