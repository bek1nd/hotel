using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Hotel.Elong
{
    public class ExchangeRateEntity
    {
        /// <summary>
        /// 货币编码
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// 汇率值
        /// </summary>
        public decimal Rate { get; set; }
    }
}
