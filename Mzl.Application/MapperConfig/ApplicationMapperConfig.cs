using AutoMapper;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Common.Insurance;
using Mzl.DomainModel.Common.TravelManage;
using Mzl.DomainModel.Customer.AppOpinion;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.DomainModel.Customer.Identification;
using Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit;
using Mzl.DomainModel.Customer.Passenger;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.DomainModel.Customer.TravelReport;
using Mzl.DomainModel.Flight;
using Mzl.DomainModel.Flight.CopyOrder;
using Mzl.DomainModel.Hotel.CopyOrder;
using Mzl.DomainModel.Hotel.CTrip.City;
using Mzl.DomainModel.Hotel.Elong.City;
using Mzl.DomainModel.Hotel.Elong.HotelInfo;
using Mzl.DomainModel.Hotel.Order;
using Mzl.DomainModel.Register;
using Mzl.DomainModel.Train.GrabTicket;
using Mzl.DomainModel.Train.Order;
using Mzl.DomainModel.Train.Order.CopyOrder;
using Mzl.DomainModel.Train.Order.OrderDetail;
using Mzl.DomainModel.Train.Server;
using Mzl.Framework.Base;
using Mzl.UIModel.Common.AuditOrder;
using Mzl.UIModel.Common.Insurance;
using Mzl.UIModel.Common.TravelManage;
using Mzl.UIModel.Customer.AppMessage;
using Mzl.UIModel.Customer.AppOpinion;
using Mzl.UIModel.Customer.CorpAduit;
using Mzl.UIModel.Customer.Corporation;
using Mzl.UIModel.Customer.CorpPolicy;
using Mzl.UIModel.Customer.Customer;
using Mzl.UIModel.Customer.Identification;
using Mzl.UIModel.Customer.MatchCorpPolicyAndAduit;
using Mzl.UIModel.Customer.TravelReport;
using Mzl.UIModel.Flight;
using Mzl.UIModel.Flight.CopyOrder;
using Mzl.UIModel.Hotel.CopyOrder;
using Mzl.UIModel.Hotel.Elong.City;
using Mzl.UIModel.Hotel.Elong.HotelInfo;
using Mzl.UIModel.Hotel.GetOrderInfo;
using Mzl.UIModel.Passenger;
using Mzl.UIModel.Register;
using Mzl.UIModel.Search;
using Mzl.UIModel.Train.GrabTicket;
using Mzl.UIModel.Train.Order;
using Mzl.UIModel.Train.Order.CopyOrder;
using Mzl.UIModel.Train.Order.OrderDetail;
using Mzl.UIModel.Train.Search;

