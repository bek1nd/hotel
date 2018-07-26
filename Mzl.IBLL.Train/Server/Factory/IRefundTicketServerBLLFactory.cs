using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.Factory;

namespace Mzl.IBLL.Train.Server.Factory
{
    public interface IRefundTicketServerBLLFactory: IBaseBLLFactory<IRefundTicketServerBLL<TraRefundTicketCallBackLogModel>>
    {
    }
}
