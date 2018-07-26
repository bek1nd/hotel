using System;
using System.Collections.Generic;
using Mzl.Common.ConfigHelper;
using Mzl.Common.MD5Helper;

namespace Mzl.DomainModel.Train.GrabTicket.KongTieInterface
{
    /// <summary>
    /// 抢票请求实体
    /// </summary>
    public class GrabTicketRequestModel
    {
        /// <summary>
        /// 接口帐号
        /// </summary>
        public string partnerid => AppSettingsHelper.GetConfig("KongTieAccountConfig.xml", "GrabTicket", "UserName");
        /// <summary>
        /// 抢票下单
        /// </summary>
        public string method => "qiang_piao_order";

        public string reqtime => DateTime.Now.ToString("yyyyMMddHHmmss");

        /// <summary>
        /// 加密校验
        /// </summary>
        public string sign
        {
            get
            {
                string key = AppSettingsHelper.GetConfig("KongTieAccountConfig.xml", "GrabTicket", "Key");
                key=MD5Helper.MD5Encrypt(key);
                return MD5Helper.MD5Encrypt(string.Format("{0}{1}{2}{3}", partnerid, method, reqtime, key));
            }
        }

        /// <summary>
        /// 系统订单号
        /// </summary>
        public string qorderid { get; set; }

        /// <summary>
        /// 抢票通知地址
        /// </summary>
        public string callback_url
            => AppSettingsHelper.GetConfig("TrainConfig.xml", "TrainCallBack", "TraGrabTicketCallBack");

        /// <summary>
        /// 抢票类型 
        /// 100:刷到余票就占座
        /// 200:刷到余票通知我们，然后我们通知用户前往下单(暂不支持)
        /// </summary>
        public int qorder_type => 100;
        /// <summary>
        /// 抢票任务开始时间
        /// </summary>
        public string qorder_start_time { get; set; }
        /// <summary>
        /// 抢票任务结束时间
        /// </summary>
        public string qorder_end_time { get; set; }
        /// <summary>
        /// 是否接受线下抢票
        /// </summary>
        public bool agree_offline { get; set; }
        /// <summary>
        /// 邮寄地址,如果agree_offline为true必填
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 联系人，如果agree_offline为true必填
        /// </summary>
        public string Contacts { get; set; }
        /// <summary>
        /// 联系人电话，如果agree_offline为true必填
        /// </summary>
        public string ContactNumber { get; set; }
        /// <summary>
        /// 出发站三字码(选填)
        /// </summary>
        public string from_station_code { get; set; }
        /// <summary>
        /// 出发站
        /// </summary>
        public string from_station_name { get; set; }
        /// <summary>
        /// 到达站三字码(选填)
        /// </summary>
        public string to_station_code { get; set; }
        /// <summary>
        /// 到达站
        /// </summary>
        public string to_station_name { get; set; }
        /// <summary>
        /// 出发日期 格式：yyyyMMdd
        /// </summary>
        public string start_date { get; set; }
        /// <summary>
        /// 出发开始时间 00:00
        /// </summary>
        public string start_begin_time =>  "00:00";
        /// <summary>
        /// 出发截止时间 24:00
        /// </summary>
        public string start_end_time => "24:00";
        /// <summary>
        /// 抢票的具体车次，以“,”隔开  K110,T9
        /// </summary>
        public string train_codes { get; set; }
        /// <summary>
        /// 车次类型，与具体车次对应；Q表示其他类型，包括临客，数字列车等
        /// </summary>
        public string train_type { get; set; }
        /// <summary>
        /// 座位类型：商务座,特等座,一等座,二等座,高级软卧,软卧,硬卧,软座,硬座
        /// </summary>
        public string seat_type { get; set; }

        /// <summary>
        /// 最大票价（传0）
        /// </summary>
        public decimal max_price => 0;
        /// <summary>
        /// 是否要无座票，true  只接受有座  false  接受无座
        /// </summary>
        public bool hasseat { get; set; }
        /// <summary>
        /// 乘客详细信息
        /// </summary>
        public List<GrabTicketPassengerRequestModel> passengers { get; set; }

    }
}
