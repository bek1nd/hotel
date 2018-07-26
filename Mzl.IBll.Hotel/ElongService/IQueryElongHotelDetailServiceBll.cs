using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Hotel.Elong.HotelInfo;
using Mzl.Framework.Base;

namespace Mzl.IBll.Hotel.ElongService
{
    public interface IQueryElongHotelDetailServiceBll : IBaseServiceBll
    {
        QueryHotelDetailResponseModel QueryHotelDetail(QueryHotelDetailRequestModel query);
    }
}
