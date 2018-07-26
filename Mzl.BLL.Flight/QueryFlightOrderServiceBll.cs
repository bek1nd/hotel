using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.IBLL.Flight;
using Mzl.Framework.Base;
using Mzl.IDAL.Flight;
using AutoMapper;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Common.Insurance;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.IBLL.Flight.DomesticRetMod;

namespace Mzl.BLL.Flight
{
    public class QueryFlightOrderServiceBll : BaseServiceBll, IQueryFlightOrderServiceBll
    {
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltFlightDal _fltFlightDal;
        private readonly IFltPassengerDal _fltPassengerDal;
        private readonly IFltCorpCostCenterDal _fltCorpCostCenterDal;
        private readonly IGetClassNameBll _getClassNameBll;
        private readonly IFltOrderUnionDal _fltOrderUnionDal;
        private readonly IGetFlightModOrderBll _getFlightModOrderBll;
        private readonly IGetFlighRefundOrderBll _getFlighRefundOrderBll;
        public QueryFlightOrderServiceBll(IFltOrderDal fltOrderDal, IFltFlightDal fltFlightDal,
           IFltPassengerDal fltPassengerDal, IFltCorpCostCenterDal fltCorpCostCenterDal,
           IGetClassNameBll getClassNameBll, IFltOrderUnionDal fltOrderUnionDal,
           IGetFlightModOrderBll getFlightModOrderBll, IGetFlighRefundOrderBll getFlighRefundOrderBll) : base()
        {
            _fltOrderDal = fltOrderDal;
            _fltFlightDal = fltFlightDal;
            _fltPassengerDal = fltPassengerDal;
            _fltCorpCostCenterDal = fltCorpCostCenterDal;
            _getClassNameBll = getClassNameBll;
            _fltOrderUnionDal = fltOrderUnionDal;
            _getFlightModOrderBll = getFlightModOrderBll;
            _getFlighRefundOrderBll = getFlighRefundOrderBll;
        }

