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
    public enum EnumPaymentType
    {
        /// <summary>
        /// 全部
        /// </summary>
        [Description("全部")]
        All,
        /// <summary>
        /// 现付
        /// </summary>
        [Description("现付")]
        SelfPay,
        /// <summary>
        /// 预付
        /// </summary>
        [Description("预付")]
        Prepay,
    }
}
