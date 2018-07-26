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
    public class GetCorpAduitCustomerRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 公司Id
        /// </summary>
        [Required]
        [Description("公司Id")]
        public string CorpId { get; set; }
        /// <summary>
        /// 审批规则id
        /// </summary>
        [Description("审批规则id")]
        public int AduitId { get; set; }
    }
}
