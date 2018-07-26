using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Base
{
    public class BaseOrderListQueryEntity
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int? Cid { get; set; }
        public string UserId { get; set; }
        public string CorpId { get; set; }
    }
}
