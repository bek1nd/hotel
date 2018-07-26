using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class AddCorpAduitDepartmentRelationRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 部门Id集合
        /// </summary>
        [Description("部门Id集合")]
        public List<KeyValueViewModel<int, bool>> DepartmentIdList { get; set; }
        /// <summary>
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int AduitId { get; set; }
    }
}
