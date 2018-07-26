using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.CorpPolicy
{
    public class AddPolicyDepartmentRelationRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 部门Id集合
        /// </summary>
        [Description("部门Id集合")]
        public List<KeyValueViewModel<int,bool>> DepartmentIdList { get; set; }
        /// <summary>
        /// 政策Id
        /// </summary>
        [Description("政策Id")]
        public int PolicyId { get; set; }
    }
}
