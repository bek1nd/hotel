using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Common.Account.Bll
{
    public interface IAccountDetailBll<T> where T : class
    {
        /// <summary>
        /// 添加帐号支付明细
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int AddAccountDetail(T t);
    }
}
