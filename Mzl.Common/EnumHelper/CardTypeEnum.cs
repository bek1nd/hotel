using System.ComponentModel;

namespace Mzl.Common.EnumHelper
{
    /// <summary>
    /// 证件类型枚举
    /// </summary>
    public enum CardTypeEnum
    {
        /// <summary>
        /// 二代身份证
        /// </summary>
        [Description("二代身份证")]
        Certificate = 1,
        /// <summary>
        /// 护照
        /// </summary>
        [Description("护照")]
        Passport = 2,
        /// <summary>
        /// 回乡证
        /// </summary>
        [Description("回乡证")]
        HomePermit = 3,
        /// <summary>
        /// 台胞证
        /// </summary>
        [Description("台胞证")]
        MTP = 4,
        /// <summary>
        /// 港澳通行证
        /// </summary>
        [Description("港澳通行证")]
        HongKongAndMacaoPass = 5,
        /// <summary>
        /// 军人证
        /// </summary>
        [Description("军人证")]
        MilitaryCard = 6,
        /// <summary>
        /// 国际海员证
        /// </summary>
        [Description("国际海员证")]
        SeafarerCertificate = 7,
        /// <summary>
        /// 外国人永久居留证
        /// </summary>
        [Description("外国人永久居留证")]
        ResidencePermit = 8,
        /// <summary>
        /// 旅行证
        /// </summary>
        [Description("旅行证")]
        TravelPermit = 9,
        /// <summary>
        /// 户口簿
        /// </summary>
        [Description("户口簿")]
        ResidenceBooklet = 10,
        /// <summary>
        /// 入台证
        /// </summary>
        [Description("入台证")]
        TaiwanEntryPermit = 11,
        /// <summary>
        /// 其他
        /// </summary>
        [Description("其他")]
        Other = 99
    }
}
