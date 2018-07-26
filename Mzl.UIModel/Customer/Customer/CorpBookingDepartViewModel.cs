using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.Customer
{
    public class CorpBookingDepartViewModel
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        [Description("部门Id")]
        public int DepartId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Description("部门名称")]
        public string DepartName { get; set; }
        /// <summary>
        /// 是否能预定该部门
        /// </summary>
        [Description("是否能预定该部门")]
        public bool IsBookinged { get; set; }
    }
}
