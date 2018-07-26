using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    public class TraAddRetModOrderModel : TraAddOrderModel 
    {
        /// <summary>
        /// 原订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 提交客户Id
        /// </summary>
        public int Cid { get; set; }
        /// <summary>
        /// 原订单坐席
        /// </summary>
        public string OldPlaceGrade { get; set; }
        /// <summary>
        /// 是否需要请求第三方接口
        /// </summary>
        public bool IsRequestInterface { get; set; }
        /// <summary>
        /// 改签订单号
        /// </summary>
        public int? CorderId { get; set; }
        /// <summary>
        /// 是否强制使用人工退票
        /// </summary>
        public bool IsUserHandRefund { get; set; }
        /// <summary>
        /// 退票类型  0普通 1虚退
        /// </summary>
        public int RefundType { get; set; }
        /// <summary>
        /// 退票备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 改签备注
        /// </summary>
        public string  TravelRemark { get; set; }
    }
}
