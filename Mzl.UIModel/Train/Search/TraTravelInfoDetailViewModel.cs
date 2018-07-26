using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Search
{
    public class TraTravelInfoDetailViewModel
    {


      public TraTravelInfoDetailViewModel( string SeatCode ,string SeatName, int SeatIndex)
        {
            this.SeatName = SeatName;
            this.SeatIndex = SeatIndex;
            this.SeatCode = SeatCode;
        }

        /// <summary>
        /// 座位信息
        /// </summary>
        public string SeatName { get; set; }
        public string SeatCount { get; set; }
        public string SeatPrice { get; set; }
        public int SeatIndex { get; set; }
        public string SeatCode { get; set; }

        public string IsViolate { get; set; } 
        public string ViolateTPolicyValQ { get; set; } 
        public string ViolateTPolicyValQDesc { get; set; } 
        public string ViolateTPolicyValM { get; set; } 
        public string ViolateTPolicyValMDesc { get; set; } 
        public string ViolateTPolicyValS { get; set; } 
        public string ViolateTPolicyValSDesc { get; set; } 

    }
}
