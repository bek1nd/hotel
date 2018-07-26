using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.Elong
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public class OrderUpdateCondition
    {
        private long orderIdField;
        private string roomTypeIdField;
        private int ratePlanIdField;
        private System.DateTime arrivalDateField;
        private System.DateTime departureDateField;
        private int numberOfRoomsField;
        private int numberOfCustomersField;
        private System.Nullable<decimal> totalPriceField;
        private System.DateTime earliestArrivalTimeField;
        private System.DateTime latestArrivalTimeField;
        private Contact contactField;
        private bool isGuaranteeOrChargedField;
        private CreditCard creditCardField;
        private CreateOrderRoom[] orderRoomsField;
        private System.Nullable<bool> isForceGuaranteeField;
        private string noteToHotelField;
        private bool isDoubleCostOrderField;
        private decimal costPriceField;

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
        /// 房型编号
        /// </summary>
        public string RoomTypeId
        {
            get
            {
                return this.roomTypeIdField;
            }
            set
            {
                this.roomTypeIdField = value;
            }
        }

        /// <summary>
        /// 产品编号
        /// </summary>
        public int RatePlanId
        {
            get
            {
                return this.ratePlanIdField;
            }
            set
            {
                this.ratePlanIdField = value;
            }
        }

        /// <summary>
        /// 入住日期
        /// </summary>
        public System.DateTime ArrivalDate
        {
            get
            {
                return this.arrivalDateField;
            }
            set
            {
                this.arrivalDateField = value;
            }
        }

        /// <summary>
        /// 离店日期
        /// </summary>
        public System.DateTime DepartureDate
        {
            get
            {
                return this.departureDateField;
            }
            set
            {
                this.departureDateField = value;
            }
        }

        /// <summary>
        /// 房间数量
        /// </summary>
        public int NumberOfRooms
        {
            get
            {
                return this.numberOfRoomsField;
            }
            set
            {
                this.numberOfRoomsField = value;
            }
        }

        /// <summary>
        /// 客人数量
        /// </summary>
        public int NumberOfCustomers
        {
            get
            {
                return this.numberOfCustomersField;
            }
            set
            {
                this.numberOfCustomersField = value;
            }
        }

        /// <summary>
        /// 订单总价
        /// 当为null或0，表示不校验价格，以系统更新后价格为准；当传入大于0价格，则校验，和系统修改后价格不相等则拒绝本次订单修改
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> TotalPrice
        {
            get
            {
                return this.totalPriceField;
            }
            set
            {
                this.totalPriceField = value;
            }
        }

        /// <summary>
        /// 最早到店时间
        /// </summary>
        public System.DateTime EarliestArrivalTime
        {
            get
            {
                return this.earliestArrivalTimeField;
            }
            set
            {
                this.earliestArrivalTimeField = value;
            }
        }

        /// <summary>
        /// 最晚到店时间
        /// </summary>
        public System.DateTime LatestArrivalTime
        {
            get
            {
                return this.latestArrivalTimeField;
            }
            set
            {
                this.latestArrivalTimeField = value;
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
        /// 是否已担保或已付款
        /// 开通了公司担保业务的合作伙伴才能使用该属性
        /// </summary>
        public bool IsGuaranteeOrCharged
        {
            get
            {
                return this.isGuaranteeOrChargedField;
            }
            set
            {
                this.isGuaranteeOrChargedField = value;
            }
        }

        /// <summary>
        /// 信用卡
        /// </summary>
        public CreditCard CreditCard
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
        /// 订单房间
        /// </summary>
        public CreateOrderRoom[] OrderRooms
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
        /// 是否强制担保
        /// 强制担保对应的担保金额是首晚，并且不可变更取消。一般是产品无担保规则，酒店对某个特定订单要求临时增加担保的时候使用。使用eLong客服的订单请不要使用该属性。
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> IsForceGuarantee
        {
            get
            {
                return this.isForceGuaranteeField;
            }
            set
            {
                this.isForceGuaranteeField = value;
            }
        }

        /// <summary>
        /// 客人对酒店的特殊要求
        /// </summary>
        public string NoteToHotel
        {
            get
            {
                return this.noteToHotelField;
            }
            set
            {
                this.noteToHotelField = value;
            }
        }

        /// <remarks/>
        public bool IsDoubleCostOrder
        {
            get
            {
                return this.isDoubleCostOrderField;
            }
            set
            {
                this.isDoubleCostOrderField = value;
            }
        }

        /// <remarks/>
        public decimal CostPrice
        {
            get
            {
                return this.costPriceField;
            }
            set
            {
                this.costPriceField = value;
            }
        }
    }
}
