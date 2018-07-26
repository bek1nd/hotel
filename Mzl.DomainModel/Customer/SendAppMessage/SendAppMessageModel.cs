using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.DomainModel.Customer.SendAppMessage
{
    public class SendAppMessageModel
    {
        public int SendId { get; set; }
        public int OrderId { get; set; }
        /// <summary>
        /// 0 出票通知  1申请核价待确认通知 2一级审核通知 3二级审核通知 4退客户通知
        /// </summary>
        public SendAppMessageTypeEnum SendType { get; set; }
        public OrderSourceTypeEnum OrderType { get; set; }
        public string SendContent { get; set; }
        public DateTime? SendFirstTime { get; set; }
        public DateTime? SendLastTime { get; set; }
        public string SendMonth => SendLastTime?.ToString("MM-dd") ?? "";
        /// <summary>
        /// 推送状态 0待发送，1发送成功，-1发送失败，-2发送异常
        /// </summary>
        public int SendStatus { get; set; }
        public int SendCount { get; set; }
        public DateTime CreateTime { get; set; }
        public string SendResult { get; set; }
        public string ClientId { get; set; }
        public int Cid { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// 是否准备出票
        /// </summary>
        public bool IsRunOutTicket { get; set; }
        /// <summary>
        /// 推送类型
        /// </summary>
        public SendAppMessageTypeEnum? SendAppMessageType { get; set; }

        public string EmailTitle { get; set; }

        public int IsRead { get; set; }
    }
}
