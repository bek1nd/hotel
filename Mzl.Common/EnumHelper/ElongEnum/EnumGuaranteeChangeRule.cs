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
    public enum EnumGuaranteeChangeRule
    {

        /// <summary>
        /// 不允许变更取消
        /// </summary>
        [Description("不允许变更取消")]
        NoChange,

        /// <summary>
        /// 允许变更/取消,需在XX日YY时之前通知
        /// </summary>
        [Description("允许变更/取消,需在XX日YY时之前通知")]
        NeedSomeDay,

        /// <summary>
        /// 允许变更/取消,需在最早到店时间之前几小时通知
        /// </summary>
        [Description("允许变更/取消,需在最早到店时间之前几小时通知")]
        NeedCheckinTime,

        /// <summary>
        /// 允许变更/取消,需在到店日期的24点之前几小时通知
        /// </summary>
        [Description("允许变更/取消,需在到店日期的24点之前几小时通知")]
        NeedCheckin24hour,
    }
}
