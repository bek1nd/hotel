using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.UIModel.Customer.AppMessage;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.IBLL.Customer.SendAppMessage;

namespace Mzl.Application.Customer
{
    internal class GetAppMessageApplication : BaseApplicationService, IGetAppMessageApplication
    {
        private readonly IGetAppMessageServiceBll _getAppMessageServiceBll;

        public GetAppMessageApplication(IGetAppMessageServiceBll getAppMessageServiceBll)
        {
            _getAppMessageServiceBll = getAppMessageServiceBll;
        }

        public GetUnReadMessageCountResponseViewModel GetUnReadMessageCount(GetUnReadMessageCountRequestViewModel request)
        {
            int count = _getAppMessageServiceBll.GetUnReadMessageCount(request.Cid);

            return new GetUnReadMessageCountResponseViewModel() { Count= count };
        }

        public GetAppMessageResponseViewModel GetUnReadMessage(GetAppMessageRequestViewModel request)
        {
            GetAppMessageResultModel resultModel =
                _getAppMessageServiceBll.GetUnReadMessage(new GetAppMessageQueryModel()
                {
                    Cid = request.Cid,
                    PageIndex = request.PageIndex,
                    PageSize = request.PageSize
                });

            foreach (var appMessageModel in resultModel.AppMessageList)
            {
                if (!string.IsNullOrEmpty(appMessageModel.SendContent) &&
                    appMessageModel.SendContent.Contains("message=")&& appMessageModel.SendContent.Contains("&"))
                {
                    List<string> mess = appMessageModel.SendContent.Split('&').ToList();
                    appMessageModel.SendContent = mess[0].Replace("message=", "");
                }
            }

            return Mapper.Map<GetAppMessageResultModel, GetAppMessageResponseViewModel>(resultModel);

        }

        public bool SetRead(int sendId)
        {
            bool flag = _getAppMessageServiceBll.SetRead(sendId);

            return flag;
        }
    }
}
