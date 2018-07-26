using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    public class ChooseSeatModel
    {
        /// <summary>
        /// 座位排号
        /// </summary>
        public int SeatIndex { get; set; }
        /// <summary>
        /// 座位号
        /// </summary>
        public List<string> SeatNo { get; set; }
    }
}
