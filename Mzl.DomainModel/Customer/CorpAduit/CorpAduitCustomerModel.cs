using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class CorpAduitCustomerModel
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
        /// 是否有审批规则
        /// </summary>
        [Description("是否有审批规则")]
        public bool IsHasAduit { get; set; }
    }
}
