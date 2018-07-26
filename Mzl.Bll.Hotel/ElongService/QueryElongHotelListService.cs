using System;
using AutoMapper;
using Mzl.DomainModel.Hotel.Elong.HotelInfo;
using Mzl.EntityModel.Hotel.Elong;
using Mzl.Framework.Base;
using Mzl.IBll.Hotel.ElongService;
using Mzl.Proxy.Hotel.Elong.Query;
using Newtonsoft.Json;

namespace Mzl.Bll.Hotel.ElongService
{
    public class QueryElongHotelListService : BaseServiceBll, IQueryElongHotelListService
    {
        private readonly IHotelListService _hotelListService;

        public QueryElongHotelListService(IHotelListService hotelListService)
        {
            _hotelListService = hotelListService;
        }
        /// <summary>
        /// 查询艺龙酒店列表
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public QueryHotelInfoResponseModel QueryHotelList(QueryHotelInfoRequestModel query)
        {
            HotelListRequestEntity requestElong =
              Mapper.Map<QueryHotelInfoRequestModel, HotelListRequestEntity>(query);
            string responseElong = _hotelListService.QueryStr(requestElong);
            BaseHotelResponseModel<QueryHotelInfoResponseModel> responseModel =
                JsonConvert.DeserializeObject<BaseHotelResponseModel<QueryHotelInfoResponseModel>>(responseElong);
            if (responseModel.Code != "0")
                throw new Exception("api异常，请稍后再试");
            return responseModel.Result;

            //HotelListResponseEntity responseElong = _hotelListService.Query(requestElong);
            //return Mapper.Map<HotelListResponseEntity, QueryHotelInfoResponseModel>(responseElong);
        }
    }
}
