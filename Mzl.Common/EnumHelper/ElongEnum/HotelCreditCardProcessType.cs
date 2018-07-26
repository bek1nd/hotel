using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    /// <summary>
    /// 信用卡交易类型
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum HotelCreditCardProcessType
    {
        [Description("直接扣款")]
        DirectCharge,
        [Description("退款")]
        Refund,
        [Description("授权")]
        Auth,
        [Description("取消授权")]
        CancelAuth,
        [Description("授权后扣款")]
        Charge,
    }
}
