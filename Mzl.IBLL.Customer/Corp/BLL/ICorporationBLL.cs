namespace Mzl.IBLL.Customer.Corp.BLL
{
    public interface ICorporationBLL<T> where T : class
    {
        T GetCorpInfoByCorpId(string corpId);
    }
}
