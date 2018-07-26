using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.TravelReport
{
    public class TravelReportCountDataViewModel
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
