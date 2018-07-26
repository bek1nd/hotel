using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class FltModOrderModel
    {
        public int Rmid { get; set; }

        public int ProcessStatus { get; set; }

        public decimal? ModPrice { get; set; }

        public decimal? ModLowPrice { get; set; }

        public string ProcessOid { get; set; }

        public string ContactPhone { get; set; }

        public string ContactEmail { get; set; }

        public string ContactFax { get; set; }

        public string SendType { get; set; }

        public string SendRemark { get; set; }

        public DateTime? SendTime { get; set; }

        public DateTime? LastSendTime { get; set; }

        public string SendAddress { get; set; }

        public int Version { get; set; }

        public int OrderId { get; set; }

        public int Cid { get; set; }

        public DateTime CreateTime { get; set; }

        public string ContactName { get; set; }

        public string ContactTel { get; set; }

        public string OrderStatus { get; set; }

        public string Remark { get; set; }

        public string CorpId { get; set; }

        public string EditOid { get; set; }

        public DateTime? EditTime { get; set; }

        public string CreateOid { get; set; }

        public string IsOnlineRefund { get; set; }

        public int? Aid { get; set; }

        public string Oid { get; set; }

        public int? RootRmid { get; set; }

        public string IsInter { get; set; }

        public string IsOnLine { get; set; }

        public string IsOnLinePay { get; set; }

        public string Paytype { get; set; }

        public DateTime? RealAcceptDatetime { get; set; }

        public string RealAcceptOid { get; set; }

        public DateTime? RealPayDatetime { get; set; }

        public string RealPayOid { get; set; }

        public DateTime? ReturnAccountTime { get; set; }

        public string ReturnAccountOid { get; set; }

        public int? BankId { get; set; }

        public int? Contactid { get; set; }

        public string Depart { get; set; }

        public DateTime? PrintTicketTime { get; set; }

        public DateTime? LastPrintTicketTime { get; set; }

        public string NumberIdentity { get; set; }

        public DateTime? OutTicketTime { get; set; }

        public int? FivePrintId { get; set; }

        public int? FivePrintCount { get; set; }

        public DateTime? FivePrintLastTime { get; set; }

        public int? BalanceType { get; set; }

        public int? TravelType { get; set; }

        public string IsNeedPrint { get; set; }

        public DateTime? IsNeedPrintTime { get; set; }

        public string WeiXinOrderId { get; set; }
        /// <summary>
        /// 改签乘机人
        /// </summary>
        public List<FltModPassengerModel> FltModPassengerList { get; set; }
        /// <summary>
        /// 改签行程信息
        /// </summary>
        public List<FltModFlightModel> FltModFlightList { get; set; }
        /// <summary>
        /// 改签订单日志
        /// </summary>
        public List<FltModOrderLogModel> FltModOrderLogList { get; set; }
        /// <summary>
        /// 改签票号
        /// </summary>
        public List<FltModTicketNoModel> FltModTicketNoList { get; set; }
    }
}