namespace Mzl.Application.MapperConfig
{
    /// <summary>
    /// 应用层Mapper映射关系配置
    /// </summary>
    public class ApplicationMapperConfig : IMapperConfig
    {
        public void InitializeConfig(IMapperConfigurationExpression cfg)
        {
            #region 报表视图
            cfg.CreateMap<TravelReportRequestUIModel, TravelReportRequestDoModel>();

            cfg.CreateMap<TravelReportAirlineCountModel, TravelReportAirlineCountViewModel>();
            cfg.CreateMap<TravelReportCostCenterModel, TravelReportCostCenterViewModel>();
            cfg.CreateMap<TravelReportReserveDayModel, TravelReportReserveDayViewModel>();
            cfg.CreateMap<TravelReportSalePriceModel, TravelReportSalePriceViewModel>();
            cfg.CreateMap<TravelReportAllSalePriceModel, TravelReportAllSalePriceViewModel>();
            cfg.CreateMap<TravelReportDportCityModel, TravelReportDportCityViewModel>();
            cfg.CreateMap<TravelReportPassengerTopModel, TravelReportPassengerTopViewModel>();
            cfg.CreateMap<TravelReportConsumeCountModel, TravelReportConsumeCountViewModel>();
            cfg.CreateMap<TravelReportYearPriceCountModel, TravelReportYearPriceCountViewModel>();
            cfg.CreateMap<TravelReportCountDataModel, TravelReportCountDataViewModel>();
            cfg.CreateMap<TravelReportFltRefundFltModModel, TravelReportFltRefundFltModViewModel>();
            cfg.CreateMap<TravelReportAirConsumeCountTableModel, TravelReportAirConsumeCountTableViewModel>();
            #endregion
            #region 客户基础数据
            //证件信息
            cfg.CreateMap<IdentificationViewModel, IdentificationModel>();
            #endregion

            #region 机票

            cfg.CreateMap<InsuranceCompanyModel, InsuranceCompanyViewModel>().ReverseMap();
            cfg.CreateMap<AuditOrderListModel, GetAuditOrderListResponseViewModel>();
            cfg.CreateMap<AuditOrderListDataModel, GetAuditOrderDataListViewModel>();
            cfg.CreateMap<AuditOrderDetailModel, AuditOrderDetailViewModel>();

            cfg.CreateMap<TravelRequestViewModel, TravelQueryModel>();
            cfg.CreateMap<TravelModel, TravelResponseViewModel>();
            cfg.CreateMap<TravelDataModel, TravelDataViewModel>();
            cfg.CreateMap<AddModApplyRequestViewModel, AddRetModApplyModel>();
            cfg.CreateMap<AddModApplyDetailViewModel, FltRetModFlightApplyModel>();
            cfg.CreateMap<AddRetApplyRequestViewModel, AddRetModApplyModel>();
            cfg.CreateMap<AddRetApplyDetailViewModel, FltRetModFlightApplyModel>();
            cfg.CreateMap<AddOrderRequestViewModel, AddOrderModel>();
            cfg.CreateMap<AddFltFlightViewModel, FltFlightModel>();
            cfg.CreateMap<AddFltPassengerViewModel, FltPassengerModel>();
            cfg.CreateMap<PassengerInfoModel, PassengerViewModel>();
            cfg.CreateMap<IdentificationModel, IdentificationViewModel>();
            cfg.CreateMap<ProjectNameModel, ProjectNameViewModel>();
            cfg.CreateMap<ProjectNameModel, CorpPolicyProjectViewModel>();
            cfg.CreateMap<CostCenterModel, CostCenterViewModel>();
            cfg.CreateMap<GetModApplyRequestViewModel, GetModApplyQueryModel>();
            cfg.CreateMap<GetModApplyModel, GetModApplyResponseViewModel>();
            cfg.CreateMap<FltFlightModel, GetModApplyFlightViewModel>();
            cfg.CreateMap<FltPassengerModel, GetModApplyPassengerViewModel>();
            cfg.CreateMap<GetRetApplyRequestViewModel, GetRetApplyQueryModel>();
            cfg.CreateMap<GetRetApplyModel, GetRetApplyResponseViewModel>();
            cfg.CreateMap<FltFlightModel, GetRetApplyFlightViewModel>();
            cfg.CreateMap<FltPassengerModel, GetRetApplyPassengerViewModel>();
            cfg.CreateMap<GetNotUseTicketNoQueryViewModel, GetNotUseTicketNoQueryModel>();
            cfg.CreateMap<GetNotUseTicketNoModel, GetNotUseTicketNoViewModel>();
            cfg.CreateMap<GetNotUseTicketNoDataModel, GetNotUseTicketNoDataViewModel>();
            cfg.CreateMap<QueryFltOrderRequestViewModel, QueryFlightOrderQueryModel>();
            cfg.CreateMap<QueryFlightOrderDataModel, QueryFltOrderResponseViewModel>();
            cfg.CreateMap<FltFlightModel, FltFlightViewModel>();
            cfg.CreateMap<FltPassengerModel, FltPassengerViewModel>();
            cfg.CreateMap<FltModOrderModel, FltModOrderViewModel>();
            cfg.CreateMap<FltModFlightModel, FltModFlightViewModel>();
            cfg.CreateMap<FltModPassengerModel, FltModPassengerViewModel>();
            cfg.CreateMap<FltRefundOrderModel, FltRefundOrderViewModel>();
            cfg.CreateMap<FltRefundDetailOrderModel, FltRefundDetailOrderViewModel>();
            cfg.CreateMap<QueryFltOrderListRequestViewModel, QueryFlightOrderListDataQueryModel>();
            cfg.CreateMap<QueryFlightOrderListModel, QueryFltOrderListResponseViewModel>();
            cfg.CreateMap<QueryFlightOrderListDataModel, FltOrderListDataViewModel>();
            cfg.CreateMap<QueryFltRetModApplyRequestViewModel, QueryFlightModApplyQueryModel>();
            cfg.CreateMap<QueryFlightModApplyDataModel, QueryFlightModApplyResponseViewModel>();
            cfg.CreateMap<GetModRetApplyAuditModel, GetModRetApplyAuditViewModel>();
            cfg.CreateMap<QueryFltModApplyListRequestViewModel, QueryFlightModApplyListDataQueryModel>();
            cfg.CreateMap<QueryFlightModApplyListModel, QueryFltModApplyListResponseViewModel>();
            cfg.CreateMap<QueryFlightModApplyListDataModel, FltModApplyListDataViewModel>();
            cfg.CreateMap<QueryFltRetModApplyRequestViewModel, QueryFlightRetApplyQueryModel>();
            cfg.CreateMap<QueryFlightRetApplyModel, QueryFlightRetApplyResponseViewModel>();
            cfg.CreateMap<FltRetFlightModel, QueryRetApplyFlightViewModel>();
            cfg.CreateMap<FltPassengerModel, QueryRetApplyPassengerViewModel>();
            cfg.CreateMap<QueryFltRetApplyListRequestViewModel, QueryFlightRetApplyListDataQueryModel>();
            cfg.CreateMap<QueryFlightRetApplyListModel, QueryFltRetApplyListResponseViewModel>();
            cfg.CreateMap<QueryFlightRetApplyListDataModel, FltRetApplyListDataViewModel>();
            cfg.CreateMap<FltFlightModel, FltFlightListViewModel>();
            cfg.CreateMap<FltPassengerModel, FltPassengerListViewModel>();
            cfg.CreateMap<SearchCityAportModel, SearchCityAirportResponseViewModel>();
            cfg.CreateMap<SearchCountryModel, CountryViewModel>();
            cfg.CreateMap<SearchCityModel, CityViewModel>();
            cfg.CreateMap<SearchAirportModel, AirportViewModel>();
            cfg.CreateMap<SearchFlightModel, SearchFlightViewModel>();
            cfg.CreateMap<SearchFlightModel, SearchModFlightViewModel>();
            cfg.CreateMap<SearchFlightDetailModel, SearchFlightDetailViewModel>();

            #endregion

            cfg.CreateMap<AddTraOrderRequestViewModel, TraAddOrderModel>();
            cfg.CreateMap<IdentificationModel, IdentificationViewModel>();
            cfg.CreateMap<CostCenterModel, CostCenterViewModel>();
            cfg.CreateMap<ProjectNameModel, ProjectNameViewModel>();
            cfg.CreateMap<TraOrderListDataModel, TraOrderListDataViewModel>();
            cfg.CreateMap<TraOrderModel, TraOrderViewModel>().ReverseMap();
            cfg.CreateMap<TraOrderDetailViewModel, TraOrderDetailModel>();
            cfg.CreateMap<TraPassengerModel, TraPassengerViewModel>().ReverseMap();
            cfg.CreateMap<ChooseSeatViewModel, ChooseSeatModel>();
            cfg.CreateMap<CustomerInfoModel, CustomerInfoViewModel>();
            cfg.CreateMap<CorpDepartmentModel, CorpDepartmentViewModel>();
            cfg.CreateMap<CorpDepartmentModel, CorpPolicyDepartmentViewModel>();
            cfg.CreateMap<CorpPolicyCustomerModel, CorpPolicyCustomerViewModel>();
            cfg.CreateMap<TraOrderListDataModel, TraRetOrderListDataViewModel>();
            cfg.CreateMap<TraModOrderListDataModel, TraModOrderListDataViewModel>();
            cfg.CreateMap<TraModOrderModel, TraModOrderViewModel>();
            cfg.CreateMap<TraTravelInfoDetailModel, TraTravelInfoDetailViewModel>();
            cfg.CreateMap<TraOrderSubmitPassengerViewModel, TraOrderSubmitPassengerModel>();

            cfg.CreateMap<CancelFltModApplyRequestViewModel, CancelFltRetModApplyModel>();
            cfg.CreateMap<CancelFltRetApplyRequestViewModel, CancelFltRetModApplyModel>();

            cfg.CreateMap<GetUnAvailablePassengerRequestViewModel, GetUnAvailablePassengerQueryModel>().ReverseMap();
            cfg.CreateMap<GetUnAvailablePassengerModel, GetUnAvailablePassengerListResponseViewModel>().ReverseMap();
            cfg.CreateMap<GetUnAvailablePassengerDataModel, GetUnAvailablePassengerDataViewModel>().ReverseMap();
            cfg.CreateMap<GetUnAvailablePassengerViewModel, FltPassengerModel>().ReverseMap();

            #region 火车抢票

            cfg.CreateMap<AddGrabTicketRequestViewModel, AddTraGrabTicketModel>().ReverseMap();
            cfg.CreateMap<AddGrabTicketPassengerViewModel, TraGrabTicketPassengerModel>().ReverseMap();
            cfg.CreateMap<TraGrabTicketListModel, TraGrabTicketListResponseViewModel>();
            cfg.CreateMap<TraGrabTicketListDataModel, TraGrabTicketListDataViewModel>();
            cfg.CreateMap<TraGrabTicketPassengerModel, TraGrabTicketListDataPassengerViewModel>();
            cfg.CreateMap<TraGrabTicketListRequestViewModel, TraGrabTicketListQueryModel>();

            #endregion


            cfg.CreateMap<RegisterViewModel, RegisterCustomerModel>();
            cfg.CreateMap<CorpAduitConfigModel, CorpAduitConfigListViewModel>();
            cfg.CreateMap<CorpAduitConfigModel, CorpAduitConfigViewModel>();
            cfg.CreateMap<AddCorpAduitConfigRequestViewModel, CorpAduitConfigModel>();
            cfg.CreateMap<UpdateCorpAduitConfigRequestViewModel, CorpAduitConfigModel>();
            cfg.CreateMap<CorpAduitConfigDetailViewModel, CorpAduitConfigDetailModel>().ReverseMap();

            cfg.CreateMap<CorpAduitCustomerModel, CorpAduitCustomerViewModel>();

            cfg.CreateMap<CustomerModel, GetCustomerInfoResponseViewModel>();

            cfg.CreateMap<AddContactRequestViewModel, AddContactModel>();
            cfg.CreateMap<EditContactRequestViewModel, EditContactModel>();

            cfg.CreateMap<MatchCorpPolicyAndAduitResultModel, MatchCorpPolicyAndAduitResponseViewModel>();
            cfg.CreateMap<CorpPolicyAndAduitChangeProjectModel, CorpPolicyAndAduitChangeProjectViewModel>();
            cfg.CreateMap<CorpPolicyAndAduitChangeModel, CorpPolicyAndAduitChangeViewModel>();
            cfg.CreateMap<CorpPolicyChangeModel, CorpPolicyChangeViewModel>();
            cfg.CreateMap<CorpAduitChangeModel, CorpAduitChangeViewModel>();

            cfg.CreateMap<CorpAduitOrderInfoModel, GetAduitOrderResponseViewModel>();
            cfg.CreateMap<CorpAduitOrderDetailModel, CorpAduitOrderDetailViewModel>();
            cfg.CreateMap<CorpAduitOrderFlowModel, CorpAduitOrderFlowViewModel>();
            cfg.CreateMap<CorpAduitOrderLogModel, CorpAduitOrderLogViewModel>();

            #region 酒店

            cfg.CreateMap<HotelCountryModel, HotelCountryViewModel>();
            cfg.CreateMap<HotelCityModel, HotelCityViewModel>();
            cfg.CreateMap<HotelDistrictModel, HotelDistrictViewModel>();
            cfg.CreateMap<HolelCommericalLocationModel, HolelCommericalLocationViewModel>();
            cfg.CreateMap<HotelLandmarkLocationModel, HotelLandmarkLocationViewModel>();



            cfg.CreateMap<QueryHotelInfoRequestViewModel, QueryHotelInfoRequestModel>();
            cfg.CreateMap<QueryHotelInfoResponseModel, QueryHotelInfoResponseViewModel>();
            cfg.CreateMap<QueryHotelDetailRequestViewModel, QueryHotelDetailRequestModel>();
            cfg.CreateMap<QueryHotelDetailResponseModel, QueryHotelDetailResponseViewModel>();
            cfg.CreateMap<HotelInfoResultModel, HotelInfoResultViewModel>();
            cfg.CreateMap<HotelBookingRuleModel, HotelBookingRuleViewModel>();
            cfg.CreateMap<HotelGuaranteeRuleModel, HotelGuaranteeRuleViewModel>();
            cfg.CreateMap<HotelPrepayRuleModel, HotelPrepayRuleViewModel>();
            cfg.CreateMap<HotelValueAddModel, HotelValueAddViewModel>();
            cfg.CreateMap<HotelDrrRuleModel, HotelDrrRuleViewModel>();
            cfg.CreateMap<HotelRoomsModel, HotelRoomsViewModel>();
            cfg.CreateMap<HotelRatePlanModel, HotelRatePlanViewModel>();
            cfg.CreateMap<HotelNightlyRatesModel, HotelNightlyRatesViewModel>();
            cfg.CreateMap<HotelDetailModel, HotelDetailViewModel>();
            cfg.CreateMap<HotelReviewModel, HotelReviewViewModel>();
            cfg.CreateMap<HotelHAvailPolicyModel, HotelHAvailPolicyViewModel>();

            cfg.CreateMap<Country, Mzl.UIModel.Hotel.CTrip.City.CountryViewModel>();

            #endregion

            cfg.CreateMap<GetTraOrderDetailInfoModel, GetTraOrderDetailResponseViewModel>();
            cfg.CreateMap<GetTraOrderModel, GetTraOrderViewModel>();
            cfg.CreateMap<GetTraModOrderModel, GetTraModOrderViewModel>();
            cfg.CreateMap<GetTraOrderTravelModel, GetTraOrderTravelViewModel>();
            cfg.CreateMap<GetTraOrderPassengerModel, GetTraOrderPassengerViewModel>();


            cfg.CreateMap<ContactInfoModel, ContactViewModel>();


            cfg.CreateMap<CopyFltDomesticOrderRequestViewModel, CopyFltOrderModel>();
            cfg.CreateMap<CopyFltFlightViewModel, CopyFltFlightModel>();

            cfg.CreateMap<CopyTraOrderRequestViewModel, CopyTraOrderModel>();
            cfg.CreateMap<CopyTraPassengerViewModel, CopyTraPassengerModel>();

            cfg.CreateMap<CopyHotelOrderRequestViewModel, CopyHotelOrderModel>();
            cfg.CreateMap<CopyHotelOrderDetailViewModel, CopyHotelOrderDetailModel>();


            cfg.CreateMap<HotelOrderInfoModel, GetHotelOrderInfoResponseViewModel>();
            cfg.CreateMap<HotelOrderDetailModel, HotelOrderDetailViewModel>();


            cfg.CreateMap<GetAppMessageResultModel, GetAppMessageResponseViewModel>();
            cfg.CreateMap<SendAppMessageModel, AppMessageViewModel>();

            cfg.CreateMap<CorpBookingDepartModel, CorpBookingDepartViewModel>();

            cfg.CreateMap<AppOpinionDomainModelList, GetAppOpinionListResponseViewModel>();
            cfg.CreateMap<AppOpinionDomainModel, AppOpinionViewModel>();

            #region 携程接口
            cfg.CreateMap<DomainModel.Hotel.CTrip.City.Country, UIModel.Hotel.CTrip.City.CountryViewModel>();
            cfg.CreateMap<DomainModel.Hotel.CTrip.City.Province, UIModel.Hotel.CTrip.City.ProvinceViewModel>();
            cfg.CreateMap<DomainModel.Hotel.CTrip.City.City, UIModel.Hotel.CTrip.City.CityViewModel>();
            #endregion

        }
    }
}
