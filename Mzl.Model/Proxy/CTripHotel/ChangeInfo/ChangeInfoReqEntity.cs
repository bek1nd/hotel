using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.ChangeInfo
{
    public class ChangeInfoReqEntity
    {
        public SearchCandidate SearchCandidate { get; set; }
        public Settings Settings { get; set; }
        public PagingSettings PagingSettings { get; set; }
    }
}
