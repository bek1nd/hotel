using System.Collections.Generic;

namespace Mzl.IBLL.Customer.CostCenter.BLL
{
    public interface ICostCenterBLL<T> where T : class
    {
        List<T> GetCostCenterListByCorpId(string corpId);
    }
}
