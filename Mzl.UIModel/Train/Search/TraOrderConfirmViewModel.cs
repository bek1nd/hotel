using Mzl.UIModel.Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Search
{
    public class TraOrderConfirmViewModel
    {
        /// <summary>
        /// 使用方订单号
        /// </summary>  
        [Description("使用方订单号")]
        public string OrderID { get; set; }

        /// <summary>
        /// 交易单号
        /// </summary>  
        [Description("交易单号")]
        public string TransactionID { get; set; }

        public int Cid { get; set; }
    }
}
