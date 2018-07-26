using Mzl.Common.EnumHelper.ElongEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class OrderDetailResponse : OrderBaseRequest
    {
        private string elongCardNoField;
        private Contact contactField;
        private ExtendInfo extendInfoField;
        private NightlyRate[] nightlyRatesField;
        private OrderRoom[] orderRoomsField;
        private long orderIdField;
        private string statusField;
        private System.Nullable<long> showStatusField;
        private System.Nullable<System.DateTime> confirmPointField;
        private decimal penaltyToCustomerField;
        private EnumCurrencyCode penaltyCurrencyCodeField;
        private System.DateTime cancelTimeField;
        private bool hasInvoiceField;
        private System.Nullable<EnumInvoiceMode> invoiceModeField;
        private Invoice invoiceField;
        private OrderCreditCardRequest creditCardField;
        private GuaranteeRuleEntity guaranteeRuleField;
        private PrepayRuleEntity prepayRuleField;
        private string[] valueAddsField;
        private string hotelNameField;
        private string roomTypeNameField;
        private string ratePlanNameField;
        private System.Nullable<bool> isCancelableField;
        private System.Nullable<System.DateTime> creationDateField;
        private System.Nullable<decimal> couponField;
        private string affiliateConfirmationIdField;
        private System.Nullable<decimal> totalPriceExchangedField;
        private System.Nullable<decimal> totalCostPriceExchangedField;
        private System.Nullable<bool> isInstantConfirmField;
        private OrderHotelRequest orderHotelField;

        /// <summary>
        /// 分销(本地)订单编号-当OrderId=0的时候，则按AffiliateConfirmationId查询
        /// </summary>
        public string AffiliateConfirmationId
        {
            get
            {
                return this.affiliateConfirmationIdField;
            }
            set
            {
                this.affiliateConfirmationIdField = value;
            }
        }

        /// <summary>
        /// 订单编号
        /// </summary>
        public long OrderId
        {
            get
            {
                return this.orderIdField;
            }
            set
            {
                this.orderIdField = value;
            }
        }

        /// <summary>
        /// 艺龙会员卡号
        /// </summary>
        public string ElongCardNo
        {
            get
            {
                return this.elongCardNoField;
            }
            set
            {
                this.elongCardNoField = value;
            }
        }

        /// <summary>
        /// 联系人
        /// </summary>
        public Contact Contact
        {
            get
            {
                return this.contactField;
            }
            set
            {
                this.contactField = value;
            }
        }

        /// <summary>
        /// 扩展信息
        /// </summary>
        public ExtendInfo ExtendInfo
        {
            get
            {
                return this.extendInfoField;
            }
            set
            {
                this.extendInfoField = value;
            }
        }

        /// <summary>
        /// 每个价格
        /// </summary>
        public NightlyRate[] NightlyRates
        {
            get
            {
                return this.nightlyRatesField;
            }
            set
            {
                this.nightlyRatesField = value;
            }
        }

        /// <summary>
        /// 房间信息
        /// </summary>
        public OrderRoom[] OrderRooms
        {
            get
            {
                return this.orderRoomsField;
            }
            set
            {
                this.orderRoomsField = value;
            }
        }

        /// <summary>
        /// 订单状态
        /// </summary>
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        /// <summary>
        /// 对用户展示的订单状态
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<long> ShowStatus
        {
            get
            {
                return this.showStatusField;
            }
            set
            {
                this.showStatusField = value;
            }
        }

        /// <summary>
        /// 下一次确认反馈时间点
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> ConfirmPoint
        {
            get
            {
                return this.confirmPointField;
            }
            set
            {
                this.confirmPointField = value;
            }
        }

        /// <summary>
        /// 订单产生的罚金
        /// </summary>
        public decimal PenaltyToCustomer
        {
            get
            {
                return this.penaltyToCustomerField;
            }
            set
            {
                this.penaltyToCustomerField = value;
            }
        }

        /// <summary>
        /// 罚金货币类型
        /// </summary>
        public EnumCurrencyCode PenaltyCurrencyCode
        {
            get
            {
                return this.penaltyCurrencyCodeField;
            }
            set
            {
                this.penaltyCurrencyCodeField = value;
            }
        }

        /// <summary>
        /// 最晚取消时间
        /// </summary>
        public System.DateTime CancelTime
        {
            get
            {
                return this.cancelTimeField;
            }
            set
            {
                this.cancelTimeField = value;
            }
        }

        /// <summary>
        /// 是否有发票信息
        /// </summary>
        public bool HasInvoice
        {
            get
            {
                return this.hasInvoiceField;
            }
            set
            {
                this.hasInvoiceField = value;
            }
        }

        /// <summary>
        /// 预付订单的发票开具模式
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<EnumInvoiceMode> InvoiceMode
        {
            get
            {
                return this.invoiceModeField;
            }
            set
            {
                this.invoiceModeField = value;
            }
        }

        /// <summary>
        /// 发票
        /// </summary>
        public Invoice Invoice
        {
            get
            {
                return this.invoiceField;
            }
            set
            {
                this.invoiceField = value;
            }
        }

        /// <summary>
        /// 信用卡
        /// </summary>
        public OrderCreditCardRequest CreditCard
        {
            get
            {
                return this.creditCardField;
            }
            set
            {
                this.creditCardField = value;
            }
        }

        /// <summary>
        /// 担保规则
        /// </summary>
        public GuaranteeRuleEntity GuaranteeRule
        {
            get
            {
                return this.guaranteeRuleField;
            }
            set
            {
                this.guaranteeRuleField = value;
            }
        }

        /// <summary>
        /// 预付规则
        /// </summary>
        public PrepayRuleEntity PrepayRule
        {
            get
            {
                return this.prepayRuleField;
            }
            set
            {
                this.prepayRuleField = value;
            }
        }

        /// <summary>
        /// 增值服务
        /// </summary>
        public string[] ValueAdds
        {
            get
            {
                return this.valueAddsField;
            }
            set
            {
                this.valueAddsField = value;
            }
        }

        /// <summary>
        /// 酒店名称
        /// </summary>
        public string HotelName
        {
            get
            {
                return this.hotelNameField;
            }
            set
            {
                this.hotelNameField = value;
            }
        }

        /// <summary>
        /// 房型名称
        /// </summary>
        public string RoomTypeName
        {
            get
            {
                return this.roomTypeNameField;
            }
            set
            {
                this.roomTypeNameField = value;
            }
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string RatePlanName
        {
            get
            {
                return this.ratePlanNameField;
            }
            set
            {
                this.ratePlanNameField = value;
            }
        }

        /// <summary>
        /// 当前是否可以取消
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> IsCancelable
        {
            get
            {
                return this.isCancelableField;
            }
            set
            {
                this.isCancelableField = value;
            }
        }

        /// <summary>
        /// 预订时间
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> CreationDate
        {
            get
            {
                return this.creationDateField;
            }
            set
            {
                this.creationDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> Coupon
        {
            get
            {
                return this.couponField;
            }
            set
            {
                this.couponField = value;
            }
        }

        /// <summary>
        /// 换算为人民币的订单总卖价
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> TotalPriceExchanged
        {
            get
            {
                return this.totalPriceExchangedField;
            }
            set
            {
                this.totalPriceExchangedField = value;
            }
        }

        /// <summary>
        /// 换算为人民币的订单总底价
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> TotalCostPriceExchanged
        {
            get
            {
                return this.totalCostPriceExchangedField;
            }
            set
            {
                this.totalCostPriceExchangedField = value;
            }
        }

        /// <summary>
        /// 当天库存是否支持即时确认
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> IsInstantConfirm
        {
            get
            {
                return this.isInstantConfirmField;
            }
            set
            {
                this.isInstantConfirmField = value;
            }
        }

        /// <summary>
        /// 订单关联的酒店信息
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public OrderHotelRequest OrderHotel
        {
            get
            {
                return this.orderHotelField;
            }
            set
            {
                this.orderHotelField = value;
            }
        }
    }
}
