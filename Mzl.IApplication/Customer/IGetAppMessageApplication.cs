using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.AppMessage;

namespace Mzl.IApplication.Customer
{
    public interface IGetAppMessageApplication : IBaseApplication
    {
        GetUnReadMessageCountResponseViewModel GetUnReadMessageCount(GetUnReadMessageCountRequestViewModel request);

        GetAppMessageResponseViewModel GetUnReadMessage(GetAppMessageRequestViewModel request);

        bool SetRead(int sendId);
    }
}
