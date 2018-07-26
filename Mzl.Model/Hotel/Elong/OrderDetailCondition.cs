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
    public class OrderDetailCondition
    {
        private long orderIdField;
        private string affiliateConfirmationIdField;

        /// <summary>
        /// 供应商订单编号
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
    }
}
