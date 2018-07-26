using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mzl.DomainModel.Customer.TravelReport
{
   public class TravelReportPassengerTopModel
    {

        public int id { get; set; }
        /// <summary>
        /// 参与人数
        /// </summary>
        [Description("参与人数")]
        public int manNum { get; set; }
        /// <summary>
        /// 销售总价
        /// </summary>销售总价")]
        public decimal SalePrice { get; set; }
        /// <summary>
        /// 乘客姓名
        /// </summary>
        [Description("乘客姓名")]
        public string passengername { get; set; }
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
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime? Createdate { get; set; }
    }
}
