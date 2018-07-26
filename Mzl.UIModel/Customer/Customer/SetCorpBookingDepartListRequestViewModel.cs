using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.Customer
{
    public class SetCorpBookingDepartListRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 部门Id集合
        /// </summary>
        [Description("部门Id集合")]
        public List<int> DepartIdList { get; set; }
        /// <summary>
        /// 被设置的客户Id
        /// </summary>
        [Description("被设置的客户Id")]
        public int CustomerCid { get; set; }
        /// <summary>
        /// 是否设置全部
        /// </summary>
        [Description("是否设置全部")]
        public bool IsAll { get; set; }
    }
}
