using Mzl.DomainModel.Hotel.Elong.HotelInfo;
using Mzl.Framework.Base;

namespace Mzl.IBll.Hotel.ElongService
{
    /// <summary>
    /// 查询艺龙酒店列表服务
    /// </summary>
    public interface IQueryElongHotelListService : IBaseServiceBll
    {
        QueryHotelInfoResponseModel QueryHotelList(QueryHotelInfoRequestModel query);
    }
}
