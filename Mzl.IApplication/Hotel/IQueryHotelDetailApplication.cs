using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Hotel.Elong.HotelInfo;

namespace Mzl.IApplication.Hotel
{
    /// <summary>
    /// 查询酒店详情信息
    /// </summary>
    public interface IQueryHotelDetailApplication : IBaseApplication
    {
        QueryHotelDetailResponseViewModel QueryHotelDetail(QueryHotelDetailRequestViewModel request);
    }
}
