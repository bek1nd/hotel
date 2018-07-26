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
    public enum EnumDrrPreferential
    {
        /// <summary>
        /// 金额
        /// </summary>
        [Description("金额")]
        Cash,
        /// <summary>
        /// 比例
        /// </summary>
        [Description("比例")]
        Scale,
        /// <summary>
        /// 金额
        /// </summary>
        [Description("金额")]
        Money,
        /// <summary>
        /// 比例  
        /// </summary>
        [Description("比例")]
        Percent
    }
}
