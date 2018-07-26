using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 税费信息
    /// </summary>
    public class TaxInfo
    {
        /// <summary>
        /// 税种
        /// </summary>
        public string taxCd { get; set; }
        /// <summary>
        /// 该税种税费金额
        /// </summary>
        public int? taxAm { get; set; }
        /// <summary>
        /// 旅客类型
        /// </summary>
        public string paxTp { get; set; }       
    }
}
