using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.DomainModel.Common.AuditOrder
{
    public class AuditResultModel
    {
        public int Code { get; set; }
        public string AuditResult { get; set; }
        public int? NextAuditCid { get; set; }
        /// <summary>
        /// 审核单据对应的客户Id
        /// </summary>
        public int OwnCid { get; set; }
        /// <summary>
        /// 审核单据Id
        /// </summary>
        public int Id { get; set; }
        public OrderSourceTypeEnum OrderType { get; set; }
    }
}
