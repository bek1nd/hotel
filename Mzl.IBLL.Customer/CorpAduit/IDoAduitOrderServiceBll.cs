using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.Framework.Base;
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.IBLL.Customer.CorpAduit
{
    /// <summary>
    /// 审批服务
    /// </summary>
    public interface IDoAduitOrderServiceBll : IBaseServiceBll
    {
        DoAduitOrderResultModel DoAduitOrder(DoAduitOrderModel doAduit);
        BaseDealAduitResultDetailModel GetCorpAduitOrderDetailmail(DoAduitOrderRequestViewModel aduitOrderId);
    }
}
