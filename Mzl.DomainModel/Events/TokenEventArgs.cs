using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Events
{
    public class TokenEventArgs: EventArgs
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public int Cid { get; set; }
        public string FromSource { get; set; }

        public TokenEventArgs(string token,string userId,int cid, string fromSource)
        {
            Token = token;
            UserId = userId;
            Cid = cid;
            FromSource = fromSource;
        }

    }
}
