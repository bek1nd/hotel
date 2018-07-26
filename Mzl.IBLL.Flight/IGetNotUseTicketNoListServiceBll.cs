using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Flight
{
    public interface IGetNotUseTicketNoListServiceBll: IBaseServiceBll
    {
        /// <summary>
        /// 获取国内未使用机票信息
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        GetNotUseTicketNoModel GetNotUseNationTicketNoList(GetNotUseTicketNoQueryModel query);
    }
}
