using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    /// <summary>
    /// 变更规则
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.33440")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public enum EnumPrepayChangeRule
    {

        /// <summary>
        /// 不允许变更取消
        /// </summary>
        [Description("不允许变更取消")]
        PrepayNoChange,

        /// <summary>
        /// 在到店当日24点前Hour小时前按规则看是否可以免费变更取消（一般是不收罚金），在Hour和Hour2之间按规则存在罚金，Hour2之后不能变更取消
        /// </summary>
        [Description("在到店当日24点前Hour小时前按规则看是否可以免费变更取消（一般是不收罚金），在Hour和Hour2之间按规则存在罚金，Hour2之后不能变更取消")]
        PrepayNeedSomeDay,

        /// <summary>
        /// 在约定日期时间点(DateNum + Time)前可以免费变更取消
        /// </summary>
        [Description("在约定日期时间点(DateNum + Time)前可以免费变更取消")]
        PrepayNeedOneTime,
    }
}
