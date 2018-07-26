using Mzl.Framework.Base;
using Mzl.UIModel.Common.AuditOrder;

namespace Mzl.IApplication.Common
{
    public interface IGetAuditOrderListApplication : IBaseApplication
    {
        GetAuditOrderListResponseViewModel GetAuditOrderList(GetAuditOrderListRequestViewModel request);
    }
}
