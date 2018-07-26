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
    public class OrderHotelRequest
    {
        private string hotelIdField;
        private string nameField;
        private string addressField;
        private string phoneField;

        /// <summary>
        /// 酒店ID
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
        /// 酒店名称
        /// </summary>
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

        /// <summary>
        /// 酒店地址
        /// </summary>
        public string Address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }

        /// <summary>
        /// 酒店电话
        /// </summary>
        public string Phone
        {
            get
            {
                return this.phoneField;
            }
            set
            {
                this.phoneField = value;
            }
        }
    }
}
