using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Flight;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class CorpAduitOrderDetailModel
    {
        /// <summary>
        /// 主键
        /// </summary>
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
        /// <summary>
        /// 机票正单信息
        /// </summary>
        [Description("机票正单信息")]
        public FltOrderInfoModel FltOrder { get; set; }
        /// <summary>
        /// 订单类型描述
        /// </summary>
        [Description("订单类型描述")]
        public string OrderTypeDes => OrderType.ValueToDescription<OrderSourceTypeEnum>();
        /// <summary>
        /// 订单类型枚举
        /// </summary>
        [Description("订单类型枚举")]
        public OrderSourceTypeEnum OrderTypeEnum => OrderType.ValueToEnum<OrderSourceTypeEnum>();
    }
}
