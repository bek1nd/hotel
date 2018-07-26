using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    /// <summary>
    /// 信用卡交易状态
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum HotelCreditCardStatus
    {
        [Description("未处理")]
        UnProcess,
        [Description("处理中")]
        Processing,
        [Description("成功")]
        Succeed,
        [Description("失败")]
        Fail,
    }
}
