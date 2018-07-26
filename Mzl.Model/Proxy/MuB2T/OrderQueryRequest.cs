using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 订单查询接口
    /// </summary>
    public class OrderQueryRequest
    {
        /// <summary>
        /// B2T用户名
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 机构名称
        /// </summary>
        public string AgentName { get; set; }
        /// <summary>
        /// B2T订单号
        /// </summary>
        public string OrderId { get; set; }
        /// <summary>
        /// 外部订单号
        /// </summary>
        public string ExtRefNo { get; set; }
    }
}
