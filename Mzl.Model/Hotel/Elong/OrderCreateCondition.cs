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
    public class OrderCreateCondition : OrderBaseCondition
    {
        private string affiliateConfirmationIdField;
        private string customerIPAddressField;
        private bool isGuaranteeOrChargedField;
        private string supplierCardNoField;
        private bool isNeedInvoiceField;
        private Contact contactField;
        private ExtendInfo extendInfoField;
        private BaseNightlyRate[] nightlyRatesField;
        private CreateOrderRoom[] orderRoomsField;
        private Invoice invoiceField;
        private CreditCard creditCardField;
        private System.Nullable<bool> isForceGuaranteeField;

        /// <summary>
        /// 合作伙伴订单确认号
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
        /// 客人访问IP
        /// </summary>
        public string CustomerIPAddress
        {
            get
            {
                return this.customerIPAddressField;
            }
            set
            {
                this.customerIPAddressField = value;
            }
        }
        /// <summary>
        /// 是否已担保或已付款
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
        /// 供应商卡号
        /// </summary>
        public string SupplierCardNo
        {
            get
            {
                return this.supplierCardNoField;
            }
            set
            {
                this.supplierCardNoField = value;
            }
        }
        /// <summary>
        /// 是否需要发票
        /// </summary>
        public bool IsNeedInvoice
        {
            get
            {
                return this.isNeedInvoiceField;
            }
            set
            {
                this.isNeedInvoiceField = value;
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
        /// 扩展字段
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
        /// 多天价格
        /// </summary>
        public BaseNightlyRate[] NightlyRates
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
        /// 客人信息
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
        /// 发票信息
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
        /// 
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
    }

    /// <summary>
    /// 订单房间
    /// </summary>
    public class CreateOrderRoom
    {
        private Customer[] customersField;

        /// <summary>
        /// 客人列表
        /// </summary>
        public Customer[] Customers
        {
            get
            {
                return this.customersField;
            }
            set
            {
                this.customersField = value;
            }
        }
    }

}
