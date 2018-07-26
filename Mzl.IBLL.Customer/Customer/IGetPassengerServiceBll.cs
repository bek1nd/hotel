using Mzl.DomainModel.Customer.Passenger;
using System.Collections.Generic;

namespace Mzl.IBLL.Customer.Customer
{
    /// <summary>
    /// 获取乘车人信息服务
    /// </summary>
    public interface IGetPassengerServiceBll
    {
        /// <summary>
        /// 获取所有的待预定乘客信息(包含常客和临客)
        /// </summary>
        /// <param name="cid">当前查询的客户Id</param>
        /// <param name="searchArgs">查询内容</param>
        /// <param name="isTemporary">是否临时乘客</param>
        /// <param name="isOnline">是否线上查询</param>
        /// <returns></returns>
        List<PassengerInfoModel> GetPassenger(int cid, bool isTemporary, string searchArgs = "", int isOnline = 0);
    }
}
