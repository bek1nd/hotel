using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class FltRefundOrderModel
    {
        public int RefundId { get; set; }

        public int OrderId { get; set; }

        public decimal? RefundCash { get; set; }

        public decimal? RefundCard { get; set; }

        public decimal? RefundFee { get; set; }

        public decimal? RefundMoney { get; set; }

        public decimal? ExpressFee { get; set; }

        public decimal? Balance { get; set; }

        public decimal? Remittance { get; set; }

        public decimal? PosFee { get; set; }

        public decimal? UsedAmount { get; set; }

        public decimal? CorporationFee { get; set; }

        public decimal? SupplierFee { get; set; }

        public string ContactPerson { get; set; }

        public string ContactTel { get; set; }

        public string SendAddress { get; set; }

        public DateTime? SendBeginDate { get; set; }

        public DateTime? SendEndDate { get; set; }

        public string SendMode { get; set; }

        public string RefundCustomer { get; set; }

        public DateTime? RcDate { get; set; }

        public string RcOid { get; set; }

        public string RefundSupplier { get; set; }

        public DateTime? RsDate { get; set; }

        public string RsOid { get; set; }

        public string RefundOid { get; set; }

        public DateTime? RefundDate { get; set; }

        public string Remark { get; set; }

        public string CustomerStatus { get; set; }

        public string SupplierStatus { get; set; }

        public string SingleTripStatus { get; set; }

        public string RefundReason { get; set; }

        public string HandleOid { get; set; }

        public int? Aid { get; set; }

        public string AccountStatus { get; set; } 

        public string AccountOid { get; set; }

        public DateTime? AccountDate { get; set; }

        public DateTime? PrintTicketsTime { get; set; }

        public string IsCompleted { get; set; }

        public string NumberIdentity { get; set; }

        public decimal? Refundfeetemp { get; set; }

        public decimal? Voucheramount { get; set; }

        public string RefundStatus { get; set; }

        public string IsLock { get; set; }

        public string Refundprofit { get; set; }

        public int? ReAid { get; set; }

        public int? PaAid { get; set; }

        public int PrintNumber { get; set; }

        public DateTime? FristPrintTime { get; set; }

        public int? PressoceStatus { get; set; }

        public string IsAudit { get; set; }

        public string AuditRemark { get; set; }

        public decimal SecondRefundMoney { get; set; }

        public int? SecondPaAid { get; set; }

        public string SecondOid { get; set; }

        public DateTime? SecondTime { get; set; }

        public string SecondRemark { get; set; }

        public string SecondPrintTime { get; set; }

        public string SecondPrintStatus { get; set; } 

        public int? Rmid { get; set; }

        public int? SecondReAid { get; set; }

        public string SecondRefundCustomer { get; set; }

        public DateTime? SecondRcDate { get; set; }

        public string SecondRcOid { get; set; }

        public int? FivePrintId { get; set; }

        public DateTime? FivePrintLastTime { get; set; }

        public string RefundTypeRemark { get; set; }

        public string IsKeepAccount { get; set; }

        public DateTime? KeepAccountDate { get; set; }

        public string KeepAccountOid { get; set; }
        /// <summary>
        /// 退票明细
        /// </summary>
        public List<FltRefundDetailOrderModel> DetailList { get; set; }
    }
}
