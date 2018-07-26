using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Train.Server
{
    [Table("Tra_ModHoldSeatCallBackLog")]
    public class TraModHoldSeatCallBackLogEntity : TraCallBackLogBasicEntity
    {

        /// <summary>
        /// API 用户请求时传入的特征
        /// </summary>
        [Description("API 用户请求时传入的特征")]
        public string Reqtoken { get; set; }
        /// <summary>
        /// 使用方订单号
        /// </summary>
        [Description("使用方订单号")]
        public string Orderid { get; set; }
        /// <summary>
        /// 交易单号
        /// </summary>
        [Description("交易单号")]
        public string Transactionid { get; set; }
        /// <summary>
        /// 订票是否成功
        /// </summary>
        [Description("订票是否成功")]
        public bool? OrderSuccess { get; set; }
        /// <summary>
        /// 订单总金额
        /// </summary>
        [Description("订单总金额")]
        public string OrderAmount { get; set; }
        /// <summary>
        /// 车次
        /// </summary>
        [Description("车次")]
        public string CheCi { get; set; }
        /// <summary>
        /// 出发站简码
        /// </summary>
        [Description("出发站简码")]
        public string From_Station_Code { get; set; }
        /// <summary>
        /// 出发站名称
        /// </summary>
        [Description("出发站名称")]
        public string From_Station_Name { get; set; }
        /// <summary>
        /// 到达站简码
        /// </summary>
        [Description("到达站简码")]
        public string To_Station_Code { get; set; }
        /// <summary>
        /// 到达站名称
        /// </summary>
        [Description("到达站名称")]
        public string To_Station_Name { get; set; }
        /// <summary>
        /// 乘车日期
        /// </summary>
        [Description("乘车日期")]
        public string Tran_Date { get; set; }
        /// <summary>
        /// 从出发站开车时间
        /// </summary>
        [Description("从出发站开车时间")]
        public string Start_Time { get; set; }
        /// <summary>
        /// 抵达目的站的时间
        /// </summary>
        [Description("抵达目的站的时间")]
        public string Arrive_Time { get; set; }
        /// <summary>
        /// 取票单号（电子单号）
        /// </summary>
        [Description("取票单号（电子单号）")]
        public string OrderNumber { get; set; }
        /// <summary>
        /// 运行时间
        /// </summary>
        [Description("运行时间")]
        public string RunTime { get; set; }
        /// <summary>
        /// 与输入的一样，订票成功了里面的 cxin 和 ticketid 参数会有值
        /// </summary>
        [Description("与输入的一样，订票成功了里面的 cxin 和 ticketid 参数会有值")]
        public string Passengers { get; set; }
        /// <summary>
        /// 仅 refund_online=1，表示该订单无法在线退票或改签（12306 官网提示
        /// </summary>
        [Description("仅 refund_online=1，表示该订单无法在线退票或改签（12306 官网提示")]
        public string Refund_Online { get; set; }
    }
}
