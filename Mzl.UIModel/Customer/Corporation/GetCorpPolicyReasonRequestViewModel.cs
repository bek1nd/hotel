using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.Corporation
{
    public class GetCorpPolicyReasonRequestViewModel : RequestBaseViewModel
    {
        public string ReasonType { get; set; } = "T";
    }
}
