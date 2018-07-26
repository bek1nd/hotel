using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 出票通知接口响应数据
    /// </summary>
    public class TicketIssueNotification
    {
        /// <summary>
        /// 返回结果代码
        /// </summary>
        public string MsgType { get; set; }
        /// <summary>
        /// 返回结果描述
        /// </summary>
        public string MsgDesc { get; set; }
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
        /// <summary>
        /// 票号信息
        /// </summary>
        public List<TicketInfo> TicketInfoModel { get; set; }
    }
}
