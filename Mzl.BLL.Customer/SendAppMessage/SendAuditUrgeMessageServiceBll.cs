using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.SendAppMessage;
using Mzl.IDAL.Customer.Customer;

namespace Mzl.BLL.Customer.SendAppMessage
{
    internal class SendAuditUrgeMessageServiceBll: BaseServiceBll,ISendAuditUrgeMessageServiceBll
    {
        private readonly SendAppMessageFactory _sendAppMessageFactory;

        public SendAuditUrgeMessageServiceBll(ISendAppMessageDal sendAppMessageDal,
            ISendAppMessageBll sendAppMessageBll, ICustomerAppClientIdDal customerAppClientIdDal)
        {
            _sendAppMessageFactory = new SendAppMessageFactory(sendAppMessageDal, sendAppMessageBll,
                customerAppClientIdDal);
        }

        public List<SendAppMessageModel> Get()
        {
            return _sendAppMessageFactory.GetSendAppMessage(SendAppMessageTypeEnum.AuditUrgeNotice);
        }

        public void Send(List<SendAppMessageModel> sendAppMessageModels)
        {
            _sendAppMessageFactory.SendAppMessage(sendAppMessageModels, SendAppMessageTypeEnum.AuditUrgeNotice);
        }
    }
}
