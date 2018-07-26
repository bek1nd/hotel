using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.ChangeInfo
{
    public class ChangeInfoResEntity
    {
        public ResponseStatusEntity ResponseStatus { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public IList<ChangeInfo> ChangeInfos { get; set; }
    }
}
