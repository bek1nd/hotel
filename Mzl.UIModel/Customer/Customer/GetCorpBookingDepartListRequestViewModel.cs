using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.Customer
{
    public class GetCorpBookingDepartListRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        public int CustomerCid { get; set; }
    }
}
