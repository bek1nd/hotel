using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.TravelReport
{
    public class TravelReportRequestDoModel
    {
        /// <summary>
        /// 查询年份
        /// </summary>
        [Description("查询年份")]
        public int TheYear { get; set; }
        /// <summary>
        /// 查询月份
        /// </summary>
        [Description("查询月份")]
        public DateTime StartMonth { get; set; }
        /// <summary>
        /// 查询结束月份
        /// </summary>
        [Description("查询结束月份")]
        public DateTime EndMonth { get; set; }
        /// <summary>
        /// 查询类型
        /// </summary>
        [Description("查询类型")]
        public int SourceType { get; set; }
        /// <summary>
        /// 公司编号
        /// </summary>
        [Description("公司编号")]
        public string Corpid { get; set; }
    }
}
