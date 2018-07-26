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
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true, ElementName = "CreditCard")]
    public class CreditCardRequest
    {
        private string numberField;
        private string cVVField;
        private int expirationYearField;
        private int expirationMonthField;
        private string holderNameField;
        private HotelIdType idTypeField;
        private string idNoField;

        /// <summary>
        /// 卡号
        /// </summary>
        public string Number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
        /// <summary>
        /// cvv
        /// </summary>
        public string CVV
        {
            get
            {
                return this.cVVField;
            }
            set
            {
                this.cVVField = value;
            }
        }
        /// <summary>
        /// 有效期-年
        /// </summary>
        public int ExpirationYear
        {
            get
            {
                return this.expirationYearField;
            }
            set
            {
                this.expirationYearField = value;
            }
        }
        /// <summary>
        /// 有效期-月
        /// </summary>
        public int ExpirationMonth
        {
            get
            {
                return this.expirationMonthField;
            }
            set
            {
                this.expirationMonthField = value;
            }
        }
        /// <summary>
        /// 持卡人
        /// </summary>
        public string HolderName
        {
            get
            {
                return this.holderNameField;
            }
            set
            {
                this.holderNameField = value;
            }
        }
        /// <summary>
        /// 证件类型
        /// </summary>
        public HotelIdType IdType
        {
            get
            {
                return this.idTypeField;
            }
            set
            {
                this.idTypeField = value;
            }
        }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string IdNo
        {
            get
            {
                return this.idNoField;
            }
            set
            {
                this.idNoField = value;
            }
        }
    }
}