        public QueryFlightOrderDataModel QueryFlightOrder(QueryFlightOrderQueryModel query)
        {
            var select=_fltOrderDal.Query<FltOrderEntity>(n => n.OrderId == query.OrderId, true);
            FltOrderEntity fltOrderEntity = select.FirstOrDefault();

            if (fltOrderEntity == null)
            {
                throw new Exception("查无此订单");
            }
            //如果登录用户没有查看全部订单的权限
            if ((query.Customer.IsShowAllOrder ?? 0) == 0)
            {
                if (!query.IsFromAduitQuery)//不是来自审批人查询
                {
                    if (!string.IsNullOrEmpty(query.Customer?.UserID) && query.Customer.UserID.ToLower() != "administrator"
                        && query.Customer.Cid != fltOrderEntity.Cid)
                        throw new Exception("查无此订单");
                }
            }
            if (!string.IsNullOrEmpty(query.Customer?.UserID) && query.Customer.UserID.ToLower() == "administrator")
            {
                if ((query.CidList != null && !query.CidList.Contains(fltOrderEntity.Cid)) || query.CidList == null)
                    throw new Exception("查无此订单");
            }

            //1.根据订单号 获取航段信息
            List<FltFlightEntity> flightEntities = _fltFlightDal.Query<FltFlightEntity>(n => n.OrderId == query.OrderId, true).ToList();
            //2.根据订单号 获取乘机人信息
            List<FltPassengerEntity> passengerEntities = _fltPassengerDal.Query<FltPassengerEntity>(n => n.OrderId == query.OrderId, true).ToList();
            //3.根据订单号 获取成本中心
            FltCorpCostCenterEntity costCenterEntity=_fltCorpCostCenterDal.Query<FltCorpCostCenterEntity>(n => n.Orderid == query.OrderId, true).FirstOrDefault();
            //4.获取仓等信息
            List<FltClassNameModel> classNameModels = _getClassNameBll.GetFlightClassName();
            //5.获取机场信息
            List<SearchCityModel> cityModels = query.AportInfo.CountryList.SelectMany(n => n.CityList).ToList();
            List<SearchAirportModel> airportModels = cityModels.SelectMany(n => n.AirportList).ToList();

            FltOrderUnionEntity fltOrderUnionEntity = _fltOrderUnionDal.Find<FltOrderUnionEntity>(query.OrderId);

            #region 机票正单信息 
            QueryFlightOrderDataModel result = Mapper.Map<FltOrderEntity, QueryFlightOrderDataModel>(fltOrderEntity);
            if (!string.IsNullOrEmpty(costCenterEntity?.Depart))
                result.CostCenter = costCenterEntity.Depart;
            if (fltOrderUnionEntity?.ProjectId != null && query.ProjectName != null)
            {
                ProjectNameModel projectNameModel= query.ProjectName.Find(n => n.ProjectId == fltOrderUnionEntity.ProjectId.Value);
                result.ProjectName = projectNameModel?.ProjectName;
                result.ProjectId = fltOrderUnionEntity.ProjectId;
            }
            result.PassengerList =
                Mapper.Map<List<FltPassengerEntity>, List<FltPassengerModel>>(
                    passengerEntities.FindAll(n => n.OrderId == fltOrderEntity.OrderId));


            result.FlightList =
                Mapper.Map<List<FltFlightEntity>, List<FltFlightModel>>(
                    flightEntities.FindAll(n => n.OrderId == fltOrderEntity.OrderId));

            #region 行程
            int index1 = 0;
            foreach (var n in result.FlightList)
            {
                SearchAirportModel airportModel = airportModels.Find(x => x.AirportCode.ToLower() == n.Dport.ToLower());
                if (airportModel != null)
                {
                    n.DportName = airportModel.AirportLongName;
                    SearchCityModel cityModel = cityModels.Find(x => x.CityCode.ToLower() == airportModel.CityCode.ToLower());
                    n.DportCity = cityModel.CityName;
                }

                SearchAirportModel airportModel2 = airportModels.Find(x => x.AirportCode.ToLower() == n.Aport.ToLower());
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

                index1++;
            } 
            #endregion
            #endregion

            #region 机票退改签订单信息

            //改签订单
            List<string> modName = new List<string>();
            List<string> modSequenceList = new List<string>();
            _getFlightModOrderBll.AportInfo = query.AportInfo;
            List<FltModOrderModel> fltModOrderList = _getFlightModOrderBll.GetModOrderByOrderId(query.OrderId);
            if (fltModOrderList != null && fltModOrderList.Count > 0)
            {
                fltModOrderList = fltModOrderList.FindAll(n => (n.ProcessStatus & 8) == 8);
                fltModOrderList.ForEach(n =>
                {
                    n.FltModFlightList.ForEach(x =>
                    {
                        n.FltModPassengerList.ForEach(m =>
                        {
                            modSequenceList.Add(x.Sequence + "|" + m.Name);
                        });

                        FltClassNameModel classNameModel =
                            classNameModels.Find(
                                m =>
                                    !string.IsNullOrEmpty(m.MClass) && !string.IsNullOrEmpty(x.Class) &&
                                    m.MClass.ToLower() == x.Class.ToLower() &&
                                    !string.IsNullOrEmpty(m.AirlineCode) && !string.IsNullOrEmpty(x.AirlineNo) &&
                                    m.AirlineCode.ToLower() == x.AirlineNo.ToLower());

                        if (classNameModel != null)
                        {
                            x.ClassName = classNameModel.ClassName;
                            x.ClassEnName = classNameModel.ClassEnName;
                        }
                    });

                    

                });
                modSequenceList = modSequenceList.Distinct().ToList();
            }

            //退票订单
            List<string>retName = new List<string>();
            List<string> refundSequenceList = new List<string>();
            List<FltRefundOrderModel> fltRefundOrderList = _getFlighRefundOrderBll.GetFlighRefundOrderByOrderId(query.OrderId);
            if (fltRefundOrderList != null && fltRefundOrderList.Count > 0)
            {
                fltRefundOrderList = fltRefundOrderList.FindAll(n => n.RefundCustomer == "T");
                fltRefundOrderList.ForEach(n =>
                {
                    n.DetailList.ForEach(x =>
                    {
                        FltFlightModel flightTemp = result.FlightList.Find(m => m.Sequence == x.Sequence);
                        x.Dport = flightTemp.Dport;
                        x.DportName = flightTemp.DportName;
                        x.DportCity = flightTemp.DportCity;
                        x.Aport = flightTemp.Aport;
                        x.AportName = flightTemp.AportName;
                        x.AportCity = flightTemp.AportCity;
                        x.FlightNo = flightTemp.FlightNo;
                        x.Class = flightTemp.Class;
                        refundSequenceList.Add(x.Sequence+"|"+x.PassengerName);
                        retName.Add(x.PassengerName);
                    });
                  
                });
                refundSequenceList = refundSequenceList.Distinct().ToList();
                result.FltRefundOrderList = fltRefundOrderList;
            }

            #region 先处理改签情况
            if (fltModOrderList != null)
            {
                List<FltModOrderModel> tempList = new List<FltModOrderModel>();

                foreach (string modSequence in modSequenceList)
                {
                    int sequence = Convert.ToInt32(modSequence.Split('|')[0]);
                    string passengerName = modSequence.Split('|')[1];

                    var flightRmidList =
                        fltModOrderList.SelectMany(n => n.FltModFlightList)
                            .Where(n => n.Sequence == sequence)
                            .Select(n => n.Rmid)
                            .ToList();
                    var passengerRmidList =
                        fltModOrderList.SelectMany(n => n.FltModPassengerList)
                            .Where(n => n.Name == passengerName)
                            .Select(n => n.Rmid)
                            .ToList();

                    int maxRmid = fltModOrderList.Where(
                        n => flightRmidList.Contains(n.Rmid) && passengerRmidList.Contains(n.Rmid))
                        .Max(n => n.Rmid);

                    var temp = fltModOrderList.Find(n => n.Rmid == maxRmid);
                    if (tempList.Find(n => n.Rmid == temp.Rmid) == null)
                    {
                        tempList.Add(temp);
                    }
                }

                result.FltModOrderList = tempList;
                result.FltModOrderList.ForEach(n =>
                {
                    n.FltModPassengerList.ForEach(x =>
                    {
                        modName.Add(x.Name);
                    });
                });
            } 
            #endregion

            #region 既有改签又有退票

            if (fltModOrderList != null && refundSequenceList.Count > 0)
            {
                foreach (string refundSequence in refundSequenceList)
                {
                    //将相同行程号，并且是相同人名的改签行程删除
                    int sequence = Convert.ToInt32(refundSequence.Split('|')[0]);
                    string passengerName = refundSequence.Split('|')[1];

                    for (int i = 0; i < fltModOrderList.Count; i++)
                    {
                        List<FltModPassengerModel> fltModPassengerModels =
                            fltModOrderList[i].FltModPassengerList.FindAll(n => n.Name == passengerName);
                        FltModFlightModel fltModFlightModel =
                            fltModOrderList[i].FltModFlightList.Find(n => n.Sequence == sequence);

                        if (fltModPassengerModels != null && fltModPassengerModels.Count > 0 &&
                            fltModFlightModel != null)
                        {
                            fltModOrderList[i].FltModFlightList.Remove(fltModFlightModel);
                        }

                    }

                }


                if (fltModOrderList != null && fltModOrderList.Count > 0)
                {
                    List<FltModOrderModel> index = new List<FltModOrderModel>();
                    for (int i = 0; i < fltModOrderList.Count; i++)
                    {
                        if (fltModOrderList[i].FltModFlightList.Count == 0)
                        {
                            index.Add(fltModOrderList[i]);
                        }
                    }

                    foreach (var i in index)
                    {
                        fltModOrderList.Remove(i);
                    }

                    modName = new List<string>();
                    result.FltModOrderList = fltModOrderList;
                    result.FltModOrderList.ForEach(n =>
                    {
                        n.FltModPassengerList.ForEach(x =>
                        {
                            modName.Add(x.Name);
                        });
                    });

                }
            }
            #endregion
            #endregion
            result.PassengerList.ForEach(n =>
            {
                if (n.InsCompanyId.HasValue)
                    n.InsuranceName=query.InsuranceCompany?.Find(x => x.CompanyID == n.InsCompanyId.Value)?.ProductName;
                if (modName.Count > 0)
                {
                    n.IsMod = (modName.Find(x => x == n.Name) != null ? true : false);
                }

                if (retName.Count > 0)
                {
                    n.IsRet = (retName.Find(x => x == n.Name) != null ? true : false);
                }
            });
            return result;
        }
    }
}
