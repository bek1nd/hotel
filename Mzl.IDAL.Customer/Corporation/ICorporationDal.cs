using Mzl.Framework.Base;

namespace Mzl.IDAL.Customer.Corporation
{
    public interface ICorporationDal : IBaseDal
    {
        T Find<T>(string id) where T : class;
    }
}
