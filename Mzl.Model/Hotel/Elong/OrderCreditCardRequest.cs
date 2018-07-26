using Mzl.Common.EnumHelper.ElongEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class OrderCreditCardRequest : CreditCardRequest
    {
        private HotelCreditCardProcessType processTypeField;
        private HotelCreditCardStatus statusField;
        private System.Nullable<decimal> amountField;
        private System.Nullable<System.DateTime> latestPayTimeField;
        private string notesField;

        private System.Nullable<bool> isPayableField;

        /// <remarks/>
        public HotelCreditCardProcessType ProcessType
        {
            get
            {
                return this.processTypeField;
            }
            set
            {
                this.processTypeField = value;
            }
        }

        /// <remarks/>
        public HotelCreditCardStatus Status
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

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> Amount
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

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<System.DateTime> LatestPayTime
        {
            get
            {
                return this.latestPayTimeField;
            }
            set
            {
                this.latestPayTimeField = value;
            }
        }

        /// <remarks/>
        public string Notes
        {
            get
            {
                return this.notesField;
            }
            set
            {
                this.notesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<bool> IsPayable
        {
            get
            {
                return this.isPayableField;
            }
            set
            {
                this.isPayableField = value;
            }
        }
    }
}
