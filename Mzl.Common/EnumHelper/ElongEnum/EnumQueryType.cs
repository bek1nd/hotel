using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum EnumQueryType
    {

        /// <summary>
        /// 智能搜索 （默认）
        /// </summary>
        [Description("智能搜索 （默认）")]
        Intelligent,

        /// <summary>
        /// 酒店名称
        /// </summary>
        [Description("酒店名称")]
        HotelName,

        /// <summary>
        /// 位置名称
        /// </summary>
        [Description("位置名称")]
        LocationName,
    }
}
