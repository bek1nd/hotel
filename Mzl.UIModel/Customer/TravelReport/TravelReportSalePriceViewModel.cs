using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.TravelReport
{
    public class TravelReportSalePriceViewModel
    {
        private string _airname = "";
        /// <summary>
        /// 参与人数
        /// </summary>
        [Description("参与人数")]
        public int manNum { get; set; }
        /// <summary>
        /// 销售价格
        /// </summary>销售价格")]
        public decimal SalePriceSum { get; set; }
        /// <summary>
        /// 航线
        /// </summary>
        [Description("航线")]
        public string AirlineNo
        {

            get { return _airname; }
            set { _airname = AirName(value); }

        }
        ///折扣占比
        ///
        public decimal salePercentage { get; set; }
        //折扣显示
        public string SaleRate { get; set; }
        /// <summary>
        /// 查询月份
        /// </summary>
        [Description("查询月份")]
        public DateTime? TheMonth { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        [Description("公司编号")]
        public string corpid { get; set; }
        private string AirName(string AirNum)
        {
            string returnval = "";
            switch (AirNum)
            {
                case "781":
                    returnval = "东航/上航(MU/FM)";
                    break;
                case "784":
                    returnval = "南方航空(CZ)";
                    break;
                case "018":
                    returnval = "吉祥航空(HO)";
                    break;
                case "999":
                    returnval = "中国国际航空(CA)";
                    break;
                case "731":
                    returnval = "厦门航空(MF)";
                    break;
                case "876":
                    returnval = "四川航空(3U)";
                    break;
                case "836":
                    returnval = "河北航空(NS)";
                    break;
                case "479":
                    returnval = "深圳航空(ZH)";
                    break;
                default:
                    returnval = "其它";
                    break;
            }
            return returnval;
        }
    }
}
