using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.BaseMaintenance.Bll
{
    public interface ITra12306AccountBll<T> where T : class
    {
        /// <summary>
        /// 获取12306帐号信息
        /// </summary>
        /// <returns></returns>
        List<T> GetTra12306AccountList();
    }
}
