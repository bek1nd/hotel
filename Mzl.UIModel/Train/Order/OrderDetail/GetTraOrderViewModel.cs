using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order.OrderDetail
{
    public class GetTraOrderViewModel
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
        public List<GetTraOrderTravelViewModel> TravelList { get; set; }
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
        [Description("审批单状态")]
        public int? AduitOrderStatus { get; set; }
        /// <summary>
        /// 审核状态描述
        /// </summary>
        [Description("审核状态描述")]
        public string AuditStatus { get; set; }
        /// <summary>
        /// 是否当前登录用户审批该订单
        /// </summary>
        [Description("是否当前登录用户审批该订单")]
        public bool IsCurrentCustomerAduitOrder { get; set; }
        /// <summary>
        /// 订单时间
        /// </summary>
        [Description("订单时间")]
        public DateTime CreateTime { get; set; }
    }
}
