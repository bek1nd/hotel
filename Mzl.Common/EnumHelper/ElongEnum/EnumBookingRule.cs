using System;
using System.ComponentModel;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [Serializable()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum EnumBookingRule
    {

        [Description("无")]
        NoneRule,
        /// <summary>
        /// 务必提供客人国籍
        /// </summary>
        [Description("务必提供客人国籍")]
        NeedNationality,
        /// <summary>
        /// 您预订了N间房，请您提供不少于N的入住客人姓名 
        /// </summary>
        [Description(" 您预订了N间房，请您提供不少于N的入住客人姓名")]
        PerRoomPerName,
        /// <summary>
        /// 此酒店要求外宾务必留英文拼写 
        /// </summary>
        [Description("此酒店要求外宾务必留英文拼写")]
        ForeignerNeedEnName,
        /// <summary>
        /// 几点到几点酒店不接受预订 , 此处校验的是下单时的预订时间
        /// </summary>
        [Description("几点到几点酒店不接受预订 , 此处校验的是下单时的预订时间")]
        RejectCheckinTime,
        /// <summary>
        /// 务必提供客人手机号(请加在联系人结点Contact上)
        /// </summary>
        [Description("务必提供客人手机号(请加在联系人结点Contact上)")]
        NeedPhoneNo,
    }
}
