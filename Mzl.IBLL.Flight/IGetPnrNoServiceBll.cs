using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Flight
{
    /// <summary>
    /// 定位服务
    /// </summary>
    public interface IGetPnrNoServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 定位
        /// </summary>
        /// <returns></returns>
        string GetPnrNo(int orderid,string email);
    }
}
