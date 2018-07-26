using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    /// <summary>
    /// 担保类型
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum EnumGuaranteeMoneyType
    {

        /// <summary>
        /// 为首晚房费担保
        /// </summary>
        [Description("为首晚房费担保")]
        FirstNightCost,

        /// <summary>
        /// 为全额房费担保
        /// </summary>
        [Description("为全额房费担保")]
        FullNightCost,
    }
}
