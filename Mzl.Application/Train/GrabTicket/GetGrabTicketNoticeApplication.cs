using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Application.Account.Factory;
using Mzl.Common.EmailHelper;
using Mzl.Framework.Base;
using Mzl.IApplication.Account.Domain;
using Mzl.IApplication.Account.Factory;
using Mzl.IApplication.Train.GrabTicket;
using Mzl.IBLL.Train.GrabTicket;
using Mzl.IBLL.Train.GrabTicket.KongTieInterface;

namespace Mzl.Application.Train.GrabTicket
{
    public class GetGrabTicketNoticeApplication : BaseApplicationService, IGetGrabTicketNoticeApplication
    {
        private readonly IResponseAsyncGrabTicketServiceBll _responseAsyncGrabTicketBll;
        private readonly IGetGrabTicketNoticeServiceBll _getGrabTicketNoticeServiceBll;

        public GetGrabTicketNoticeApplication(IResponseAsyncGrabTicketServiceBll responseAsyncGrabTicketBll,
            IGetGrabTicketNoticeServiceBll getGrabTicketNoticeServiceBll)
        {
            _responseAsyncGrabTicketBll = responseAsyncGrabTicketBll;
            _getGrabTicketNoticeServiceBll = getGrabTicketNoticeServiceBll;
        }

        public void GetGrabTicketNotice(string responseData)
        {
            bool flag = _responseAsyncGrabTicketBll.ResponseGrabTicketResult(responseData); //获取异步抢票通知

            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    if (flag)
                    {
                        IAccountDomainFactory accountDomainFactory = new AccountDomainFactory();
                        IAccountDomain accountDomain = accountDomainFactory.CreateDomainObj();

                        _getGrabTicketNoticeServiceBll.PaySupplierEvent+= accountDomain.DoPaySupplierEvent;

                        _getGrabTicketNoticeServiceBll.GetGrabTicketSuccessNotice(
                            _responseAsyncGrabTicketBll.SuccessedResult);

                        _getGrabTicketNoticeServiceBll.PaySupplierEvent -= accountDomain.DoPaySupplierEvent;

                    }
                    else
                    {
                        _getGrabTicketNoticeServiceBll.GetGrabTicketFailedNotice(
                            _responseAsyncGrabTicketBll.FailedResult);
                    }

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }

            }


            //发送邮件通知
            //if (flag)
            //{
            //    string context = string.Format("");
            //    EmailHelper.SendEmail("", "火车抢票成功通知", null, null, context, _email);
            //}
            //else
            //{
            //}
        }
    }
}
