using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Customer.Corporation.CorpAudit
{
    [Table("P_CorpAduitOrder_Detail")]
    public class CorpAduitOrderDetailEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("主键")]
        public int DetailId { get; set; }
        /// <summary>
        /// 审批单号
        /// </summary>
        [Description("审批单号")]
        public int AduitOrderId { get; set; }
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public int OrderId { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        [Description("订单类型")]
        public int OrderType { get; set; }
    }
}
