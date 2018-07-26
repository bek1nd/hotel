using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpAduit;

namespace Mzl.IBLL.Customer.CorpAduit
{
    public interface ICorpAduitBll
    {
        /// <summary>
        /// 提交审批单
        /// </summary>
        /// <returns></returns>
        int SubmitAduit(SubmitAduitModel model);
        /// <summary>
        /// 送审
        /// </summary>
        /// <returns></returns>
        BaseDealAduitResultModel DeliveAduit(DeliveAduitModel model);
        /// <summary>
        /// 审批
        /// </summary>
        /// <returns></returns>
        BaseDealAduitResultModel DoAduit(BaseDealAduitModel model);
        ///
        ///查询
        ///
        List<BaseDealAduitResultDetailModel> GetCorpAduitOrderDetail(int aduitOrderId);
    }
}
