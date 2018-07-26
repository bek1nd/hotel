using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Customer.Corporation
{
    public class GetCorpPolicyReasonResponseViewModel
    {
        /// <summary>
        /// 差旅政策选择原因
        /// </summary>
        [Description("差旅政策选择原因")]
        public List<KeyValueViewModel<string, string>> PolicyReason { get; set; }
    }
}
