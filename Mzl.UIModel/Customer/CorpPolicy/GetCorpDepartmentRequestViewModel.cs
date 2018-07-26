using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.CorpPolicy
{
    public class GetCorpDepartmentRequestViewModel : RequestBaseViewModel
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
