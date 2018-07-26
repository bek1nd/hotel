using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mzl.EntityModel.Train.Order
{
    [Table("Tra_Order_Detail")]
    public class TraOrderDetailEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("主键")]
        [Column("Od_Id")]
        public int OdId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        [Description("订单编号")]
        [Column("Order_Id")]
        public int OrderId { get; set; }
        /// <summary>
        /// 始发站
        /// </summary>
        [Description("始发站")]
        [Column("Start_Addr")]
        public int StartNameId { get; set; }
        /// <summary>
        /// 到达站
        /// </summary>
        [Description("到达站")]
        [Column("End_Addr")]
        public int EndNameId { get; set; }
        /// <summary>
        /// 发车时间
        /// </summary>
        [Description("发车时间")]
        [Column("Send_Time")]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 车次
        /// </summary>
        [Description("车次")]
        [Column("Train_No")]
        public string TrainNo { get; set; }
        /// <summary>
        /// 席别
        /// </summary>
        [Description("席别")]
        [Column("Place_Type")]
        public string PlaceType { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        [Description("等级")]
        [Column("Place_grade")]
        public string PlaceGrade { get; set; }
        /// <summary>
        /// 订票张数
        /// </summary>
        [Description("订票张数")]
        [Column("Ticket_Num")]
        public int? TicketNum { get; set; }
        /// <summary>
        /// 退票费
        /// </summary>
        [Description("退票费")]
        [Column("Order_QMoney")]
        public decimal RefundFee { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        [Description("手续费")]
        [Column("Order_SMoney")]
        public decimal ServiceFee { get; set; }
        /// <summary>
        /// 票面价
        /// </summary>
        [Description("票面价")]
        [Column("Train_Money")]
        public decimal FacePrice { get; set; }
        /// <summary>
        /// 订单小计
        /// </summary>
        [Description("订单小计")]
        [Column("Order_Money")]
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        [Column("Order_Remark")]
        public string OrderRemark { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Description("状态")]
        [Column("Order_Status")]
        public string OrderStatus { get; set; }
        /// <summary>
        /// 12306订单号
        /// </summary>
        [Description("12306订单号")]
        [Column("OrderId")]
        public string OrderId12306 { get; set; }
        /// <summary>
        /// 车厢
        /// </summary>
        [Description("车厢")]
        [Column("Place_Car")]
        public string PlaceCar { get; set; }
        /// <summary>
        /// 席位号
        /// </summary>
        [Description("席位号")]
        [Column("Place_SeatNo")]
        public string PlaceSeatNo { get; set; }
        /// <summary>
        /// 出发城市名
        /// </summary>
        [Description("出发城市名")]
        [Column("StartCity")]
        public string StartCity { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        [Description("到达时间")]
        [Column("End_Time")]
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 到达城市名
        /// </summary>
        [Description("到达城市名")]
        [Column("EndCity")]
        public string EndCity { get; set; }
        /// <summary>
        /// 出发车站名
        /// </summary>
        [Description("出发车站名")]
        [Column("Start_AddrName")]
        public string StartName { get; set; }
        /// <summary>
        /// 到达车站名
        /// </summary>
        [Description("到达车站名")]
        [Column("End_AddrName")]
        public string EndName { get; set; }
        /// <summary>
        /// 火车类型
        /// </summary>
        [Description("火车类型")]
        [Column("TrainType")]
        public string TrainType { get; set; }
        /// <summary>
        /// 实收票价
        /// </summary>
        [Description("实收票价")]
        [Column("TrainSalePrice")]
        public decimal? TrainSalePrice { get; set; }
        /// <summary>
        /// 儿童实际销售票价
        /// </summary>
        [Description("儿童实际销售票价")]
        [Column("TrainChdSalePrice")]
        public decimal? TrainChdSalePrice { get; set; }
        /// <summary>
        /// 儿童退票费
        /// </summary>
        [Description("儿童退票费")]
        [Column("Order_CQMoney")]
        public decimal OrderCqMoney { get; set; }
        /// <summary>
        /// 供应商收手续费
        /// </summary>
        [Description("供应商收手续费")]
        [Column("Order_SXMoney")]
        public decimal OrderSxMoney { get; set; }
        /// <summary>
        /// 供应商收儿童手续费
        /// </summary>
        [Description("供应商收儿童手续费")]
        [Column("Order_CSXMoney")]
        public decimal OrderCsXMoney { get; set; }
        /// <summary>
        /// 供应商金额
        /// </summary>
        [Description("供应商金额")]
        [Column("SupplierMoney")]
        public decimal? SupplierMoney { get; set; }
        /// <summary>
        /// 出发站Code
        /// </summary>
        public string StartCode { get; set; }
        /// <summary>
        /// 到达站Code
        /// </summary>
        public string EndCode { get; set; }
        /// <summary>
        /// 违反差旅政策描述
        /// </summary>
        public string CorpPolicy { get; set; }
        /// <summary>
        /// 违反差旅政策原因
        /// </summary>
        public string ChoiceReason { get; set; }
    }
}
