using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Flight
{
    public class ConfirmRetModAuditPriceRequestViewModel : RequestBaseViewModel
    {

        /// <summary>
        /// 申请Id
        /// </summary>
        public int Rmid { get; set; }
        /// <summary>
        /// 违规原因
        /// </summary>
        public List<ChoiceReasonViewModel> PolicyReasonList { get; set; }
    }
}
