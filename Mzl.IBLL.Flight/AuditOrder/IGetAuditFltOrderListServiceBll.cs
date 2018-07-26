using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Flight.AuditOrder
{
    public interface IGetAuditFltOrderListServiceBll : IBaseServiceBll
    {
        AuditOrderListModel GetAuditFltOrderList(AuditFltOrderListQueryModel query);
    }
}
