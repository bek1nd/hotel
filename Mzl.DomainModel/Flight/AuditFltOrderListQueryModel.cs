using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Customer.CorpPolicy;

namespace Mzl.DomainModel.Flight
{
    public class AuditFltOrderListQueryModel : BaseOrderQueryModel
    {
        /// <summary>
        /// 审核人id
        /// </summary>
        public int AuditCid { get; set; }
        public SearchCityAportModel AportInfo { get; set; }
        public List<ChoiceReasonModel> PolicyReasonList { get; set; }
        /// <summary>
        /// 是否审核
        /// </summary>
        public bool IsAudit { get; set; }

    }
}
