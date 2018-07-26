using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.DBHelper;

namespace Mzl.UIModel.Customer.TravelReport
{
    
    public class TravelReportAirlineCountViewModel
    {
    
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
        public string AirlineNo { get; set; }
        //人数占比
        public decimal ManPercentage
        {
            get; set;
        }
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

       
    }
}
