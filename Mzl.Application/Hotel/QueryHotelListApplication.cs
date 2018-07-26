using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Hotel.Elong.HotelInfo;
using Mzl.Framework.Base;
using Mzl.IApplication.Hotel;
using Mzl.IBll.Hotel;
using Mzl.IBll.Hotel.ElongService;
using Mzl.UIModel.Hotel.Elong.HotelInfo;

namespace Mzl.Application.Hotel
{
    internal class QueryHotelListApplication : BaseApplicationService, IQueryHotelListApplication
    {
        private readonly IQueryElongHotelListService _queryElongHotelListService;

        public QueryHotelListApplication(IQueryElongHotelListService queryElongHotelListService)
        {
            _queryElongHotelListService = queryElongHotelListService;
        }

        public QueryHotelInfoResponseViewModel QueryHotelList(QueryHotelInfoRequestViewModel query)
        {
            QueryHotelInfoRequestModel requestModel =
                Mapper.Map<QueryHotelInfoRequestViewModel, QueryHotelInfoRequestModel>(query);
            QueryHotelInfoResponseModel responseModel= _queryElongHotelListService.QueryHotelList(requestModel);
            return Mapper.Map<QueryHotelInfoResponseModel, QueryHotelInfoResponseViewModel>(responseModel);
        }
    }

    
}
