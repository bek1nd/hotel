using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight.CopyOrder;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Flight.CopyOrder
{
    public interface ICopyFltDomesticOrderServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 复制订单
        /// </summary>
        /// <returns></returns>
        int CopyOrder(CopyFltOrderModel copyFltOrderModel);
    }
}
