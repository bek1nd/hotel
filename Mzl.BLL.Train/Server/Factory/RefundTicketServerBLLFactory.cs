using Mzl.IBLL.Train.Server.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.IDAL.Train.Server.Factory;
using Mzl.BLL.Train.Server.BLL;
using Mzl.DAL.Train.Server.Factory;

namespace Mzl.BLL.Train.Server.Factory
{
    public class RefundTicketServerBLLFactory : IRefundTicketServerBLLFactory
    {
        public IRefundTicketServerBLL<TraRefundTicketCallBackLogModel> CreateBllObj()
        {
            IRefundTicketServerDALFactory factory = new RefundTicketServerDALFactory();
            return new RefundTicketServerBLL(factory);
        }

        public IRefundTicketServerBLL<TraRefundTicketCallBackLogModel> CreateSampleBllObj()
        {
            return new RefundTicketServerBLL();
        }
    }
}
