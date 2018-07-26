using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 支付代扣税费信息
    /// </summary>
    public class PayTaxInfo
    {
        /// <summary>
        /// 税费代码
        /// </summary>
        public string TaxCd { get; set; }
        /// <summary>
        /// 税费金额
        /// </summary>
        public float? TaxAmount { get; set; }
        /// <summary>
        /// 税费旅客类型
        /// </summary>
        public string TaxPassTp { get; set; }
    }
}
