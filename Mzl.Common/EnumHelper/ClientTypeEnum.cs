using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper
{
    public enum ClientTypeEnum
    {
        /// <summary>
        /// 安卓
        /// </summary>
        [Description("安卓")]
        A,
        /// <summary>
        /// IOS
        /// </summary>
        [Description("IOS")]
        I,
        /// <summary>
        /// 差旅网站
        /// </summary>
        [Description("差旅线上网站")]
        P,
        /// <summary>
        /// OA网站
        /// </summary>
        [Description("OA系统")]
        O
    }
}
