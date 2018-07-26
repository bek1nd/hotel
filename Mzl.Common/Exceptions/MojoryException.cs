using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.Common.Exceptions
{
    public class MojoryException : Exception
    {
        public MojoryApiResponseCode Code { get; private set; }
        public string CodeMessage { get; private set; }
        public int OtherId { get; private set; }
        public MojoryException(MojoryApiResponseCode code)
        {
            this.Code = code;
        }

        public MojoryException(MojoryApiResponseCode code,string codeMessage)
        {
            this.Code = code;
            this.CodeMessage = codeMessage;
        }

        public MojoryException(MojoryApiResponseCode code, string codeMessage,int otherId)
        {
            this.Code = code;
            this.CodeMessage = codeMessage;
            this.OtherId = otherId;
        }

    }
}
