using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Customer.AppClient
{
    /// <summary>
    /// App推送信息
    /// </summary>
    [Table("P_SendAppMessage")]
    public class SendAppMessageEntity
    {
        [Key]
        public int SendId { get; set; }
        public int OrderId { get; set; }
        /// <summary>
        /// 0 出票通知  1申请核价待确认通知 2一级审核通知 3二级审核通知 4退客户通知
        /// </summary>
        public int SendType { get; set; }
        public string OrderType { get; set; }
        public string SendContent { get; set; }
        public DateTime? SendFirstTime { get; set; }
        public DateTime? SendLastTime { get; set; }
        /// <summary>
        /// 推送状态 0待发送，1发送成功，-1发送失败，-2发送异常，-3没有设备Id,-4不发送
        /// </summary>
        public int SendStatus { get; set; }
        public int SendCount { get; set; }
        public DateTime CreateTime { get; set; }
        public string SendResult { get; set; }
        public string ClientId { get; set; }
        public int Cid { get; set; }
        /// <summary>
        /// 是否在客户端读取推送消息 0或NULL否 1是
        /// </summary>
        public int? IsRead { get; set; }
    }
}
