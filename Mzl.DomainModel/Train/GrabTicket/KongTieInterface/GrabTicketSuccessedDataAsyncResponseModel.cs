using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.GrabTicket.KongTieInterface
{
    public class GrabTicketSuccessedDataAsyncResponseModel
    {
        /// <summary>
        /// API用户请求时传入的特征
        /// </summary>
        public string reqtoken { get; set; }

        /// <summary>
        /// 采购商订单号
        /// </summary>
        public string orderid { get; set; }

        /// <summary>
        /// 交易单号
        /// </summary>
        public string transactionid { get; set; }

        /// <summary>
        /// 订票是否成功
        /// </summary>
        public bool ordersuccess { get; set; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        public string orderamount { get; set; }

        /// <summary>
        /// 车次
        /// </summary>
        public string checi { get; set; }

        /// <summary>
        /// 出发站简码
        /// </summary>
        public string from_station_code { get; set; }

        /// <summary>
        /// 出发站名称
        /// </summary>
        public string from_station_name { get; set; }

        /// <summary>
        /// 到达站简码
        /// </summary>
        public string to_station_code { get; set; }

        /// <summary>
        /// 到达站名称
        /// </summary>
        public string to_station_name { get; set; }

        /// <summary>
        /// 乘车日期
        /// </summary>
        public string train_date { get; set; }

        /// <summary>
        /// 从出发站开车时间
        /// </summary>
        public string start_time { get; set; }

        /// <summary>
        /// 抵达目的站的时间
        /// </summary>
        public string arrive_time { get; set; }

        /// <summary>
        /// 取票单号（电子单号）
        /// </summary>
        public string ordernumber { get; set; }

        /// <summary>
        /// 运行时间
        /// </summary>
        public string runtime { get; set; }

        /// <summary>
        /// 仅refund_online=1，表示该订单无法在线退票（12306官网提示）
        /// </summary>
        public string refund_online { get; set; }

        /// <summary>
        /// 请求时间，格式：yyyyMMddHHmmssfff（非空）例：20140101093518059
        /// </summary>
        public string reqtime { get; set; }

        public string sign { get; set; }

        public int code { get; set; }
        public string msg { get; set; }

        /// <summary>
        /// 出票回调乘客信息
        /// </summary>
        public List<GrabTicketSuccessedPassengerAsyncResponseModel> passengers { get; set; }
    }
}
