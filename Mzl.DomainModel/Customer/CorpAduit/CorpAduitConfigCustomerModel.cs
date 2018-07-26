using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class CorpAduitConfigCustomerModel
    {
        /// <summary>
        /// 客户Id集合
        /// </summary>
        [Description("客户Id集合")]
        public List<int> CidList { get; set; }
        /// <summary>
        /// 审批规则Id
        /// </summary>
        [Description("审批规则Id")]
        public int AduitId { get; set; }
    }
}
