using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.CorpAduit
{
    public class DeleteCorpAduitConfigRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 差旅审批规则Id集合
        /// </summary>
        [Description("差旅审批规则Id集合")]
        [Required]
        public List<int> ConfigIdList { get; set; }
    }
}
