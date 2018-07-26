using Mzl.IDAL.Train.Server.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IDAL.Train.Server.DAL;
using Mzl.DAL.Train.Server.DAL;

namespace Mzl.DAL.Train.Server.Factory
{
    public class PrintTicketServerDALFactory : IPrintTicketServerDALFactory
    {
        public IPrintTicketServerDAL CreateSampleDalObj()
        {
            return new PrintTicketServerDAL();
        }
    }
}
