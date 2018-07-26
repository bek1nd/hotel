using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Login;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.Customer
{
    /// <summary>
    /// 新增App端的设备ID,并和客户Id绑定关系
    /// </summary>
    public interface IAddAppClientIdServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 新增App端的设备ID,并和客户Id绑定关系
        /// </summary>
        /// <returns></returns>
        int AddAppClientId(AddAppClientIdModel query);

        /// <summary>
        /// 获取设备ID
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        string GetAppClientId(int cid);
    }
}
