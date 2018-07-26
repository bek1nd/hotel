using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Flight
{
    /// <summary>
    /// 机票订单表
    /// </summary>
    [Table("Flt_Order")]
    public partial class FltOrderEntity
    {
        [Key]
        public int OrderId { get; set; }

        public int Cid { get; set; }

        [Required]
        [StringLength(50)]
        public string Oid { get; set; }

        public decimal Refundfee { get; set; }

        [StringLength(3)]
        public string Paytype { get; set; }

        public decimal Payamount { get; set; }

        public decimal Totalamount { get; set; }

        public decimal DepositAmount { get; set; }

        public decimal Voucheramount { get; set; }

        public decimal SendTicketAmount { get; set; }

        public decimal CreditcardfeeAmount { get; set; }

        public decimal OtherAmount { get; set; }

        [Required]
        [StringLength(1)]
        public string Orderstatus { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Insurancefee { get; set; }

        [Required]
        [StringLength(1000)]
        public string Remark { get; set; }

        public int ProcessStatus { get; set; }

        [StringLength(50)]
        public string SendOid { get; set; }

        public DateTime? SendTicketTime { get; set; }

        public DateTime? LastSendTicketTime { get; set; }

        public DateTime? PrintTicketTime { get; set; }

        public DateTime? LastPrintTicketTime { get; set; }

        [Required]
        [StringLength(1)]
        public string PassengerType { get; set; }

        public int? Contactid { get; set; }

        [StringLength(3)]
        public string ConfirmType { get; set; }

        public int? CreditId { get; set; }

        [StringLength(500)]
        public string SendTicketRemark { get; set; }

        [StringLength(30)]
        public string SendTicketType { get; set; }

        public DateTime? EstimateTicketTime { get; set; }

        public DateTime? EstimateCollectiontime { get; set; }

        public DateTime? RealAcceptDatetime { get; set; }

        [StringLength(8000)]
        public string PNRdetail { get; set; }

        [Required]
        [StringLength(50)]
        public string CreateOid { get; set; }

        public int? BankId { get; set; }

        [Required]
        [StringLength(1)]
        public string OrderType { get; set; }

        public int? FromOrder { get; set; }

        [StringLength(3)]
        public string DeferType { get; set; }

        public int? Score { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        [StringLength(1)]
        public string IsInter { get; set; }

        [StringLength(50)]
        public string Cname { get; set; }

        [StringLength(50)]
        public string Ename { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Fax { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(1)]
        public string OutTicketStatus { get; set; }

        [StringLength(50)]
        public string PrintTicketOid { get; set; }

        [StringLength(200)]
        public string Allport { get; set; }

        public DateTime? ReturnAccountTime { get; set; }

        [StringLength(50)]
        public string ReturnAccountOid { get; set; }

        public int? RouteId { get; set; }

        public DateTime? RealPayDatetime { get; set; }

        public DateTime? FakePayDatetime { get; set; }

        [StringLength(6000)]
        public string BuyRemark { get; set; }

        public decimal? BackAmount { get; set; }

        [Required]
        [StringLength(1)]
        public string IsOnline { get; set; }

        public DateTime? Collectiontime { get; set; }

        [StringLength(50)]
        public string CollectionOid { get; set; }

        [StringLength(1)]
        public string CheckStatus { get; set; }

        public int? CPId { get; set; }

        public DateTime? CPTime { get; set; }

        /// <summary>
        /// 航线类型,S单程,B往返程,M联程
        /// </summary>
        [Required]
        [StringLength(1)]
        public string FltType { get; set; }

        /// <summary>
        /// 航程描述
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public DateTime? PrintOrderTime { get; set; }

        [StringLength(20)]
        public string PrintOrderOid { get; set; }

        public int? ChildOrderId { get; set; }

        [StringLength(200)]
        public string ChoiceReason { get; set; }

        [StringLength(200)]
        public string EstimateTicketDes { get; set; }

        [StringLength(1)]
        public string CollectionForEndMonth { get; set; }

        [StringLength(6)]
        public string PeerRecordNo { get; set; }

        public int? PeerRecordNoId { get; set; }

        [Required]
        [StringLength(1)]
        public string IsOnLinePay { get; set; }

        [StringLength(1)]
        public string CheckType { get; set; }

        public int TelTime { get; set; }

        [StringLength(1)]
        public string CancelType { get; set; }

        /// <summary>
        /// 是否改期换开(T,是,F,否)
        /// </summary>
        [Required]
        [StringLength(1)]
        public string IsModandChange { get; set; }

        [StringLength(50)]
        public string OrderNumber { get; set; }

        [StringLength(1)]
        public string OrderFrom { get; set; }

        [StringLength(20)]
        public string OfficeCode { get; set; }

        [StringLength(20)]
        public string OfficeMobile { get; set; }

        [StringLength(5000)]
        public string PolicyMemo { get; set; }

        /// <summary>
        /// 是否是三方协议票
        /// </summary>
        [Required]
        [StringLength(1)]
        public string IsTA { get; set; }

        public int? CPIdSecond { get; set; }

        public decimal? OtherSystemBudget { get; set; }

        [StringLength(1)]
        public string IsFromRetAgain { get; set; }

        public int? CorpLinkId { get; set; }

        public int? ServiceFeeType { get; set; }

        public decimal ThirdPartyFee { get; set; }

        public decimal? FreezeAmount { get; set; }

        [StringLength(1000)]
        public string FreezeRemark { get; set; }

        public bool? IsDirect { get; set; }

        [StringLength(200)]
        public string FCItem { get; set; }

        public string OrderSource { get; set; }
        public int? IsPrint { get; set; }
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        public int? CorpPolicyId { get; set; }
        /// <summary>
        /// 差旅审批规则Id
        /// </summary>
        public int? CorpAduitId { get; set; }
        /// <summary>
        /// 出差原由
        /// </summary>
        public string TravelReason { get; set; }
        /// <summary>
        /// 是否线上隐藏 0否 1是
        /// </summary>
        public int? IsOnlineShow { get; set; }
        /// <summary>
        /// 复制类型 C普通复制 X虚退复制
        /// </summary>
        public string CopyType { get; set; }
        /// <summary>
        /// 复制来源订单Id
        /// </summary>
        public int? CopyFromOrderId { get; set; }

        public int? IsAutoOutTicket { get; set; }
    }
}
