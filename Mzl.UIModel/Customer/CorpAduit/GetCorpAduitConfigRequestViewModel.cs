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
    public class GetCorpAduitConfigRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int? ConfigId { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        [Description("公司Id")]
        [Required]
        public string CorpId { get; set; }
    }
}
