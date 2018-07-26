using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.TravelReport
{
    public class TravelReportReserveDayViewModel
    {
        /// <summary>
        /// 参与人数
        /// </summary>
        [Description("参与人数")]
        public int manNum { get; set; }
        /// <summary>
        /// 月份汇总价格
        /// </summary>")]
        [Description("月份汇总价格")]
        public decimal SalePriceSum { get; set; }
        /// <summary>
        /// 平均销售价格
        /// </summary>]
        [Description("平均销售价格")]
        public decimal SalePriceAvg { get; set; }
        /// <summary>
        /// 提前天数
        /// </summary>
        [Description("提前天数")]
        public string DiffDay { get; set; }
        //人数占比
        public decimal ManPercentage { get; set; }
        //销售额占比
        public decimal moneyPercentage { get; set; }
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
