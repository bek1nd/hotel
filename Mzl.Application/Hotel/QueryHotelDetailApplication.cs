using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Hotel.Elong.HotelInfo;
using Mzl.Framework.Base;
using Mzl.IApplication.Hotel;
using Mzl.IBll.Hotel.ElongService;
using Mzl.UIModel.Hotel.Elong.HotelInfo;

namespace Mzl.Application.Hotel
{
    public class QueryHotelDetailApplication : BaseApplicationService, IQueryHotelDetailApplication
    {
        private readonly IQueryElongHotelDetailServiceBll _queryElongHotelDetailServiceBll;
        public QueryHotelDetailApplication(IQueryElongHotelDetailServiceBll queryElongHotelDetailServiceBll)
        {
            _queryElongHotelDetailServiceBll = queryElongHotelDetailServiceBll;
        }

        public QueryHotelDetailResponseViewModel QueryHotelDetail(QueryHotelDetailRequestViewModel request)
        {
            QueryHotelDetailRequestModel requestModel =
                Mapper.Map<QueryHotelDetailRequestViewModel, QueryHotelDetailRequestModel>(request);
            QueryHotelDetailResponseModel responseModel = _queryElongHotelDetailServiceBll.QueryHotelDetail(requestModel);
            return Mapper.Map<QueryHotelDetailResponseModel, QueryHotelDetailResponseViewModel>(responseModel);
        }
    }
}
