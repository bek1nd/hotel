using System.Data.Entity;
using Mzl.EntityModel.Common;
using Mzl.EntityModel.Common.AccountInfo;
using Mzl.EntityModel.Customer.AppClient;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Contact;
using Mzl.EntityModel.Customer.Corporation.Corp;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.EntityModel.Customer.Corporation.CostCenter;
using Mzl.EntityModel.Customer.Corporation.Department;
using Mzl.EntityModel.Customer.Corporation.Project;
using Mzl.EntityModel.Customer.Corporation.ServiceFee;
using Mzl.EntityModel.Train.BaseMaintenance;
using Mzl.EntityModel.Train.Order;
using Mzl.EntityModel.Train.Server;
using Mzl.EntityModel.Flight;
using Mzl.EntityModel.Customer.Corporation.CorpPolicy;
using Mzl.EntityModel.Operator;
using Mzl.EntityModel.Train;
using Mzl.EntityModel.XingA;
using Mzl.EntityModel.Register;
using Mzl.EntityModel.Customer.TravelReport;
using Mzl.EntityModel.Hotel;
using Mzl.EntityModel.Hotel.CTripHotel;

namespace Mzl.EntityModel.EFContext
{
    public class BrightourDbContext : DbContext
    {
        public BrightourDbContext() : base("name=brightour")
        {

        }

        static BrightourDbContext()
        {
            Database.SetInitializer<BrightourDbContext>(null);
        }
        #region 差旅报告
        /// <summary>
        /// 差旅报告-航段
        /// </summary>
        public DbSet<TravelReportAirlineCountEntity> TravelReportAirlineCount { get; set; }
        /// <summary>
        /// 差旅报告-成本中心汇总表 
        /// </summary>
        public DbSet<TravelReportCostCenterCountEntity> TravelReportCostCenterCountEntity { get; set; }
        /// <summary>
        /// 差旅报告-预定提前天数占比 
        /// </summary>
        public DbSet<TravelReportReserveDayEntity> TravelReportReserveDayEntity { get; set; }
        ///<summary>
        ///打折比率
        ///</summary>
        public DbSet<TravelReportSalePriceEntity> TravelReportSalePriceEntity { get; set; }
        public DbSet<TravelReportAllSalePriceEntity> TravelReportallAllSalePriceEntity { get; set; }
        /// <summary>
        /// 前10条出差航段汇总表 
        /// </summary>
        public DbSet<TravelReportDportCityEntity> TravelReportDportCityEntity { get; set; }
        /// <summary>
        /// 前10位人员出差人次汇总表
        /// </summary>
        public DbSet<TravelReportPassengerTopEntity> TravelReportPassengerTopEntity { get; set; }
        /// <summary>
        /// 汇总表
        /// </summary>
        public DbSet<TravelReportConsumeCountEntity> TravelReportConsumeCountEntity { get; set; }
        public DbSet<TravelReportYearPriceCountEntity> TravelReportYearPriceCountEntity { get; set; }
        #endregion

