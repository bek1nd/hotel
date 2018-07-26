using Mzl.Common.Factory;
using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.Server.Factory
{
   public interface ITicketRefundServerBLLFactoty : IBaseBLLFactory<ITicketRefundServerBLL<TraTicketRefundResponseModel>>
    {
    }
}
