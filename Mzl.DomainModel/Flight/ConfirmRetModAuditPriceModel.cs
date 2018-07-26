using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class ConfirmRetModAuditPriceModel
    {

        public int? Cid { get; set; }
        public int Rmid { get; set; }
        public List<ConfirmRetModAuditPriceDetailModel> DetailList { get; set; }
    }
}
