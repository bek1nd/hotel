using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    /// <summary>
    /// 证件类型
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum HotelIdType
    {
        [Description("身份证")]
        IdentityCard,
        [Description("护照")]
        Passport,
        [Description("其他")]
        Other,
        [Description("军官证")]
        OfficerCertificate,
        [Description("警官证")]
        PoliceID,
        [Description("回乡证")]
        ReentryPermit,
    }
}
