using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.CorpAduit
{
    public enum AduitTypeEnum
    {
        /// <summary>
        /// 自操作
        /// </summary>
        [Description("自操作")]
        N = 0,
        /// <summary>
        /// 代操作
        /// </summary>
        [Description("代操作")]
        D = 1,
        /// <summary>
        /// tc代操作
        /// </summary>
        [Description("tc代操作")]
        T = 2,
    }
}
