using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class FltModPassengerModel
    {
        public int Id { get; set; }

        public int Rmid { get; set; }

        public int Pid { get; set; }
        /// <summary>
        /// 对应原订单乘机人
        /// </summary>
        public FltPassengerModel Passenger { get; set; }

        public string PType { get; set; }

        public string Name => Passenger?.Name;
        public string CardNo => Passenger?.CardNo;
        public string CardTypeDesc => Passenger?.CardTypeDesc;
    }
}
