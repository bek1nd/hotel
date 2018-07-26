using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Common.TravelManage
{
    public class TravelDataModel
    {
        public int Sequence { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string DName { get; set; }
        public string AName { get; set; }
        public string TravelNo { get; set; }
        public DateTime DTime { get; set; }
        public DateTime ATime { get; set; }

    }
}
