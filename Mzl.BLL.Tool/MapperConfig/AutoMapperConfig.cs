using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using AutoMapper;
using Mzl.DomainModel.Common.Account;
using Mzl.DomainModel.Common.Insurance;
using Mzl.DomainModel.Common.Operator;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Customer.Corp;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.DomainModel.Customer.Identification;
using Mzl.DomainModel.Customer.Login;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.DomainModel.Customer.ServiceFee;
using Mzl.DomainModel.Train.BaseMaintenance;
using Mzl.DomainModel.Train.Order;
using Mzl.DomainModel.Train.Server;
using Mzl.DomainModel.XingA;
using Mzl.EntityModel.Common;
using Mzl.EntityModel.Common.AccountInfo;
using Mzl.EntityModel.Customer.AppClient;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Contact;
using Mzl.EntityModel.Customer.Corporation.Corp;
using Mzl.EntityModel.Customer.Corporation.CostCenter;
using Mzl.EntityModel.Customer.Corporation.Department;
using Mzl.EntityModel.Customer.Corporation.Project;
using Mzl.EntityModel.Customer.Corporation.ServiceFee;
using Mzl.EntityModel.Flight;
using Mzl.EntityModel.Train.BaseMaintenance;
using Mzl.EntityModel.Train.Order;
using Mzl.EntityModel.Train.Server;
using Mzl.EntityModel.XingA;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.DomainModel.Train.GrabTicket;
using Mzl.EntityModel.Train;
using Mzl.DomainModel.Register;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.EntityModel.Hotel.Elong;
using Mzl.EntityModel.Register;
using Mzl.EntityModel.Customer.TravelReport;
using Mzl.DomainModel.Customer.TravelReport;
using Mzl.DomainModel.Hotel.Elong.HotelInfo;
using Mzl.DomainModel.Hotel.Order;
using Mzl.EntityModel.Hotel;
using Mzl.EntityModel.Operator;

