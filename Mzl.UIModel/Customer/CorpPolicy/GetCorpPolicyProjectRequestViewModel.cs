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
    public class GetCorpPolicyProjectRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 公司Id
        /// </summary>
        [Required]
        [Description("公司Id")]
        public string CorpId { get; set; }
        /// <summary>
        /// 政策Id
        /// </summary>
        [Description("政策Id")]
        public int? PolicyId { get; set; }
        /// <summary>
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int? AduitId { get; set; }
    }
}
