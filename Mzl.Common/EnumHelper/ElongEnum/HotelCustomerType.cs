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
    public enum HotelCustomerType
    {
        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        None,

        /// <summary>
        /// 统一价
        /// </summary>
        [Description("统一价")]
        All,

        /// <summary>
        /// 内宾价
        /// </summary>
        [Description("内宾价")]
        Chinese,

        /// <summary>
        /// 外宾价
        /// </summary>
        [Description("外宾价")]
        OtherForeign,

        /// <summary>
        /// 港澳台客人价
        /// </summary>
        [Description("港澳台客人价")]
        HongKong,

        /// <summary>
        /// 日本客人价
        /// </summary>
        [Description("日本客人价")]
        Japanese,
    }
}
