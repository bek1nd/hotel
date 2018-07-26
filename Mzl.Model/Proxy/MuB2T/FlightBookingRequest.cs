using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 中转航班预定接口，请求数据
    /// </summary>
    public class FlightBookingRequest
    {
        /// <summary>
        /// B2T登录名
        /// </summary>
        public string account { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string contactName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string contactPhone { get; set; }
        /// <summary>
        /// 联系邮箱
        /// </summary>
        public string contactEmail { get; set; }
        /// <summary>
        /// 航班信息
        /// </summary>
        public List<ODInfo> ODInfo { get; set; }
        /// <summary>
        /// 旅客信息
        /// </summary>
        public List<PassInfo> PassInfo { get; set; }
        /// <summary>
        /// 外部订单号
        /// </summary>
        public string extRefNo { get; set; }
        /// <summary>
        /// 航班类型
        /// </summary>
        public string flightTp { get; set; }
        /// <summary>
        /// 行程类型
        /// </summary>
        public string routeTp { get; set; }

    }
}
