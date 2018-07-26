using Mzl.Framework.Base;
using Mzl.IApplication.CTripHotel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;
using Mzl.UIModel.Hotel.CTripHotel.HotelQuery;
using Mzl.DomainModel.Hotel.CTrip.Hotel;
using Mzl.IBll.Hotel.CtripHotel.SolrService;

namespace Mzl.Application.CTripHotel
{
    public class CTripHotelInfoApplication : BaseApplicationService, ICTripHotelInfoApplication
    {
        private IHotelInfoService _hotleInfoService { get; set; }
        private CTripHotelInfoApplication(IHotelInfoService hotelInfoService)
        {
            _hotleInfoService = hotelInfoService;
        }
        public HotelStaticInfoDomainModel Query(CTripHotelInfoReqViewModel req)
        {
            return _hotleInfoService.QueryById(req.Id,"testsolr2");
        }

        public List<CTripHotelSimpleResViewModel> QuerySimpleHotelList(CTripHotelSimpleReqViewModel req)
        {
            throw new NotImplementedException();
        }
    }
}
