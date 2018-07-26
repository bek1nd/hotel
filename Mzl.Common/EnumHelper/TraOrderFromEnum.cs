using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper
{
    public enum TraOrderFromEnum
    {
        /// <summary>
        /// 接口
        /// </summary>
        [Description("接口")]
        Interface = 0,
        /// <summary>
        /// 手工
        /// </summary>
        [Description("手工")]
        Hand = 1,
    }
}
