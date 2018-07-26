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
    public class Inventory
    {
        private string hotelIDField;
        private string hotelCodeField;
        private bool statusField;
        private int overBookingField;
        private System.DateTime startDateField;
        private System.DateTime endDateField;
        private string startTimeField;
        private string endTimeField;
        private System.Nullable<bool> isInstantConfirmField;
        private string iC_BeginTimeField;
        private string iC_EndTimeField;
        private string roomTypeIdField;
        private System.DateTime dateField;
        private int amountField;

        /// <summary>
        /// 酒店ID
        /// </summary>
        public string HotelID
        {
            get
            {
                return this.hotelIDField;
            }
            set
            {
                this.hotelIDField = value;
            }
        }

        /// <summary>
        /// 酒店编码
        /// </summary>
        public string HotelCode
        {
            get
            {
                return this.hotelCodeField;
            }
            set
            {
                this.hotelCodeField = value;
            }
        }

        /// <summary>
        /// 库存状态
        /// </summary>
        public bool Status
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
        /// 房型ID
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
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
        /// 库存时间
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime Date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <summary>
        /// 库存数量
        /// </summary>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

        /// <summary>
        /// 超售状态
        /// </summary>
        public int OverBooking
        {
            get
            {
                return this.overBookingField;
            }
            set
            {
                this.overBookingField = value;
            }
        }

        /// <summary>
        /// 可用开始日期
        /// </summary>
        public System.DateTime StartDate
        {
            get
            {
                return this.startDateField;
            }
            set
            {
                this.startDateField = value;
            }
        }

        /// <summary>
        /// 可用结束日期
        /// </summary>
        public System.DateTime EndDate
        {
            get
            {
                return this.endDateField;
            }
            set
            {
                this.endDateField = value;
            }
        }

        /// <summary>
        /// 可用开始时间
        /// </summary>
        public string StartTime
        {
            get
            {
                return this.startTimeField;
            }
            set
            {
                this.startTimeField = value;
            }
        }

        /// <summary>
        /// 可用结束时间
        /// </summary>
        public string EndTime
        {
            get
            {
                return this.endTimeField;
            }
            set
            {
                this.endTimeField = value;
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
        /// 预订当天即时确认可用开始时间
        /// </summary>
        public string IC_BeginTime
        {
            get
            {
                return this.iC_BeginTimeField;
            }
            set
            {
                this.iC_BeginTimeField = value;
            }
        }

        /// <summary>
        /// 预订当天即时确认可用结束时间
        /// </summary>
        public string IC_EndTime
        {
            get
            {
                return this.iC_EndTimeField;
            }
            set
            {
                this.iC_EndTimeField = value;
            }
        }
    }
}
