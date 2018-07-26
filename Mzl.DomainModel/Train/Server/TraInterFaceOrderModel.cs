using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
    public class TraInterFaceOrderModel
    {

        /// <summary>
        /// 主键
        /// </summary>
        public int InterfaceId { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        [Description("订单号")]
        public string OrderId { get; set; }

        /// <summary>
        /// 订单对应车票
        /// </summary>
        [Description("订单对应车票")]
        public string Transactionid { get; set; }



        /// <summary>
        /// 订单创建时间
        /// </summary>
        [Description("订单创建时间")]
        public DateTime CreateTime { get; set; }



        /// <summary>
        /// 订单状态
        /// </summary>
        [Description("订单状态")]
        public int Status { get; set; }




        /// <summary>
        /// 取票单号
        /// </summary>
        [Description("取票单号")]
        public string OrderNumber { get; set; }

        /// <summary>
        /// 请求token信息
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// 接口返回原因
        /// </summary>
        public string Reason { get; set; }

    }
}
