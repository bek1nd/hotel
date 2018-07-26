using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 税率
    /// </summary>
    public class Tax
    {
        /// <summary>
        /// 数量
        /// </summary>
        public string count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 税费金额
        /// </summary>
        public double? taxAmount { get; set; }
        /// <summary>
        /// 税种
        /// </summary>
        public string taxcd { get; set; }
    }
}
