using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Common.TravelManage;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IApplication.Common;
using Mzl.IBLL.Common.BaseInfo;
using Mzl.IBLL.Common.TravelManage;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.UIModel.Common.TravelManage;
using Mzl.UIModel.Flight;

namespace Mzl.Application.Common
{
    internal class GetTravelListApplication: BaseApplicationService,IGetTravelListApplication
    {
        private readonly IGetTravelServiceBll _getTravelServiceBll;
        private readonly IGetCityForFlightServiceBll _getCityForFlightServiceBll;
        private readonly IGetContactBll _getContactBll;

        public GetTravelListApplication(IGetTravelServiceBll getTravelServiceBll,
            IGetCityForFlightServiceBll getCityForFlightServiceBll, IGetContactBll getContactBll)
        {
            _getTravelServiceBll = getTravelServiceBll;
            _getCityForFlightServiceBll = getCityForFlightServiceBll;
            _getContactBll = getContactBll;
        }

        public TravelResponseViewModel GetTravel(TravelRequestViewModel request)
        {

            ContactInfoModel  contactInfoModel= _getContactBll.GetCorpContactByCid(request.Cid);
            if(contactInfoModel==null)
                throw new Exception("无法查询到对应的联系人信息");
            //1.查询机场信息
            SearchCityAportModel aportModel = _getCityForFlightServiceBll.SearchAirport(new List<string>() { "N" });
            TravelQueryModel query = Mapper.Map<TravelRequestViewModel, TravelQueryModel>(request);
            query.AportInfo = aportModel;
            query.ContactId = contactInfoModel.ContactId;

            TravelModel travelModel = _getTravelServiceBll.GetTravelList(query);

            TravelResponseViewModel viewModel = Mapper.Map<TravelModel, TravelResponseViewModel>(travelModel);
            return viewModel;
        }
    }
}
