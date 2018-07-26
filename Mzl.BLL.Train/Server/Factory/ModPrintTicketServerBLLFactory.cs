using Mzl.IBLL.Train.Server.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.IDAL.Train.Server.Factory;
using Mzl.DAL.Train.Server.Factory;
using Mzl.BLL.Train.Server.BLL;

namespace Mzl.BLL.Train.Server.Factory
{
    public class ModPrintTicketServerBLLFactory : IModPrintTicketServerBLLFactory
    {
        public IModPrintTicketServerBLL<TraModPrintTicketCallBackLogModel> CreateBllObj()
        {
            IModPrintTicketServerDALFactory factory = new ModPrintTicketServerDALFactory();
            return new ModPrintTicketServerBLL(factory);
        }

        public IModPrintTicketServerBLL<TraModPrintTicketCallBackLogModel> CreateSampleBllObj()
        {
            return new ModPrintTicketServerBLL();
        }
    }
}
