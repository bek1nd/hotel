using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.CorpAduit
{
    public interface ICheckAduitOrderServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 根据客户Id和订单号，判断当前客户Id是否是订单的审批人
        /// </summary>
        /// <returns></returns>
        bool CheckAduitCidHasOrderId(int cid,int orderId);
    }
}
