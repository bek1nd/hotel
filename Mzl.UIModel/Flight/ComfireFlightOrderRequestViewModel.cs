using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class ComfireFlightOrderRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        public int? DepartId { get; set; }
    }
}
