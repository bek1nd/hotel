using Mzl.Common.Log;
using Mzl.IBLL.Tran.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Train.Server
{
    public class HoldSeatServer : IHoldSeatServer<string>
    {
        public bool WriteHoldSeatLog(string t)
        {
            LogHelper.WriteLog("占座回调:" + t, "CallBack");
            return true;
        }
    }
}