        #region 公共信息
        /// <summary>
        /// 机场
        /// </summary>
        public DbSet<AirPortEntity> AirPort { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public DbSet<CityEntity> City { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public DbSet<CountryEntity> Country { get; set; }
        /// <summary>
        /// 保险产品
        /// </summary>
        public DbSet<InsuranceCompanyEntity> InsuranceCompany { get; set; }
        /// <summary>
        /// App推送信息
        /// </summary>
        public DbSet<SendAppMessageEntity> SendAppMessage { get; set; }
        #endregion

        #region 火车
        /// <summary>
        /// 占位日志表
        /// </summary>
        public DbSet<TraHoldSeatCallBackLogEntity> TraHoldSeatCallBackLog { get; set; }
        public DbSet<TraModHoldSeatCallBackLogEntity> TraModHoldSeatCallBackLog { get; set; }
        public DbSet<TraModPrintTicketCallBackLogEntity> TraModPrintTicketCallBackLog { get; set; }
        public DbSet<TraPrintTicketCallBackLogEntity> TraPrintTicketCallBackLog { get; set; }
        public DbSet<TraRefundTicketCallBackLogEntity> TraRefundTicketCallBackLog { get; set; }
        /// <summary>
        /// 火车订单表
        /// </summary>
        public DbSet<TraOrderEntity> TraOrder { get; set; }
        /// <summary>
        /// 火车订单状态表
        /// </summary>
        public DbSet<TraOrderStatusEntity> TraOrderStatus { get; set; }
        /// <summary>
        /// 火车行程表
        /// </summary>
        public DbSet<TraOrderDetailEntity> TraOrderDetail { get; set; }
        /// <summary>
        /// 火车乘车人表
        /// </summary>
        public DbSet<TraPassengerEntity> TraPassenger { get; set; }
        /// <summary>
        /// 接口订单操作记录表
        /// </summary>
        public DbSet<TraOrderOperateEntity> TraOrderOperate { get; set; }
        /// <summary>
        /// 接口订单表
        /// </summary>
        public DbSet<TraInterFaceOrderEntity> InterFaceOrder { get; set; }
        /// <summary>
        /// 改签订单
        /// </summary>
        public DbSet<TraModOrderEntity> TraModOrder { get; set; }
        /// <summary>
        /// 改签行程明细
        /// </summary>
        public DbSet<TraModOrderDetailEntity> TraModDetail { get; set; }
        /// <summary>
        /// 火车站信息
        /// </summary>
        public DbSet<TraAddressEntity> TraAddress { get; set; }
        /// <summary>
        /// 火车订单日志
        /// </summary>
        public DbSet<TraOrderLogEntity> TraOrderLog { get; set; }
        /// <summary>
        /// 12306帐号信息
        /// </summary>
        public DbSet<Tra12306AccountEntity> Tra12306AccountEntity { get; set; }
        /// <summary>
        /// 抢票信息
        /// </summary>
        public DbSet<TraGrabTicketEntity> TraGrabTicket { get; set; }
        /// <summary>
        /// 抢票乘车人
        /// </summary>
        public DbSet<TraGrabTicketPassengerEntity> TraGrabTicketPassenger { get; set; }
        #endregion

        #region 收付款账户
        /// <summary>
        /// 帐号信息
        /// </summary>
        public DbSet<AccountEntity> AccountInfo { get; set; }
        /// <summary>
        /// 帐号收支明细
        /// </summary>
        public DbSet<AccountDetailEntity> AccountDetailInfo { get; set; }
        #endregion

        #region 客户信息
        /// <summary>
        /// 客户信息
        /// </summary>
        public DbSet<CustomerInfoEntity> CustomerInfo { get; set; }
        /// <summary>
        /// 客户扩展信息
        /// </summary>
        public DbSet<CustomerUnionInfoEntity> CustomerUnionInfo { get; set; }

        /// <summary>
        /// 联系人信息
        /// </summary>
        public DbSet<ContactInfoEntity> ContactInfo { get; set; }
        /// <summary>
        /// 联系人证件信息
        /// </summary>
        public DbSet<ContactIdentificationInfoEntity> ContactIdentificationInfo { get; set; }
        /// <summary>
        /// 客户的设备ID信息表
        /// </summary>
        public DbSet<CustomerAppClientIdEntity> AppClientId { get; set; }
        /// <summary>
        /// 客户app意见表
        /// </summary>
        public DbSet<AppOpinionEntity> AppOpinion { get; set; }
        /// <summary>
        /// 联系地址
        /// </summary>
        public DbSet<ContactAddressEntity> ContactAddress { get; set; }
        #endregion

        #region 公司信息

        /// <summary>
        /// 成本中心
        /// </summary>
        public DbSet<CostCenterEntity> CostCenterInfo { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public DbSet<ProjectNameEntity> ProjectNameInfo { get; set; }
        /// <summary>
        /// 公司所属部门信息
        /// </summary>
        public DbSet<CorpDepartmentEntity> CorpDepartmentInfo { get; set; }
        /// <summary>
        /// 服务费配置
        /// </summary>
        public DbSet<ServiceFeeConfigEntity> ServiceFeeConfig { get; set; }
        /// <summary>
        /// 服务费配置明细
        /// </summary>
        public DbSet<ServiceFeeConfigDetailsEntity> ServiceFeeConfigDetails { get; set; }
        /// <summary>
        /// 公司信息
        /// </summary>
        public DbSet<CorporationEntity> CorporationInfo { get; set; }
        /// <summary>
        /// 差旅政策明细
        /// </summary>
        public DbSet<CorpPolicyDetailConfigEntity> CorpPolicyDetailConfig { get; set; }
        /// <summary>
        /// 差旅政策
        /// </summary>
        public DbSet<CorpPolicyConfigEntity> CorpPolicyConfig { get; set; }
        /// <summary>
        /// 差旅原因
        /// </summary>
        public DbSet<ChoiceReasonEntity> ChoiceReason { get; set; }
        /// <summary>
        /// 差旅政策与部门的关系表
        /// </summary>
        public DbSet<CorpPolicyConfigDepartmentEntity> CorpPolicyConfigDepartment { get; set; }
        /// <summary>
        /// 差旅政策与部门员工关系表
        /// </summary>
        public DbSet<CorpPolicyConfigCustomerEntity> CorpPolicyConfigCustomer { get; set; }
        /// <summary>
        /// 差旅政策与项目成本中心的关系表
        /// </summary>
        public DbSet<CorpPolicyConfigProjectEntity> CorpPolicyConfigProject { get; set; }
        /// <summary>
        /// 差旅审批规则
        /// </summary>
        public DbSet<CorpAduitConfigEntity> CorpAduitConfig { get; set; }
        /// <summary>
        /// 差旅审批规则明细
        /// </summary>
        public DbSet<CorpAduitConfigDetailEntity> CorpAduitConfigDetail { get; set; }
        /// <summary>
        /// 差旅审批规则与部门的关系表
        /// </summary>
        public DbSet<CorpAduitConfigDepartmentEntity> CorpAduitConfigDepartment { get; set; }
        /// <summary>
        /// 差旅审批规则与项目成本中心的关系表
        /// </summary>
        public DbSet<CorpAduitConfigProjectEntity> CorpAduitConfigProject { get; set; }
        /// <summary>
        /// 差旅审批规则与部门员工的关系表
        /// </summary>
        public DbSet<CorpAduitConfigCustomerEntity> CorpAduitConfigCustomer { get; set; }
        /// <summary>
        /// 审批单表
        /// </summary>
        public DbSet<CorpAduitOrderEntity> CorpAduitOrder { get; set; }
        /// <summary>
        /// 审批单与订单关系表
        /// </summary>
        public DbSet<CorpAduitOrderDetailEntity> CorpAduitOrderDetail { get; set; }
        /// <summary>
        /// 审批阶段表
        /// </summary>
        public DbSet<CorpAduitOrderFlowEntity> CorpAduitOrderFlow { get; set; }
        /// <summary>
        /// 审批日志表
        /// </summary>
        public DbSet<CorpAduitOrderLogEntity> CorpAduitOrderLog { get; set; }

        #endregion

        #region 机票
        /// <summary>
        /// 机票订单
        /// </summary>
        public DbSet<FltOrderEntity> FltOrder { get; set; }
        /// <summary>
        /// 舱等
        /// </summary>
        public DbSet<FltClassNameEntity> FltClassName { get; set; }
        /// <summary>
        /// 机票航程
        /// </summary>
        public DbSet<FltFlightEntity> FltFlight { get; set; }
        /// <summary>
        /// 机票订单日志
        /// </summary>
        public DbSet<FltOrderLogEntity> FltOrderLog { get; set; }
        /// <summary>
        /// 机票订单附表
        /// </summary>
        public DbSet<FltOrderUnionEntity> FltOrderUnion { get; set; }
        /// <summary>
        /// 机票乘机人
        /// </summary>
        public DbSet<FltPassengerEntity> FltPassenger { get; set; }
        /// <summary>
        /// 机票票号
        /// </summary>
        public DbSet<FltTicketNoEntity> FltTicketNo { get; set; }
       /// <summary>
       /// 机票订单成本中心信息
       /// </summary>
        public DbSet<FltCorpCostCenterEntity> FltCorpCostCenter { get; set; }
        /// <summary>
        /// 白名单表
        /// </summary>
        public DbSet<FltWhiteListPassengerEntity> FltWhiteListPassenger { get; set; }
        /// <summary>
        /// 退改签申请表
        /// </summary>
        public DbSet<FltRetModApplyEntity> FltRetModApply { get; set; }
        /// <summary>
        /// 退改签申请明细信息
        /// </summary>
        public DbSet<FltRetModFlightApplyEntity> FltRetModFlightApply { get; set; }
        /// <summary>
        /// 退改签申请日志
        /// </summary>
        public DbSet<FltRetModApplyLogEntity> FltRetModApplyLog { get; set; }
        /// <summary>
        /// 改签订单表
        /// </summary>
        public DbSet<FltModOrderEntity> FltModOrder { get; set; }
        /// <summary>
        /// 改签订单日志表
        /// </summary>
        public DbSet<FltModOrderLogEntity> FltModOrderLog { get; set; }
        /// <summary>
        /// 改签行程表
        /// </summary>
        public DbSet<FltModFlightEntity> FltModFlight { get; set; }
        /// <summary>
        /// 改签乘机人
        /// </summary>
        public DbSet<FltModPassengerEntity> FltModPassenger { get; set; }
        /// <summary>
        /// 改签票号表
        /// </summary>
        public DbSet<FltModTicketNoEntity> FltModTicketNo { get; set; }
        /// <summary>
        /// 退票订单
        /// </summary>
        public DbSet<FltRefundOrderEntity> RefundOrder { get; set; }
        /// <summary>
        /// 退票订单详情
        /// </summary>
        public DbSet<FltRefundOrderDetailEntity> FltRefundOrderDetail { get; set; }
        #endregion

        #region 行啊
        /// <summary>
        /// 行啊数据
        /// </summary>
        public DbSet<XingAEntity> XingACenter { get; set; }
        #endregion

        #region 员工
        /// <summary>
        /// OA员工信息
        /// </summary>
        public DbSet<OperatorEntity> Operator { get; set; }
        #endregion

        /// <summary>
        /// 合作登记
        /// </summary>
        public DbSet<RegisterCustomerEntity> RegisterCustomer { get; set; }

        #region 酒店
        /// <summary>
        /// 酒店订单
        /// </summary>
        public DbSet<HolOrderEntity> HolOrder { get; set; }
        /// <summary>
        /// 酒店订单明细（间夜信息）
        /// </summary>
        public DbSet<HolOrderDetailEntity> HolOrderDetail { get; set; }
        /// <summary>
        /// 酒店订单日志
        /// </summary>
        public DbSet<HolOrderLogEntity> HolOrderLog { get; set; }
        /// <summary>
        /// 酒店退房
        /// </summary>
        public DbSet<HolRefundEntity> HolRefund { get; set; }
        #endregion


        #region 携程酒店接口
        public DbSet<CTripHotelCityCNEntity> cTripHotelCityCNs { get; set; }
        public DbSet<CTripHotelCityENEntity> cTripHotelCityENs { get; set; }
        #endregion
    }
}
