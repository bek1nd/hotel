using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.SendAppMessage
{
    public interface IGetPrintFltTicketEmailMessageContentMyServiceBll: IBaseServiceBll
    {
        /// <summary>
        /// 获取审批类型app推送内容
        /// </summary>
        /// <param name="sendAppMessageModels"></param>
        void GetSendAppMessage(List<SendAppMessageModel> sendAppMessageModels);
    }
}
