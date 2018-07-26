using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel
{
    public class ReturnToken
    {
        public int AID { get; set; }
        public int SID { get; set; }
        public string Access_Token { get; set; }
        public int Expires_in { get; set; }
        public string Refresh_Token { get; set; }
    }
}
