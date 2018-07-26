using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mzl.EntityModel.Train.Order
{
    [Table("Tra_ModTravel")]
    public class TraModOrderDetailEntity
    {
        /// <summary>
        /// 改签行程ID
        /// </summary>
        [Key]
        [Description("改签行程ID")]
        public int TravelId { get; set; }
        /// <summary>
        /// 所属订单
        /// </summary>
        [Description("所属订单")]
        public string OrderId { get; set; }
        /// <summary>
        /// 乘客ID
        /// </summary>
        [Description("乘客ID")]
        public string Pid { get; set; }
        /// <summary>
        /// 车次
        /// </summary>
        [Description("车次")]
        public string TrainNo { get; set; }
        /// <summary>
        /// 出发站
        /// </summary>
        [Description("出发站")]
        public string AddrName { get; set; }
        /// <summary>
        /// 到达站
        /// </summary>
        [Description("到达站")]
        public string EndName { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        [Description("出发时间")]
        public DateTime? SendTime { get; set; }
        /// <summary>
        /// 抵达时间
        /// </summary>
        [Description("抵达时间")]
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 火车类型
        /// </summary>
        [Description("火车类型")]
        public string TrainType { get; set; }
        /// <summary>
        /// 卧铺/座位
        /// </summary>
        [Description("卧铺/座位")]
        public string PlaceType { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        [Description("等级")]
        public string PlaceGrade { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        [Description("数量")]
        public int? TicketNum { get; set; }
        /// <summary>
        /// 票面价
        /// </summary>
        [Description("票面价")]
        public decimal? TrainMoney { get; set; }
        /// <summary>
        /// 儿童价
        /// </summary>
        [Description("儿童价")]
        public decimal? TrainChdSalePrice { get; set; }
        /// <summary>
        /// 手续费
        /// </summary>
        [Description("手续费")]
        public decimal? OrderSMoney { get; set; }
        /// <summary>
        /// 保险总价
        /// </summary>
        [Description("保险总价")]
        public decimal? Insurance { get; set; }
        /// <summary>
        /// 小计
        /// </summary>
        [Description("小计")]
        public decimal? SumPrice { get; set; }
        /// <summary>
        /// 火车票改签Id
        /// </summary>
        [Description("火车票改签Id")]
        public int? CorderId { get; set; }
        /// <summary>
        /// 车厢
        /// </summary>
        [Description("车厢")]
        public string PlaceCar { get; set; }
        /// <summary>
        /// 座位号
        /// </summary>
        [Description("座位号")]
        public string PlaceSeatNo { get; set; }
        /// <summary>
        /// 出发站Code
        /// </summary>
        [Description("出发站Code")]
        public string StartCode { get; set; }
        /// <summary>
        /// 到达站Code
        /// </summary>
        [Description("到达站Code")]
        public string EndCode { get; set; }
        /// <summary>
        /// 改签票号
        /// </summary>
        [Description("改签票号")]
        public string TicketNo { get; set; }
        /// <summary>
        /// 改签手续费
        /// </summary>
        [Description("改签手续费")]
        public decimal? ModFee { get; set; }
    }
}
