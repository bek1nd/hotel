using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Server;

namespace Mzl.IBLL.Train.RequestInterface
{
    /// <summary>
    /// 请求第三方接口出票
    /// </summary>
    public interface IRequestPrintTicketBll
    {
        TraOrderConfirmResponseModel RequestPrintTicket(TraOrderConfirmModel model);
    }
}
