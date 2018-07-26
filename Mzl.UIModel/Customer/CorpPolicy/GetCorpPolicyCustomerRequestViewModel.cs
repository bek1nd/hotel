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
    public class GetCorpPolicyCustomerRequestViewModel : RequestBaseViewModel
    {
        [Required]
        [Description("公司Id")]
        public string CorpId { get; set; }
        [Description("政策Id")]
        public int PolicyId { get; set; }
    }
}
