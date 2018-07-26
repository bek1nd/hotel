using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Tran.Server
{
    /// <summary>
    /// 查询火车票接口
    /// </summary>
    public interface IQueryTicketServer<out T> : IServer where T : class
    {
        T Query();
    }
}
