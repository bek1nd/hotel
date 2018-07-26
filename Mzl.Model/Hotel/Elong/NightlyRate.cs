using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.Elong
{
    /// <summary>
    /// 每天价格数组
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public class NightlyRate
    {
        private decimal memberField;
        private decimal costField;
        private System.Nullable<decimal> basisField;
        private bool statusField;
        private decimal addBedField;
        private System.DateTime dateField;
        private System.Nullable<int> breakfastCountField;

        /// <summary>
        /// 会员价
        /// </summary>
        public decimal Member
        {
            get
            {
                return this.memberField;
            }
            set
            {
                this.memberField = value;
            }
        }

        /// <summary>
        /// 结算价
        /// </summary>
        public decimal Cost
        {
            get
            {
                return this.costField;
            }
            set
            {
                this.costField = value;
            }
        }

        /// <summary>
        /// 原始价格
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<decimal> Basis
        {
            get
            {
                return this.basisField;
            }
            set
            {
                this.basisField = value;
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
        /// 加床价
        /// </summary>
        public decimal AddBed
        {
            get
            {
                return this.addBedField;
            }
            set
            {
                this.addBedField = value;
            }
        }

        /// <summary>
        /// 当天日期
        /// </summary>
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
        /// 包含的早餐份数
        /// </summary>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable = true)]
        public System.Nullable<int> BreakfastCount
        {
            get
            {
                return this.breakfastCountField;
            }
            set
            {
                this.breakfastCountField = value;
            }
        }
    }
}
