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
    public class HotelListResponseEntity
    {
        /// <summary>
        /// 查询到的酒店总数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 酒店结果集
        /// </summary>
        public HotelEntity[] Hotels { get; set; }

        /// <summary>
        /// 汇率信息
        /// </summary>
        public ExchangeRateEntity[] ExchangeRateList { get; set; }
    }
}
