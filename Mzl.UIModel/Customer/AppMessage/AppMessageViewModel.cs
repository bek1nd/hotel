using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.UIModel.Customer.AppMessage
{
    public class AppMessageViewModel
    {
        public int SendId { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        [Description("消息类型")]
        public int SendType { get; set; }

        /// <summary>
        /// 消息类型描述
        /// </summary>
        [Description("消息类型描述")]
        public string SendTypeDes => SendType.ValueToDescription<SendAppMessageTypeEnum>();
        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public int OrderId { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        [Description("消息内容")]
        public string SendContent { get; set; }
        /// <summary>
        /// 是否读取
        /// </summary>
        [Description("是否读取")]
        public int IsRead { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        public int Cid { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        [Description("订单类型")]
        public string OrderType { get; set; }
        /// <summary>
        /// 订单类型
        /// </summary>
        [Description("订单类型")]
        public int OrderTypeIndex => (int) OrderType.NameToEnum<OrderSourceTypeEnum>();

        /// <summary>
        /// 订单类型
        /// </summary>
        [Description("订单类型")]
        public string OrderTypeDes => OrderTypeIndex.ValueToDescription<OrderSourceTypeEnum>();
        /// <summary>
        /// 发送月份
        /// </summary>
        [Description("发送月份")]
        public string SendMonth { get; set; }
    }
}
