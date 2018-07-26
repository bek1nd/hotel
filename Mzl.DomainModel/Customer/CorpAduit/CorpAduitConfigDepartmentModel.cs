using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class CorpAduitConfigDepartmentModel
    {
        /// <summary>
        /// 部门Id集合
        /// </summary>
        [Description("部门Id集合")]
        public List<KeyValueModel<int, bool>> DepartmentIdList { get; set; }
        /// <summary>
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int AduitId { get; set; }
    }
}
