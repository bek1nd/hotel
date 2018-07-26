using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true, ElementName="CreditCard")]
    public class CreditCard
    {
        private string categoryIdField;

        private string categoryNameField;

        private string categoryNameEnField;

        /// <remarks/>
        public string CategoryId
        {
            get
            {
                return this.categoryIdField;
            }
            set
            {
                this.categoryIdField = value;
            }
        }

        /// <remarks/>
        public string CategoryName
        {
            get
            {
                return this.categoryNameField;
            }
            set
            {
                this.categoryNameField = value;
            }
        }

        /// <remarks/>
        public string CategoryNameEn
        {
            get
            {
                return this.categoryNameEnField;
            }
            set
            {
                this.categoryNameEnField = value;
            }
        }
    }
}
