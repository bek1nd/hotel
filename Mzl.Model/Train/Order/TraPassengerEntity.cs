using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mzl.EntityModel.Train.Order
{
    [Table("Tra_Passenger")]
    public class TraPassengerEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("主键")]
        public int Pid { get; set; }
        /// <summary>
        /// 乘车人名称
        /// </summary>
        [Description("乘车人名称")]
        [Column("P_Name")]
        public string Name { get; set; }
        /// <summary>
        /// 乘车人身份证
        /// </summary>
        [Description("乘车人身份证")]
        [Column("P_CodeNo")]
        public string CardNo { get; set; }
        /// <summary>
        /// 火车行程Id
        /// </summary>
        [Description("火车行程Id")]
        [Column("Od_Id")]
        public int OdId{ get; set; }
        /// <summary>
        /// 0未删，1已删，2退票
        /// </summary>
        [Description("0未删，1已删，2退票")]
        [Column("Is_Del")]
        public int IsDel { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Description("手机号")]
        [Column("Mobile")]
        public string Mobile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        [Column("OrderId")]
        public string OtherOrderId { get; set; }
        /// <summary>
        /// 证件类型，1身份证,2护照,4台湾通行证,5港澳通行证
        /// </summary>
        [Description("证件类型，1身份证,2护照,4台湾通行证,5港澳通行证")]
        [Column("P_CardType")]
        public int? CardNoType { get; set; }
        /// <summary>
        /// 保险数量
        /// </summary>
        [Description("保险数量")]
        [Column("InsuranceCount")]
        public int? InsuranceCount { get; set; }
        /// <summary>
        /// 保险金额
        /// </summary>
        [Description("保险金额")]
        [Column("Insurance")]
        public int? Insurance { get; set; }
        /// <summary>
        /// 保险底价
        /// </summary>
        [Description("保险底价")]
        [Column("InsuranceLowPrice")]
        public decimal? InsuranceLowPrice { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [Description("出生日期")]
        [Column("Birthday")]
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 乘客类型，成人P，儿童C
        /// </summary>
        [Description("乘客类型，成人P，儿童C")]
        [Column("P_Type")]
        public string AgeType { get; set; }
        /// <summary>
        /// 车厢
        /// </summary>
        [Description("车厢")]
        [Column("Place_Car")]
        public string PlaceCar { get; set; }
        /// <summary>
        /// 座位号
        /// </summary>
        [Description("座位号")]
        [Column("Place_SeatNo")]
        public string PlaceSeatNo { get; set; }
        /// <summary>
        /// 保险产品ID
        /// </summary>
        [Description("保险产品ID")]
        [Column("InsCompanyId")]
        public int? InsCompanyId { get; set; }
        /// <summary>
        /// 联系人ID
        /// </summary>
        [Description("联系人ID")]
        [Column("Contactid")]
        public int? ContactId { get; set; }
        /// <summary>
        /// 票号
        /// </summary>
        [Description("票号")]
        [Column("TicketNo")]
        public string TicketNo { get; set; }
        /// <summary>
        /// 改签后的票号
        /// </summary>
        [Description("改签后的票号")]
        [Column("ModTicketNo")]
        public string ModTicketNo { get; set; }
        /// <summary>
        /// 服务费
        /// </summary>
        [Column("ServiceFee")]
        public decimal? ServiceFee { get; set; }
        /// <summary>
        /// 票价
        /// </summary>
        [Column("FacePrice")]
        public decimal? FacePrice { get; set; }
        /// <summary>
        /// 坐席
        /// </summary>
        public string PlaceGrade { get; set; }
    }
}
