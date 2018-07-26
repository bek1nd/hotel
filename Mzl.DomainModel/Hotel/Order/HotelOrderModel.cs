using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Hotel.Order
{
    public class HotelOrderModel
    {
        public int OrderId { get; set; }

        public int HolId { get; set; }

        public int RtId { get; set; }

        public int Cid { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int DayRange { get; set; }

        public int RoomNum { get; set; }

        public int CustomerNum { get; set; }

        public string CustomerName { get; set; }

        public string OrderType { get; set; }

        public string OrderStatus { get; set; }

        public int ProcessStatus { get; set; }

        public int Mid { get; set; }

        public string Oid { get; set; }

        public string Remark { get; set; }

        public string Explain { get; set; }

        public string PayType { get; set; }

        public decimal PayAmount { get; set; }

        public decimal VoucherAmount { get; set; }

        public decimal CreditCardfeeAmount { get; set; }

        public decimal DepositAmount { get; set; }

        public decimal SendTicketAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal OtherAmount { get; set; }

        public decimal LowAmount { get; set; }

        public decimal ProceedsAmount { get; set; }

        public DateTime CreateDate { get; set; }

        public string CreateOid { get; set; }

        public int CancelType { get; set; }

        public int BankId { get; set; }

        public int CreditId { get; set; }

        public string BalanceType { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public string ContactMobile { get; set; }

        public string ContactEmail { get; set; }

        public string SendType { get; set; }

        public string SendRemark { get; set; }

        public DateTime SendTime { get; set; }

        public DateTime LastSendTime { get; set; }

        public string SendOid { get; set; }

        public int SendScore { get; set; }

        public string SendAddress { get; set; }

        public string SendFax { get; set; }

        public string Depart { get; set; }

        public string BookingRemark { get; set; }

        public string ConfirmRemark { get; set; }

        public DateTime KeepTo { get; set; }

        public decimal PlanCommission { get; set; }

        public decimal ActualCommission { get; set; }

        public int NightAuditStatus { get; set; }

        public DateTime CommissionMonth { get; set; }

        public string OutOrderId { get; set; }

        public DateTime EstimateCollectiontime { get; set; }

        public int InvoiceType { get; set; }

        public string InvoiceTitle { get; set; }

        public string InvoiceContent { get; set; }

        public decimal InvoiceAmount { get; set; }

        public decimal ExtendAmount { get; set; }

        public decimal BackAmount { get; set; }

        public DateTime? Collectiontime { get; set; }

        public string CollectionOid { get; set; }

        public DateTime? RealPayDatetime { get; set; }

        public string RealPayOid { get; set; }

        public DateTime? Printordertime { get; set; }

        public string Printorderoid { get; set; }

        public string HolType { get; set; }

        public DateTime? FaccountsTime { get; set; }

        public string FaccountsOid { get; set; }

        public string IsOnLine { get; set; }

        public DateTime? KeepToTo { get; set; }

        public string ContactFax { get; set; }

        public string ComfirmType { get; set; }

        public string CollectionForEndMonth { get; set; }

        public DateTime? ConfirmTime { get; set; }

        public string ConfirmOid { get; set; }

        public DateTime? FristPrintTime { get; set; }

        public int PrintNumber { get; set; }

        public string IsOnLinePay { get; set; }

        public string GuaranteeRemark { get; set; }

        public int? ProjectId { get; set; }

        public string IsLuggage { get; set; }

        public string IsBuses { get; set; }

        public string BusesRemark { get; set; }

        public int? FivePrintId { get; set; }

        public DateTime? FivePrintLastTime { get; set; }

        public int? TravelType { get; set; }

        public int? BalanceMethod { get; set; }

        public string IsNeedPrint { get; set; }

        public DateTime? IsNeedPrintTime { get; set; }

        public string WeiXinOrderId { get; set; }

        public string IsJourneyOrder { get; set; }

        public decimal? UnCollectionAmount { get; set; }

        public decimal? CollectionAmount { get; set; }

        public string OrderFrom { get; set; }

        public string OrderNumber { get; set; }

        public int? IsSecretInquiry { get; set; }

        public string CustomerMobile { get; set; }

        public int? IsPrint { get; set; }

        public int? IsOnlineShow { get; set; }

        public string CopyType { get; set; }

        public int? CopyFromOrderId { get; set; }
    }
}
