using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    public class TraModOrderModel
    {
        /// <summary>
        /// 改签单ID
        /// </summary>
        [Description("改签单ID")]
        public int CorderId { get; set; }
        /// <summary>
        /// 对应正单的第几个改签单
        /// </summary>
        [Description("对应正单的第几个改签单")]
        public int? Squence { get; set; }
        /// <summary>
        ///  联系人id
        /// </summary>
        [Description(" 联系人id")]
        public int? ContactId { get; set; }
        /// <summary>
        /// 原订单号
        /// </summary>
        [Description("原订单号")]
        public int? OrderId { get; set; }
        /// <summary>
        /// 'N','P','W','F'  ---改签单状态取消、处理中、待处理、完成
        /// </summary>
        [Description("'N','P','W','F'  ---改签单状态取消、处理中、待处理、完成")]
        public string OrderStatus { get; set; }
        public string OrderStatusDesc { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Description("创建人")]
        public string CreateOid { get; set; }
        /// <summary>
        /// 订单来源
        /// </summary>
        [Description("订单来源")]
        public string IsOnlineRefund { get; set; }
        /// <summary>
        /// 操作人
        /// </summary>
        [Description("操作人")]
        public string Oid { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        [Description("支付方式")]
        public string PayMethod { get; set; }
        /// <summary>
        /// 信用卡扣款--银行
        /// </summary>
        [Description("信用卡扣款--银行")]
        public string PayBank { get; set; }
        /// <summary>
        /// 信用卡扣款--卡号
        /// </summary>
        [Description("信用卡扣款--卡号")]
        public string PayBankCard { get; set; }
        /// <summary>
        /// 信用卡扣款--有效期
        /// </summary>
        [Description("信用卡扣款--有效期")]
        public DateTime? ValidityTime { get; set; }
        /// <summary>
        /// 信用卡扣款--三字码
        /// </summary>
        [Description("信用卡扣款--三字码")]
        public string ThreeMad { get; set; }
        /// <summary>
        /// 信用卡扣款--持卡人
        /// </summary>
        [Description("信用卡扣款--持卡人")]
        public string CardOwner { get; set; }
        /// <summary>
        /// 信用卡扣款--证件号码
        /// </summary>
        [Description("信用卡扣款--证件号码")]
        public string NameCard { get; set; }
        /// <summary>
        /// 信用卡扣款--电话
        /// </summary>
        [Description("信用卡扣款--电话")]
        public string CardPhone { get; set; }
        /// <summary>
        /// 银行汇款--银行名称
        /// </summary>
        [Description("银行汇款--银行名称")]
        public string BankName { get; set; }
        /// <summary>
        /// 公司付款--成本中心
        /// </summary>
        [Description("公司付款--成本中心")]
        public string CorpOrder { get; set; }
        /// <summary>
        /// 取票方式
        /// </summary>
        [Description("取票方式")]
        public string GetTickets { get; set; }
        /// <summary>
        /// 取票方式--送票地址
        /// </summary>
        [Description("取票方式--送票地址")]
        public string TicketAdress { get; set; }
        /// <summary>
        /// 取票方式--送(取)票时间(日期）
        /// </summary>
        [Description("取票方式--送(取)票时间(日期）")]
        public DateTime? TicketTime { get; set; }
        /// <summary>
        /// 取票方式--送(取)票时间(小时）
        /// </summary>
        [Description("取票方式--送(取)票时间(小时）")]
        public string TicketTimeHouer { get; set; }
        /// <summary>
        /// 取票方式--送(取)票时间(分钟）
        /// </summary>
        [Description("取票方式--送(取)票时间(分钟）")]
        public string TicketTimeMin { get; set; }
        /// <summary>
        /// 取票方式--最晚送(取)票时间(小时):
        /// </summary>
        [Description("取票方式--最晚送(取)票时间(小时):")]
        public string TicketDeadTimeH { get; set; }
        /// <summary>
        /// 取票方式--最晚送(取)票时间(分钟)
        /// </summary>
        [Description("取票方式--最晚送(取)票时间(分钟)")]
        public string TicketDeadTimeM { get; set; }
        /// <summary>
        ///  取票方式--送票说明
        /// </summary>
        [Description(" 取票方式--送票说明")]
        public string TicketRemark { get; set; }
        /// <summary>
        /// 常用联系人--姓名
        /// </summary>
        [Description("常用联系人--姓名")]
        public string CName { get; set; }
        /// <summary>
        /// 常用联系人--手机
        /// </summary>
        [Description("常用联系人--手机")]
        public string CPhone { get; set; }
        /// <summary>
        /// 常用联系人--电话
        /// </summary>
        [Description("常用联系人--电话")]
        public string CMobile { get; set; }
        /// <summary>
        /// 常用联系人--传真
        /// </summary>
        [Description("常用联系人--传真")]
        public string CFax { get; set; }
        /// <summary>
        /// 常用联系人--email
        /// </summary>
        [Description("常用联系人--email")]
        public string CEmail { get; set; }
        /// <summary>
        /// 状态位 A.改签,B.已打印取票单,C.已付票款 ,D.已付手续费 ,E.已收款,F.已付款,G.已打印出票单,H.已采购
        /// </summary>
        [Description("状态位 A.改签,B.已打印取票单,C.已付票款 ,D.已付手续费 ,E.已收款,F.已付款,G.已打印出票单,H.已采购")]
        public string ProcessStatus { get; set; }
        /// <summary>
        /// 该签单取消原因
        /// </summary>
        [Description("该签单取消原因")]
        public string Reason { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        public string Cid { get; set; }
        /// <summary>
        /// 改签单创建时间
        /// </summary>
        [Description("改签单创建时间")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 改签差价
        /// </summary>
        [Description("改签差价")]
        public decimal? CalcPrice { get; set; }
        /// <summary>
        /// 改签单显示单号，如20027216B
        /// </summary>
        [Description("改签单显示单号")]
        public string Coid { get; set; }
        /// <summary>
        /// 五联单打印序列号
        /// </summary>
        [Description("五联单打印序列号")]
        public int? FivePrintId { get; set; }
        /// <summary>
        /// 五联单打印次数
        /// </summary>
        [Description("五联单打印次数")]
        public int? FivePrintCount { get; set; }
        /// <summary>
        /// 五联单最后打印时间
        /// </summary>
        [Description("五联单最后打印时间")]
        public DateTime? FivePrintLastTime { get; set; }
        /// <summary>
        /// 结算方式 0：现结 1：月结
        /// </summary>
        [Description("结算方式 0：现结 1：月结")]
        public int? BalanceType { get; set; }
        /// <summary>
        /// 结算方式 0：因公 1：因私
        /// </summary>
        [Description("结算方式 0：因公 1：因私")]
        public int? TravelType { get; set; }
        /// <summary>
        /// 退票\改签编号如ABCDE
        /// </summary>
        [Description("退票改签编号如ABCDE")]
        public string NumberIdentity { get; set; }
        /// <summary>
        /// 改签面价
        /// </summary>
        public decimal? ModFacePrice { get; set; }
        /// <summary>
        /// 接口订单状态
        /// </summary>
        public int? InterFaceOrderStatus { get; set; }
        /// <summary>
        /// 订单总价
        /// </summary>
        public decimal? PayAmount { get; set; }

        public string OrderSource { get; set; }

        public int? IsPrint { get; set; }
        /// <summary>
        /// 改签备注
        /// </summary>
        public string TravelRemark { get; set; }
    }
}
