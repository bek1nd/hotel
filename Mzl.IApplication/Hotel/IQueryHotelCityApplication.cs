using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Hotel.Elong.City;

namespace Mzl.IApplication.Hotel
{
    /// <summary>
    /// 查询酒店城市
    /// </summary>
    public interface IQueryHotelCityApplication : IBaseApplication
    {
        /// <summary>
        /// 查询酒店城市
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        QueryHotelCityResponseViewModel QueryHotelCity(QueryHotelCityRequestViewModel request);
    }
}
