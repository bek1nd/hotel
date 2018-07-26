using System.Collections.Generic;
using Mzl.DomainModel.Hotel.Elong.City;
using Mzl.Framework.Base;

namespace Mzl.IBll.Hotel.ElongService
{
    /// <summary>
    /// 查询酒店城市服务
    /// </summary>
    public interface IQueryElongHotelCityServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 查询酒店城市信息
        /// </summary>
        /// <returns></returns>
        List<HotelCountryModel> QueryHotelCity(int queryCityType);

    }
}
