using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.CorpAduit.SubmitCorpAduitOrder
{
    /// <summary>
    /// 送审
    /// </summary>
    public interface ISubmitCorpAduitOrderServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 送审
        /// </summary>
        /// <param name="submitModel"></param>
        /// <returns></returns>
        bool Submit(SubmitCorpAduitOrderModel submitModel);
        /// <summary>
        /// 是否送审
        /// </summary>
        bool IsSendAduit { get; }
    }
}
