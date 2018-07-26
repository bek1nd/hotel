using Mzl.DomainModel.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Flight
{
    public interface IAddOrderBll
    {
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="fltAddOrderModel"></param>
        /// <returns></returns>
        int AddOrder(AddOrderModel fltAddOrderModel);
    }
}
