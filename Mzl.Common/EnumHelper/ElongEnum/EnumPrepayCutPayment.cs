using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    /// <summary>
    /// 扣款类型
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum EnumPrepayCutPayment
    {

        /// <summary>
        /// 金额
        /// </summary>
        [Description("金额")]
        Money,

        /// <summary>
        /// 比例
        /// </summary>
        [Description("比例")]
        Percent,

        /// <summary>
        /// 首晚
        /// </summary>
        [Description("首晚")]
        FristNight,
    }
}
