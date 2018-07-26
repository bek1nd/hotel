using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Flight
{
    public class FltRetModApplyLogModel
    {
        public int LogId { get; set; }

        public int? Rmid { get; set; }

        public string Oid { get; set; }

        public string LogType { get; set; }

        public string Remark { get; set; }

        public DateTime? LogTime { get; set; }
    }
}
