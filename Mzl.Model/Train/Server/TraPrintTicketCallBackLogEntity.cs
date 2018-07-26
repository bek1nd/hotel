using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Train.Server
{
    [Table("Tra_PrintTicketCallBackLog")]
    public class TraPrintTicketCallBackLogEntity:TraCallBackLogBasicEntity
    {
        /// <summary>
        /// 请求时间
        /// </summary>
        [Description("请求时间，格式：yyyyMMddHHmmssfff（非空）例：20140101093518059")]
        public string Reqtime { get; set; }


        /// <summary>
        /// 数字签名
        /// </summary>
        [Description("数字签名=md5(partnerid+reqtime+md5(key)) md5 算法得到的字符串全部为小写")]
        public string Sign { get; set; }

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
        /// 是否出票成功
        /// </summary>
        [Description("是否出票成功的标识（Y：出票成功,N：出票失败）")]
        public string IsSuccess { get; set; }


    }
}
