using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Common.Insurance;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight
{
    public class GetFltOrderBll: BaseBll,IGetFltOrderBll
    {
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltFlightDal _fltFlightDal;
        private readonly IFltPassengerDal _fltPassengerDal;
        private readonly IFltCorpCostCenterDal _fltCorpCostCenterDal;
        private readonly IGetClassNameBll _getClassNameBll;
        private readonly IFltOrderUnionDal _fltOrderUnionDal;

        public GetFltOrderBll(IFltOrderDal fltOrderDal, IFltFlightDal fltFlightDal,
           IFltPassengerDal fltPassengerDal, IFltCorpCostCenterDal fltCorpCostCenterDal,
           IGetClassNameBll getClassNameBll, IFltOrderUnionDal fltOrderUnionDal) 
        {
            _fltOrderDal = fltOrderDal;
            _fltFlightDal = fltFlightDal;
            _fltPassengerDal = fltPassengerDal;
            _fltCorpCostCenterDal = fltCorpCostCenterDal;
            _getClassNameBll = getClassNameBll;
            _fltOrderUnionDal = fltOrderUnionDal;
        }

        public SearchCityAportModel AportInfo {private get; set; }
        public List<ProjectNameModel> ProjectNameList { private get; set; }
        public List<InsuranceCompanyModel> InsuranceCompanyList { private get; set; }


        /// <summary>
        /// 根据订单号获取订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public FltOrderInfoModel GetFltOrderById(int orderId)
        {
            FltOrderEntity fltOrderEntity = _fltOrderDal.Find<FltOrderEntity>(orderId);
            if (fltOrderEntity == null)
                return null;

            //1.根据订单号 获取航段信息
            List<FltFlightEntity> flightEntities =
                _fltFlightDal.Query<FltFlightEntity>(n => n.OrderId == orderId, true).ToList();
            //2.根据订单号 获取乘机人信息
            List<FltPassengerEntity> passengerEntities =
                _fltPassengerDal.Query<FltPassengerEntity>(n => n.OrderId == orderId, true).ToList();
            //3.根据订单号 获取成本中心
            FltCorpCostCenterEntity costCenterEntity =
                _fltCorpCostCenterDal.Query<FltCorpCostCenterEntity>(n => n.Orderid == orderId, true).FirstOrDefault();
            //4.获取仓等信息
            List<FltClassNameModel> classNameModels = _getClassNameBll.GetFlightClassName();
            //5.获取机场信息
            List<SearchCityModel> cityModels = AportInfo?.CountryList.SelectMany(n => n.CityList).ToList();
            List<SearchAirportModel> airportModels = cityModels?.SelectMany(n => n.AirportList).ToList();
            //6.机票订单扩展表
            FltOrderUnionEntity fltOrderUnionEntity = _fltOrderUnionDal.Find<FltOrderUnionEntity>(orderId);

            FltOrderInfoModel result = Mapper.Map<FltOrderEntity, FltOrderInfoModel>(fltOrderEntity);

            if (!string.IsNullOrEmpty(costCenterEntity?.Depart))
                result.CostCenter = costCenterEntity.Depart;
            if (fltOrderUnionEntity?.ProjectId != null && ProjectNameList != null)
            {
                ProjectNameModel projectNameModel = ProjectNameList.Find(n => n.ProjectId == fltOrderUnionEntity.ProjectId.Value);
                result.ProjectName = projectNameModel?.ProjectName;
            }
            //result.CorpPolicy = fltOrderUnionEntity?.CorpPolicy;
            result.PassengerList =
                Mapper.Map<List<FltPassengerEntity>, List<FltPassengerModel>>(
                    passengerEntities.FindAll(n => n.OrderId == fltOrderEntity.OrderId));
            result.FlightList =
                Mapper.Map<List<FltFlightEntity>, List<FltFlightModel>>(
                    flightEntities.FindAll(n => n.OrderId == fltOrderEntity.OrderId));

            result.PassengerList.ForEach(n =>
            {
                if (n.InsCompanyId.HasValue)
                    n.InsuranceName = InsuranceCompanyList?.Find(x => x.CompanyID == n.InsCompanyId.Value)?.ProductName;
            });
            #region 行程信息

            result.CorpPolicy = string.Empty;
            result.ChoiceReason = string.Empty;
            foreach (var n in result.FlightList)
            {
                if (!string.IsNullOrEmpty(n.CorpPolicy) && n.CorpPolicy.ToLower() != "undefined")
                    result.CorpPolicy += ";" + n.CorpPolicy;
                if (!string.IsNullOrEmpty(n.ChoiceReason) && n.ChoiceReason.ToLower() != "undefined")
                    result.ChoiceReason += ";" + n.ChoiceReason;
               SearchAirportModel airportModel = airportModels?.Find(x => x.AirportCode.ToLower() == n.Dport.ToLower());
                if (airportModel != null)
                {
                    n.DportName = airportModel.AirportLongName;
                    SearchCityModel cityModel = cityModels.Find(x => x.CityCode.ToLower() == airportModel.CityCode.ToLower());
                    n.DportCity = cityModel.CityName;
                }

                SearchAirportModel airportModel2 = airportModels?.Find(x => x.AirportCode.ToLower() == n.Aport.ToLower());
                if (airportModel2 != null)
                {
                    n.AportName = airportModel2.AirportLongName;
                    SearchCityModel cityModel2 = cityModels.Find(x => x.CityCode.ToLower() == airportModel2.CityCode.ToLower());
                    n.AportCity = cityModel2.CityName;
                }

                FltClassNameModel classNameModel =
                    classNameModels.Find(
                        x =>
                            !string.IsNullOrEmpty(x.MClass) && !string.IsNullOrEmpty(n.Class) &&
                            x.MClass.ToLower() == n.Class.ToLower() &&
                            !string.IsNullOrEmpty(x.AirlineCode) && !string.IsNullOrEmpty(n.AirlineNo) &&
                            x.AirlineCode.ToLower() == n.AirlineNo.ToLower());

                if (classNameModel != null)
                {
                    n.ClassName = classNameModel.ClassName;
                    n.ClassEnName = classNameModel.ClassEnName;
                }
            }

            if (!string.IsNullOrEmpty(result.CorpPolicy))
            {
                result.CorpPolicy = result.CorpPolicy.Substring(1);
            }

            if (!string.IsNullOrEmpty(result.ChoiceReason))
            {
                result.ChoiceReason = result.ChoiceReason.Substring(1);
            }

            #endregion

            return result;
        }

        public List<FltOrderInfoModel> GetFltOrderListById(List<int> orderIdList)
        {
            List<FltOrderInfoModel> orderInfoModels = new List<FltOrderInfoModel>();
            foreach (var orderId in orderIdList)
            {
                var order = GetFltOrderById(orderId);
                if (order != null)
                    orderInfoModels.Add(order);
            }
            return orderInfoModels;
        }
    }
}
