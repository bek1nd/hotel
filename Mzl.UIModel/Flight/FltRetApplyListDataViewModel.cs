using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class FltRetApplyListDataViewModel
    {
        /// <summary>
        /// 申请Id
        /// </summary>
        public int Rmid { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 申请对应的原订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 退票申请状态
        /// </summary>
        public string OrderStatusDesc { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        public string AuditStatus { get; set; }
        public List<FltFlightListViewModel> FlightList { get; set; }
        public List<FltPassengerListViewModel> PassengerList { get; set; }
    }
}
