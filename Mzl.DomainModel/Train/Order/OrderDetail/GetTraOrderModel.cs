using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mzl.DomainModel.Train.Order.OrderDetail
{
    public class GetTraOrderModel
    {
        /// <summary>
        /// 订单Id
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 订单总额
        /// </summary>
        public decimal OrderAmount { get; set; }
        /// <summary>
        /// 行程总额
        /// </summary>
        public decimal TravelAmount { get; set; }
        /// <summary>
        /// 服务费总额
        /// </summary>
        public decimal ServiceAmount { get; set; }
        /// <summary>
        /// 行程信息集合
        /// </summary>
        [Description("行程信息集合")]
        public List<GetTraOrderTravelModel> TravelList { get; set; }
        /// <summary>
        /// 是否允许改签
        /// </summary>
        [Description("是否允许改签")]
        public bool IsAllowMod { get; set; }
        /// <summary>
        /// 是否允许退票
        /// </summary>
        [Description("是否允许退票")]
        public bool IsAllowRet { get; set; }
        /// <summary>
        /// 审批单Id
        /// </summary>
        [Description("审批单Id")]
        public int? AduitOrderId { get; set; }
        /// <summary>
        ///  审批单状态
        /// </summary>
        public int? AduitOrderStatus { get; set; }
        /// <summary>
        /// 审核状态描述
        /// </summary>
        public string AuditStatus { get; set; }
        /// <summary>
        /// 是否当前登录用户审批该订单
        /// </summary>
        [Description("是否当前登录用户审批该订单")]
        public bool IsCurrentCustomerAduitOrder { get; set; }

        public DateTime CreateTime { get; set; }

    }
}
