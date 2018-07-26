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
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true, ElementName = "HotelGeos")]
    public class HotelGeosResponseEntity
    {

        private HotelGeo[] hotelGeoListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("HotelGeo")]
        public HotelGeo[] HotelGeoList
        {
            get
            {
                return this.hotelGeoListField;
            }
            set
            {
                this.hotelGeoListField = value;
            }
        }
    }
}
