using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Hotel.Elong.HotelInfo;
using Mzl.EntityModel.Hotel.Elong;
using Mzl.Framework.Base;
using Mzl.IBll.Hotel.ElongService;
using Mzl.Proxy.Hotel.Elong.Query;
using Newtonsoft.Json;

namespace Mzl.Bll.Hotel.ElongService
{
    public class QueryElongHotelDetailServiceBll : BaseServiceBll, IQueryElongHotelDetailServiceBll
    {
        private readonly IHotelDetail _hotelDetail;

        public QueryElongHotelDetailServiceBll(IHotelDetail hotelDetail)
        {
            _hotelDetail = hotelDetail;
        }

        public QueryHotelDetailResponseModel QueryHotelDetail(QueryHotelDetailRequestModel query)
        {
            HotelDetailRequestEntity requestElong =
                Mapper.Map<QueryHotelDetailRequestModel, HotelDetailRequestEntity>(query);
            string responseElong = _hotelDetail.QueryStr(requestElong);
            BaseHotelResponseModel<QueryHotelDetailResponseModel> responseModel =
            JsonConvert.DeserializeObject<BaseHotelResponseModel<QueryHotelDetailResponseModel>>(responseElong);
            if (responseModel.Code != "0")
                throw new Exception("api异常，请稍后再试");
            return responseModel.Result;
        }
    }
}
