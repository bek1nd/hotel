using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.DomainModel.Events;
using Mzl.DomainModel.Common.Account;
using Mzl.DomainModel.Train.GrabTicket.KongTieInterface;

namespace Mzl.IBLL.Train.GrabTicket
{
    /// <summary>
    /// 获取抢票异步通知
    /// </summary>
    public interface IGetGrabTicketNoticeServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 获取抢票异步成功通知，并做处理
        /// 则自动生成火车订单，通知抢票发起者
        /// </summary>
        void GetGrabTicketSuccessNotice(GrabTicketSuccessedDataAsyncResponseModel successedData);
        /// <summary>
        /// 获取抢票异步失败通知，并做处理
        /// </summary>
        /// <param name="failedData"></param>
        void GetGrabTicketFailedNotice(GrabTicketFailedDataAsyncResponseModel failedData);
        /// <summary>
        /// 通知付款记录对象，进行付款记录
        /// </summary>
        event EventHandler<CommonEventArgs<AccountDetailModel>> PaySupplierEvent;
    }
}
