using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.Customer
{
    public class GetCorpBookingDepartListResponseViewModel
    {
        /// <summary>
        /// 预定部门信息集合
        /// </summary>
        [Description("预定部门信息集合")]
        public List<CorpBookingDepartViewModel> BookingDepartList { get; set; }
        /// <summary>
        /// 是否全部部门
        /// </summary>
        [Description("是否全部部门")]
        public bool IsAll { get; set; }
    }
}
