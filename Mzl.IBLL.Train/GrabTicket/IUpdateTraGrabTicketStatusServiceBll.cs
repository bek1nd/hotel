using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.GrabTicket;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Train.GrabTicket
{
    /// <summary>
    /// 更新抢票信息状态
    /// </summary>
    public interface IUpdateTraGrabTicketStatusServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 提交抢票完毕之后，根据返回信息更新抢票状态
        /// </summary>
        /// <param name="updateTraGrabTicketStatusModel"></param>
        /// <returns></returns>
        bool UpdateTraGrabTicketStatusByAfterSubmit(UpdateTraGrabTicketStatusModel updateTraGrabTicketStatusModel);
        
    }
}
