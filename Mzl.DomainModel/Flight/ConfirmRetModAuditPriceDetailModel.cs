using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class ConfirmRetModAuditPriceDetailModel
    {

        /// <summary>
        /// 航班序号
        /// </summary>
        public int Sequence { get; set; }
        public int Pid { get; set; }
        /// <summary>
        /// 违规原因Id
        /// </summary>
        public int? ChoiceReasonId { get; set; }
    }
}
