using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class QueryFltOrderRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        [Required]
        public int? OrderId { get; set; }

    }
}
