using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.Corporation
{
    public class CorpDepartmentViewModel
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        [Description("部门Id")]
        public string Id { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Description("部门名称")]
        public string DepartName { get; set; }
    }
}
