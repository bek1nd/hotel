namespace Mzl.IApplication.Base
{
    public interface IBaseDomainFactory<out T> where T : class
    {
        T CreateDomainObj();
    }
}
