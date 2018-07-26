using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Train.Server.BLL
{
    /// <summary>
    /// 火车票退票接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRefundTicketServerBLL<in T> : IBaseServerBLL where T : class
    {
        /// <summary>
        /// 保存占位回调信息
        /// </summary>
        /// <param name="t"></param>
        bool SaveRefundTicketLog(T t);

        /// <summary>
        /// 获取占位信息
        /// </summary>
        /// <returns></returns>
        string ReceiveRefundTicketInof();
    
    }
}
