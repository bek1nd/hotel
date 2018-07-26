using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Flight
{
    public interface ICancelFltOrderServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 取消线上差旅订单
        /// </summary>
        /// <returns></returns>
        int CancelOnlineCorpOrder(int orderId,int cid,string remark);
    }
}
