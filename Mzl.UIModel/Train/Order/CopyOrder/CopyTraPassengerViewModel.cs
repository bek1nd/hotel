using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order.CopyOrder
{
    public class CopyTraPassengerViewModel
    {
        public int Pid { get; set; }
        /// <summary>
        /// 服务费
        /// </summary>
        public decimal? ServiceFee { get; set; }
        /// <summary>
        /// 票价
        /// </summary>
        public decimal? FacePrice { get; set; }
    }
}
