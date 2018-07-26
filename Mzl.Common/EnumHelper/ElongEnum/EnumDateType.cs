using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum EnumDateType
    {

        /// <summary>
        /// 入住日期
        /// </summary>
        [Description("入住日期")]
        CheckInDay,

        /// <summary>
        /// 在店日期
        /// </summary>
        [Description("在店日期")]
        StayDay,

        /// <summary>
        /// 预订日期（订单的创建日期）
        /// </summary>
        [Description("预订日期（订单的创建日期）")]
        BookDay,
    }
}
