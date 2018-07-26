using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class GetModRetApplyAuditViewModel
    {
        public int Pid { get; set; }
        public string Name { get; set; }
        public string DportName { get; set; }
        public string DportCity { get; set; }
        public string AportName { get; set; }
        public string AportCity { get; set; }
        /// <summary>
        /// 核价的价格
        /// </summary>
        public decimal? AuditPrice { get; set; }
        /// <summary>
        /// 违规信息
        /// </summary>
        public string PolicyDesc { get; set; }
        public int? ChoiceReasonId { get; set; }
        /// <summary>
        /// 选择原因
        /// </summary>
        public string ChoiceReason { get; set; }
        public int Sequence { get; set; }
    }
}
