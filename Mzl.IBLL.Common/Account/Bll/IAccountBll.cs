using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Common.Account.Bll
{
    public interface IAccountBll<T> where T : class
    {
        /// <summary>
        /// 获取帐号信息
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        T GetAccountInfo(int aid);
        /// <summary>
        /// 更新帐号信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int UpdateAccount(T t);
    }
}
