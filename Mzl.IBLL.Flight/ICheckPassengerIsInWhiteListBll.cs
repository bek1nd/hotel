using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;

namespace Mzl.IBLL.Flight
{
    public interface ICheckPassengerIsInWhiteListBll
    {
        string Result { get; }
        /// <summary>
        /// 判断是否存在白名单内
        /// </summary>
        /// <param name="passengerList"></param>
        /// <param name="isCheckName"></param>
        /// <returns>True 是 False 否</returns>
        bool CheckPassenger(List<FltPassengerModel> passengerList, bool isCheckName);
        /// <summary>
        /// 通过人名判断
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        bool CheckPassengerName(string name);
        /// <summary>
        /// 通过证件判断
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        bool CheckPassengerCardNo(string cardNo);
    }
}
