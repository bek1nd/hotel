using Mzl.Common.EnumHelper.ElongEnum;
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
    public class OrderBaseRequest
    {
        private string hotelIdField;
        private string roomTypeIdField;
        private int ratePlanIdField;
        private System.DateTime arrivalDateField;
        private System.DateTime departureDateField;
        private EnumGuestTypeCode customerTypeField;
        private EnumPaymentType paymentTypeField;
        private int numberOfRoomsField;
        private int numberOfCustomersField;
        private System.DateTime earliestArrivalTimeField;
        private System.DateTime latestArrivalTimeField;
        private EnumCurrencyCode currencyCodeField;
        private decimal totalPriceField;
        private decimal customerPriceField;
        private EnumConfirmationType confirmationTypeField;
        private string noteToHotelField;
        private string noteToElongField;
        private string noteToGuestField;

        /// <summary>
        /// 酒店编号
        /// </summary>
        public string HotelId
        {
            get
            {
                return this.hotelIdField;
            }
            set
            {
                this.hotelIdField = value;
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
        /// 客人类型
        /// </summary>
        public EnumGuestTypeCode CustomerType
        {
            get
            {
                return this.customerTypeField;
            }
            set
            {
                this.customerTypeField = value;
            }
        }

        /// <summary>
        /// 付款类型
        /// </summary>
        public EnumPaymentType PaymentType
        {
            get
            {
                return this.paymentTypeField;
            }
            set
            {
                this.paymentTypeField = value;
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
        /// 货币类型
        /// </summary>
        public EnumCurrencyCode CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }

        /// <summary>
        /// 总价
        /// </summary>
        public decimal TotalPrice
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

        /// <remarks/>
        public decimal CustomerPrice
        {
            get
            {
                return this.customerPriceField;
            }
            set
            {
                this.customerPriceField = value;
            }
        }

        /// <summary>
        /// 确认类型
        /// </summary>
        public EnumConfirmationType ConfirmationType
        {
            get
            {
                return this.confirmationTypeField;
            }
            set
            {
                this.confirmationTypeField = value;
            }
        }

        /// <summary>
        /// 给酒店备注
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

        /// <summary>
        /// 给艺龙备注
        /// </summary>
        public string NoteToElong
        {
            get
            {
                return this.noteToElongField;
            }
            set
            {
                this.noteToElongField = value;
            }
        }

        /// <summary>
        /// 给客人的备注
        /// </summary>
        public string NoteToGuest
        {
            get
            {
                return this.noteToGuestField;
            }
            set
            {
                this.noteToGuestField = value;
            }
        }
    }
}
