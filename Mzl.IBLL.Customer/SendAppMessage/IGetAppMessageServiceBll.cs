using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.SendAppMessage
{
    public interface IGetAppMessageServiceBll : IBaseServiceBll
    {
        int GetUnReadMessageCount(int cid);

        GetAppMessageResultModel GetUnReadMessage(GetAppMessageQueryModel query);

        bool SetRead(int sendId);
    }
}
