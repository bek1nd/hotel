using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper
{
    /// <summary>
    /// 审批类型
    /// </summary>
    public enum OrderCheckTypeEnum
    {
        /// <summary>
        /// 邮件审批
        /// </summary>
        [Description("邮件审批")]
        E,
        /// <summary>
        /// 电话审批
        /// </summary>
        [Description("电话审批")]
        T,
    }
}
