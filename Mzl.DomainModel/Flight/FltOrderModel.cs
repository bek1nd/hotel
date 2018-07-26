using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class FltOrderModel
    {
        public int OrderId { get; set; }

        public int Cid { get; set; }

        public string Oid { get; set; }

        public decimal Refundfee { get; set; }

        public string Paytype { get; set; }

        public decimal Payamount { get; set; }

        public decimal Totalamount { get; set; }

        public decimal DepositAmount { get; set; }

        public decimal Voucheramount { get; set; }

        public decimal SendTicketAmount { get; set; }

        public decimal CreditcardfeeAmount { get; set; }

        public decimal OtherAmount { get; set; }

        public string Orderstatus { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Insurancefee { get; set; }

        public string Remark { get; set; }

        public int ProcessStatus { get; set; }

        public string SendOid { get; set; }

        public DateTime? SendTicketTime { get; set; }

        public DateTime? LastSendTicketTime { get; set; }

        public DateTime? PrintTicketTime { get; set; }

        public DateTime? LastPrintTicketTime { get; set; }
        public string PassengerType { get; set; }

        public int? Contactid { get; set; }

        public string ConfirmType { get; set; }

        public int? CreditId { get; set; }

        public string SendTicketRemark { get; set; }

        public string SendTicketType { get; set; }

        public DateTime? EstimateTicketTime { get; set; }

        public DateTime? EstimateCollectiontime { get; set; }

        public DateTime? RealAcceptDatetime { get; set; }

        public string PNRdetail { get; set; }

        public string CreateOid { get; set; }

        public int? BankId { get; set; }

        public string OrderType { get; set; }

        public int? FromOrder { get; set; }

        public string DeferType { get; set; }

        public int? Score { get; set; }

        public string Address { get; set; }

        public string IsInter { get; set; }

        public string Cname { get; set; }

        public string Ename { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string OutTicketStatus { get; set; }

        public string PrintTicketOid { get; set; }

        public string Allport { get; set; }

        public DateTime? ReturnAccountTime { get; set; }

        public string ReturnAccountOid { get; set; }

        public int? RouteId { get; set; }

        public DateTime? RealPayDatetime { get; set; }

        public DateTime? FakePayDatetime { get; set; }

        public string BuyRemark { get; set; }

        public decimal BackAmount { get; set; }

        public string IsOnline { get; set; }

        public DateTime? Collectiontime { get; set; }

        public string CollectionOid { get; set; }

        public string CheckStatus { get; set; }

        public int? CPId { get; set; }

        public DateTime? CPTime { get; set; }
        /// <summary>
        /// 航线类型,S单程,B往返程,M联程
        /// </summary>
        public string FltType { get; set; }

        public string Description { get; set; }

        public DateTime? PrintOrderTime { get; set; }

        public string PrintOrderOid { get; set; }

        public int? ChildOrderId { get; set; }

        public string ChoiceReason { get; set; }

        public string EstimateTicketDes { get; set; }

        public string CollectionForEndMonth { get; set; }

        public string PeerRecordNo { get; set; }

        public int? PeerRecordNoId { get; set; }

        public string IsOnLinePay { get; set; }

        public string CheckType { get; set; }

        public int TelTime { get; set; }

        public string CancelType { get; set; }

        public string IsModandChange { get; set; }

        public string OrderNumber { get; set; }

        public string OrderFrom { get; set; }

        public string OfficeCode { get; set; }

        public string OfficeMobile { get; set; }

        public string PolicyMemo { get; set; }

        public string IsTA { get; set; }

        public int? CPIdSecond { get; set; }

        public decimal? OtherSystemBudget { get; set; }

        public string IsFromRetAgain { get; set; }

        public int? CorpLinkId { get; set; }

        public int? ServiceFeeType { get; set; }

        public decimal ThirdPartyFee { get; set; }

        public decimal? FreezeAmount { get; set; }

        public string FreezeRemark { get; set; }

        public bool? IsDirect { get; set; }

        public string FCItem { get; set; }


        public string PassengerName { get; set; }

        public string TicketNo { get; set; }

        public string CustomerRemark { get; set; }

        public int ExpandStatus { get; set; }

        public int NotReturnMoney { get; set; }

        public string IsMobile { get; set; }

        public int? ProjectId { get; set; }

        public int? Insuaranceoid { get; set; }

        public DateTime? InsurancecreateTime { get; set; }

        public string InsuranceOid { get; set; }

        public DateTime? AffirmTime { get; set; }

        public string CARecordNo { get; set; }

        public string CorpId { get; set; }

        public int? CorpDepartId { get; set; }

        public string CorpPolicy { get; set; }

        public string Appraise { get; set; }

        public int? CPCid { get; set; }

        public decimal? LostAmount { get; set; }

        public string IsPolicyL { get; set; }

        public string IsPolicyT { get; set; }

        public string IsPolicyR { get; set; }

        public string TMNum { get; set; }

        public string ProjectCode { get; set; }

        public string IsAutoInsurance { get; set; }

        public string PolicyUpLoadOid { get; set; }

        public string PolicyUpLoadOName { get; set; }

        public string FreightRatesType { get; set; }

        public decimal? InnerRateAmount { get; set; }

        public decimal? InnerSaleRateAmount { get; set; }

        public decimal? InnerRate { get; set; }

        public decimal? InnerSaleRate { get; set; }

        public string IsFastPrintTicket { get; set; }

        public int? FivePrintId { get; set; }

        public int? FivePrintCount { get; set; }

        public DateTime? FivePrintLastTime { get; set; }

        public int? IsTeamOrder { get; set; }

        public int? BalanceType { get; set; }

        public int? TravelType { get; set; }

        public string IsNeedPrint { get; set; }

        public DateTime? IsNeedPrintTime { get; set; }

        public string WeiXinOrderId { get; set; }

        public decimal? UnCollectionAmount { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        public string CostCenter { get; set; }
        public string OrderSource { get; set; }
        /// <summary>
        /// 是否打印两连单
        /// </summary>

        public int? IsPrint { get; set; }
        /// <summary>
        /// 出差原由
        /// </summary>
        public string TravelReason { get; set; }

    }
}
