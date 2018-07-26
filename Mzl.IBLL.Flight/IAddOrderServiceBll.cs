using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Flight
{
    public interface IAddOrderServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 添加国内机票订单
        /// </summary>
        /// <param name="fltAddOrderModel"></param>
        /// <returns></returns>
        int AddDomesticOrder(AddOrderModel fltAddOrderModel);
    }
}
