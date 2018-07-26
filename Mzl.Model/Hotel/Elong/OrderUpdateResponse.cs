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
    public class OrderUpdateResponse : OrderCreateResponse
    {
        private decimal totalPriceField;
        private EnumCurrencyCode guaranteeCurrencyCodeField;

        /// <summary>
        /// 订单总价
        /// 更新订单后总价可能改变
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

        /// <summary>
        /// 担保金额的货币
        /// </summary>
        public EnumCurrencyCode GuaranteeCurrencyCode
        {
            get
            {
                return this.guaranteeCurrencyCodeField;
            }
            set
            {
                this.guaranteeCurrencyCodeField = value;
            }
        }
    }
}
