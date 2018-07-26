using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class ConfirmRetModAuditPriceResultModel
    {
        public bool IsSuccess { get; set; }
        public int? OwnCid { get; set; }
        public int Rmid { get; set; }
        /// <summary>
        /// 差旅审批规则Id
        /// </summary>
        public int? CorpAduitId { get; set; }
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        public int? CorpPolicyId { get; set; }
        /// <summary>
        /// 是否违反了差旅政策
        /// </summary>
        public bool? IsViolatePolicy { get; set; }
    }
}
