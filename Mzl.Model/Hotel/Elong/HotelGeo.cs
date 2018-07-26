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
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = true)]
    public class HotelGeo
    {

        /// <summary>
        /// 行政区
        /// </summary>
        private PubObj[] districtsField;

        /// <summary>
        /// 商业区
        /// </summary>
        private PubObj[] commericalLocationsField;

        /// <summary>
        /// 标志物
        /// </summary>
        private PubObj[] landmarkLocationsField;

        /// <summary>
        /// 国家
        /// </summary>
        private string countryField;

        /// <summary>
        /// 省份名称
        /// </summary>
        private string provinceNameField;

        /// <summary>
        /// 省份编号
        /// </summary>
        private string provinceIdField;

        /// <summary>
        /// 城市名称
        /// </summary>
        private string cityNameField;

        /// <summary>
        /// 城市名称
        /// </summary>
        private string cityCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Location")]
        public PubObj[] Districts
        {
            get
            {
                return this.districtsField;
            }
            set
            {
                this.districtsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Location")]
        public PubObj[] CommericalLocations
        {
            get
            {
                return this.commericalLocationsField;
            }
            set
            {
                this.commericalLocationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Location")]
        public PubObj[] LandmarkLocations
        {
            get
            {
                return this.landmarkLocationsField;
            }
            set
            {
                this.landmarkLocationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Country
        {
            get
            {
                return this.countryField;
            }
            set
            {
                this.countryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ProvinceName
        {
            get
            {
                return this.provinceNameField;
            }
            set
            {
                this.provinceNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ProvinceId
        {
            get
            {
                return this.provinceIdField;
            }
            set
            {
                this.provinceIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CityName
        {
            get
            {
                return this.cityNameField;
            }
            set
            {
                this.cityNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CityCode
        {
            get
            {
                return this.cityCodeField;
            }
            set
            {
                this.cityCodeField = value;
            }
        }
    }
    
}
