using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.CorpPolicy
{
    public class CorpPolicyCustomerModel
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        public int Cid { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        [Description("客户名称")]
        public string CustomerName { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Description("部门名称")]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 是否有政策
        /// </summary>
        [Description("是否有政策")]
        public bool IsHasPolicy { get; set; }
    }
}
