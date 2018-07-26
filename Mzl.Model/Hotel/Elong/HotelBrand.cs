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
    public class HotelBrand
    {
        private int brandIdField;

        private int groupIdField;

        private string shortNameField;

        //private string shortNameEnField;

        private string nameField;

        //private string nameEnField;

        private string lettersField;

        //private string lettersEnField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int BrandId
        {
            get
            {
                return this.brandIdField;
            }
            set
            {
                this.brandIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int GroupId
        {
            get
            {
                return this.groupIdField;
            }
            set
            {
                this.groupIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ShortName
        {
            get
            {
                return this.shortNameField;
            }
            set
            {
                this.shortNameField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string ShortNameEn
        //{
        //    get
        //    {
        //        return this.shortNameEnField;
        //    }
        //    set
        //    {
        //        this.shortNameEnField = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string NameEn
        //{
        //    get
        //    {
        //        return this.nameEnField;
        //    }
        //    set
        //    {
        //        this.nameEnField = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Letters
        {
            get
            {
                return this.lettersField;
            }
            set
            {
                this.lettersField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string LettersEn
        //{
        //    get
        //    {
        //        return this.lettersEnField;
        //    }
        //    set
        //    {
        //        this.lettersEnField = value;
        //    }
        //}
    }
}
