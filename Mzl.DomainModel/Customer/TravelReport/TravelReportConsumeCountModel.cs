using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.TravelReport
{
    public class TravelReportConsumeCountModel
    {
        /// <summary>
        /// 销售价格
        /// </summary>
        [Description("销售价格")]
        public decimal SalePriceSum { get; set; }
        /// <summary>
        /// 节省价格
        /// </summary>
        [Description("节省价格")]
        public decimal SavePrice { get; set; }        
        /// <summary>
        /// 损失价格
        /// </summary>
        [Description("损失价格")]
        public decimal LostPrice { get; set; }
        /// <summary>
        /// 消费类型
        /// </summary>
        [Description("消费类型")]
        public string SaleType { get; set; }
        /// <summary>
        /// 查询年份
        /// </summary>
        [Description("查询年份")]
        public int TheYear { get; set; }
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

        /// <summary>
        /// 机票用，退票金额
        /// </summary>

        [Description("机票用，退票金额")]
        public decimal RefundMoney { get; set; }
    }
}