namespace Mzl.BLL.Tool.MapperConfig
{
    /// <summary>
    /// Bll层AutoMapper映射关系
    /// </summary>
    public class AutoMapperConfig: IMapperConfig
    {
        public void InitializeConfig(IMapperConfigurationExpression cfg)
        {
            //报表视图
            cfg.CreateMap<TravelReportAirlineCountEntity, TravelReportAirlineCountModel>();
            cfg.CreateMap<TravelReportCostCenterCountEntity, TravelReportCostCenterModel>();
            cfg.CreateMap<TravelReportReserveDayEntity, TravelReportReserveDayModel>();
            cfg.CreateMap<TravelReportSalePriceEntity, TravelReportSalePriceModel>();
            cfg.CreateMap<TravelReportAllSalePriceEntity, TravelReportAllSalePriceModel>();
            cfg.CreateMap<TravelReportDportCityEntity, TravelReportDportCityModel>();
            cfg.CreateMap<TravelReportPassengerTopEntity, TravelReportPassengerTopModel>();
            cfg.CreateMap<TravelReportConsumeCountEntity, TravelReportConsumeCountModel>();
            cfg.CreateMap<TravelReportYearPriceCountEntity, TravelReportYearPriceCountModel>();

            cfg.CreateMap<FltOrderModel, FltOrderEntity>().ReverseMap();
            cfg.CreateMap<FltFlightModel, FltFlightEntity>().ReverseMap();
            cfg.CreateMap<FltPassengerModel, FltPassengerEntity>().ReverseMap();
            cfg.CreateMap<FltRetModApplyEntity, FltRetModApplyModel>();
            cfg.CreateMap<FltWhiteListPassengerEntity, FltWhiteListPassengerModel>();
            cfg.CreateMap<AddRetModApplyModel, FltRetModApplyEntity>();
            cfg.CreateMap<FltRetModFlightApplyModel, FltRetModFlightApplyEntity>();
            cfg.CreateMap<FltRefundOrderEntity, FltRefundOrderModel>();
            cfg.CreateMap<FltRefundOrderDetailEntity, FltRefundDetailOrderModel>();
            cfg.CreateMap<FltModOrderEntity, FltModOrderModel>();
            cfg.CreateMap<FltModFlightEntity, FltModFlightModel>();
            cfg.CreateMap<FltModPassengerEntity, FltModPassengerModel>();
            cfg.CreateMap<FltModTicketNoEntity, FltModTicketNoModel>();
            cfg.CreateMap<FltModOrderLogEntity, FltModOrderLogModel>();
            cfg.CreateMap<FltRetModFlightApplyEntity, FltRetModFlightApplyModel>();
            cfg.CreateMap<FltRetModApplyLogEntity, FltRetModApplyLogModel>();
            cfg.CreateMap<FltPassengerModel, FltPassengerModel>();
            cfg.CreateMap<FltRetModFlightApplyModel, FltRetFlightModel>();
            cfg.CreateMap<FltClassNameEntity, FltClassNameModel>();
            cfg.CreateMap<FltOrderEntity, QueryFlightOrderListDataModel>();
            cfg.CreateMap<FltOrderEntity, QueryFlightOrderDataModel>();
            cfg.CreateMap<FltOrderEntity, FltOrderInfoModel>();

            cfg.CreateMap<InsuranceCompanyEntity, InsuranceCompanyModel>().ReverseMap();
            cfg.CreateMap<CountryEntity, SearchCountryModel>();
            cfg.CreateMap<CityEntity, SearchCityModel>();
            cfg.CreateMap<AirPortEntity, SearchAirportModel>();
            cfg.CreateMap<AccountModel, AccountEntity>().ReverseMap();
            cfg.CreateMap<AccountDetailModel, AccountDetailEntity>().ReverseMap();


            cfg.CreateMap<ContactIdentificationInfoEntity, IdentificationModel>().ReverseMap();
            cfg.CreateMap<ContactInfoEntity, ContactInfoModel>().ReverseMap();
            cfg.CreateMap<CorpDepartmentEntity, CorpDepartmentModel>().ReverseMap();
            cfg.CreateMap<CostCenterModel, CostCenterEntity>().ReverseMap();
            cfg.CreateMap<CustomerInfoEntity, CustomerInfoModel>().ReverseMap();
            cfg.CreateMap<CustomerUnionInfoEntity, CustomerUnionInfoModel>().ReverseMap();
            cfg.CreateMap<CorporationEntity, CorporationModel>().ReverseMap();
            cfg.CreateMap<CustomerInfoEntity, CustomerModel>().ReverseMap();
            cfg.CreateMap<ProjectNameEntity, ProjectNameModel>().ReverseMap();
            cfg.CreateMap<ServiceFeeConfigDetailsEntity, ServiceFeeConfigDetailsModel>();
            cfg.CreateMap<ServiceFeeConfigEntity, ServiceFeeConfigModel>();

            cfg.CreateMap<TraModOrderModel, TraModOrderEntity>().ReverseMap();
            cfg.CreateMap<TraModOrderListQueryModel, TraModOrderListQueryEntity>();
            cfg.CreateMap<TraModOrderListDataEntity, TraModOrderListDataModel>();
            cfg.CreateMap<TraModOrderDetailEntity, TraModOrderDetailModel>().ReverseMap();
            cfg.CreateMap<TraOrderEntity, TraOrderModel>().ReverseMap();
            cfg.CreateMap<TraOrderListQueryModel, TraOrderListQueryEntity>();
            cfg.CreateMap<TraOrderListDataEntity, TraOrderListDataModel>().ReverseMap();
            cfg.CreateMap<TraOrderDetailModel, TraOrderDetailEntity>().ReverseMap();
            cfg.CreateMap<TraOrderLogModel, TraOrderLogEntity>().ReverseMap();
            cfg.CreateMap<TraOrderStatusModel, TraOrderStatusEntity>().ReverseMap();
            cfg.CreateMap<TraPassengerModel, TraPassengerEntity>().ReverseMap();
            cfg.CreateMap<Tra12306AccountEntity, Tra12306AccountModel>();

            cfg.CreateMap<TraHoldSeatCallBackLogModel, TraHoldSeatCallBackLogEntity>().ReverseMap();
            cfg.CreateMap<TraModHoldSeatCallBackLogModel, TraModHoldSeatCallBackLogEntity>().ReverseMap();
            cfg.CreateMap<TraModPrintTicketCallBackLogModel, TraModPrintTicketCallBackLogEntity>().ReverseMap();
            cfg.CreateMap<TraPrintTicketCallBackLogModel, TraPrintTicketCallBackLogEntity>().ReverseMap();
            cfg.CreateMap<TraQueryTrainResponseDateModel, TraTravelInfoModel>().ReverseMap();
            cfg.CreateMap<TraRefundTicketCallBackLogModel, TraRefundTicketCallBackLogEntity>().ReverseMap();
            cfg.CreateMap<TraInterFaceOrderModel, TraInterFaceOrderEntity>().ReverseMap();

            cfg.CreateMap<XingAModel, XingAEntity>().ReverseMap();

            cfg.CreateMap<AddAppClientIdModel, CustomerAppClientIdEntity>();
            cfg.CreateMap<SendAppMessageModel, SendAppMessageEntity>().ReverseMap();


            cfg.CreateMap<AddTraGrabTicketModel, TraGrabTicketEntity>().ReverseMap();
            cfg.CreateMap<TraGrabTicketPassengerModel, TraGrabTicketPassengerEntity>().ReverseMap();
            cfg.CreateMap<TraGrabTicketModel, TraGrabTicketEntity>().ReverseMap();
            cfg.CreateMap<UpdateTraGrabTicketStatusModel, TraGrabTicketEntity>().ReverseMap();


            cfg.CreateMap<RegisterCustomerModel, RegisterCustomerEntity>();


            cfg.CreateMap<CorpAduitConfigEntity, CorpAduitConfigModel>().ReverseMap();
            cfg.CreateMap<CorpAduitConfigDetailEntity, CorpAduitConfigDetailModel>().ReverseMap();

            cfg.CreateMap<CorpAduitOrderEntity, CorpAduitOrderInfoModel>();
            cfg.CreateMap<CorpAduitOrderEntity, CorpAduitOrderModel>();
            cfg.CreateMap<CorpAduitOrderDetailEntity, CorpAduitOrderDetailModel>();
            cfg.CreateMap<CorpAduitOrderFlowEntity, CorpAduitOrderFlowModel>();
            cfg.CreateMap<CorpAduitOrderLogEntity, CorpAduitOrderLogModel>();

            #region 酒店
            cfg.CreateMap<QueryHotelInfoRequestModel, HotelListRequestEntity>();
            cfg.CreateMap<QueryHotelDetailRequestModel, HotelDetailRequestEntity>();
            cfg.CreateMap<HotelListResponseEntity, QueryHotelInfoResponseModel>();
            cfg.CreateMap<HotelEntity, HotelInfoResultModel>();
            cfg.CreateMap<BookingRuleEntity, HotelBookingRuleModel>();
            cfg.CreateMap<GuaranteeRuleEntity, HotelGuaranteeRuleModel>();
            cfg.CreateMap<PrepayRuleEntity, HotelPrepayRuleModel>();
            cfg.CreateMap<ValueAddEntity, HotelValueAddModel>();
            cfg.CreateMap<DrrRuleEntity, HotelDrrRuleModel>();
            cfg.CreateMap<RoomEntity, HotelRoomsModel>();
            cfg.CreateMap<ListRatePlanEntity, HotelRatePlanModel>();
            cfg.CreateMap<NightlyRateEntity, HotelNightlyRatesModel>();
            cfg.CreateMap<DetailEntity, HotelDetailModel>();
            cfg.CreateMap<ReviewEntity, HotelReviewModel>();
            #endregion

            cfg.CreateMap<ContactAddressEntity, ContactAddressModel>();


            cfg.CreateMap<FltOrderEntity, FltOrderEntity>();
            cfg.CreateMap<FltOrderUnionEntity, FltOrderUnionEntity>();
            cfg.CreateMap<FltCorpCostCenterEntity, FltCorpCostCenterEntity>();
            cfg.CreateMap<FltFlightEntity, FltFlightEntity>();
            cfg.CreateMap<FltPassengerEntity, FltPassengerEntity>();
            cfg.CreateMap<FltTicketNoEntity, FltTicketNoEntity>();

            cfg.CreateMap<CorpAduitOrderEntity, CorpAduitOrderEntity>();
            cfg.CreateMap<CorpAduitOrderDetailEntity, CorpAduitOrderDetailEntity>();
            cfg.CreateMap<CorpAduitOrderFlowEntity, CorpAduitOrderFlowEntity>();
            cfg.CreateMap<CorpAduitOrderLogEntity, CorpAduitOrderLogEntity>();


            cfg.CreateMap<TraOrderEntity, TraOrderEntity>();
            cfg.CreateMap<TraOrderDetailEntity, TraOrderDetailEntity>();
            cfg.CreateMap<TraPassengerEntity, TraPassengerEntity>();


            cfg.CreateMap<HolOrderEntity, HolOrderEntity>();
            cfg.CreateMap<HolOrderDetailEntity, HolOrderDetailEntity>();

            cfg.CreateMap<HolOrderEntity, HotelOrderInfoModel>();
            cfg.CreateMap<HolOrderDetailEntity, HotelOrderDetailModel>();

            cfg.CreateMap<SearchFlightDetailModel, SearchFlightDetailModel>();

            cfg.CreateMap<OperatorEntity, OperatorModel>().ReverseMap();

        }

    }
}
