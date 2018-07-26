using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Flight
{
    public class GetNotUseTicketNoQueryViewModel: RequestBaseViewModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int? OrderId { get; set; }
        public DateTime? TackOffBeginTime { get; set; }
        public DateTime? TackOffEndTime { get; set; }
        public string PassengerName { get; set; }
        public DateTime? OrderBeginTime { get; set; }
        public DateTime? OrderEndTime { get; set; }
        /// <summary>
        /// 当前显示多少条
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        public int PageIndex { get; set; }
    }
}
