using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Tran.Server
{
    /// <summary>
    /// 火车票占位接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHoldSeatServer<in T> where T : class
    {
        /// <summary>
        /// 记录占位回调信息
        /// </summary>
        /// <param name="t"></param>
        bool WriteHoldSeatLog(T t);
    }
}
