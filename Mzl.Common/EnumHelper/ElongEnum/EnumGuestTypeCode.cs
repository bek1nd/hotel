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
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public enum EnumGuestTypeCode {
        
        /// <summary>
        /// 统一价
        /// </summary>
        [Description("统一")]
        All,
        
        /// <summary>
        /// 内宾价，需提示客人“须持大陆身份证入住”
        /// </summary>
        [Description("内宾")]
        Chinese,
        
        /// <summary>
        /// 外宾价，需提示客人“须持国外护照入住”
        /// </summary>
        [Description("外宾")]
        OtherForeign,
        
        /// <summary>
        /// 港澳台客人价，需提示客人“须持港澳台身份证入住”
        /// </summary>
        [Description("港澳台客人")]
        HongKong,
        
        /// <summary>
        /// 日本客人价，需提示客人“须持日本护照入住”
        /// </summary>
        [Description("日本客人")]
        Japanese,

        /// <summary>
        /// 
        /// </summary>
        [Description("中宾价")]
        ChinaGuest  
    }
}
