using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.BLL.Customer.Customer;
using Mzl.DomainModel.Customer.TravelReport;
using Mzl.UIModel.Customer.TravelReport;
using AutoMapper;

namespace Mzl.Application.Customer
{
    internal class TravelReportApplication : BaseApplicationService, ITravelReportApplication
    {
        private readonly ITravelReportServiceBll _TravelReportServiceBll;
        public TravelReportApplication(ITravelReportServiceBll TrService)
        {
            _TravelReportServiceBll = TrService;
        }

        //退票
        public TravelReportFltRefundFltModResponseViewModel GetTravelReport_FltRefund(TravelReportRequestUIModel request)
        {
            TravelReportRequestDoModel requestmodel = Mapper.Map<TravelReportRequestUIModel, TravelReportRequestDoModel>(request);
            List<TravelReportFltRefundFltModModel> modelList = _TravelReportServiceBll.GetTravelReportFltRefund(requestmodel);
            List<TravelReportFltRefundFltModViewModel> viewList = Mapper.Map<List<TravelReportFltRefundFltModModel>, List<TravelReportFltRefundFltModViewModel>>(
       modelList).ToList();

            return new TravelReportFltRefundFltModResponseViewModel() { TravelReportFltRefundFltModList = viewList };
        }
        //改签
        public TravelReportFltRefundFltModResponseViewModel GetTravelReport_FltMod(TravelReportRequestUIModel request)
        {
            TravelReportRequestDoModel requestmodel = Mapper.Map<TravelReportRequestUIModel, TravelReportRequestDoModel>(request);
            List<TravelReportFltRefundFltModModel> modelList = _TravelReportServiceBll.GetTravelReportFltMod(requestmodel);
            List<TravelReportFltRefundFltModViewModel> viewList = Mapper.Map<List<TravelReportFltRefundFltModModel>, List<TravelReportFltRefundFltModViewModel>>(
       modelList).ToList();

            return new TravelReportFltRefundFltModResponseViewModel() { TravelReportFltRefundFltModList = viewList };
        }
        //返回汇总页面条数
        public TravelReportCountDataResponseViewModel GetTravelReport_CountData(TravelReportCountDataRequestViewModel request)
        {
            List<TravelReportCountDataModel> modelList = _TravelReportServiceBll.GetTravelReportCountData(request.corpid,request.TheYear);
            List<TravelReportCountDataViewModel> viewList = Mapper.Map<List<TravelReportCountDataModel>, List<TravelReportCountDataViewModel>>(
       modelList).ToList();

            return new TravelReportCountDataResponseViewModel() { TravelReportCountDataList = viewList }; 
        }
        //返回全航司优惠输出表
        public TravelReportAirConsumeCountTableResponseViewModel GetTravelReport_AirConsumeCountTable(TravelReportRequestUIModel request)
        {
            TravelReportRequestDoModel requestmodel = Mapper.Map<TravelReportRequestUIModel, TravelReportRequestDoModel>(
      request);
            List<TravelReportAirConsumeCountTableModel> modelList = _TravelReportServiceBll.GetTravelReportAirConsumeCountTable(requestmodel);

            List<TravelReportAirConsumeCountTableViewModel> viewList = Mapper.Map<List<TravelReportAirConsumeCountTableModel>, List<TravelReportAirConsumeCountTableViewModel>>(
            modelList).ToList();

            return new TravelReportAirConsumeCountTableResponseViewModel() { TravelReportAirlineCountList = viewList };
        }
        //汇总页面
        public TravelReportYearPriceCountResponseViewModel GetTravelReport_YearPriceCount(TravelReportRequestUIModel request)
        {
            TravelReportRequestDoModel requestmodel = Mapper.Map<TravelReportRequestUIModel, TravelReportRequestDoModel>(
       request);
            List<TravelReportYearPriceCountModel> modelList = _TravelReportServiceBll.GetTravelReportYearPriceCount(requestmodel);
            List<TravelReportYearPriceCountViewModel> viewList = Mapper.Map<List<TravelReportYearPriceCountModel>, List<TravelReportYearPriceCountViewModel>>(
            modelList).Take(10).ToList();

            return new TravelReportYearPriceCountResponseViewModel() { TravelReportYearPriceCountList = viewList };
        }
        //汇总页面
        public TravelReportConsumeCountResponseViewModel GetTravelReport_ConsumeCount(TravelReportRequestUIModel request)
        {
            TravelReportRequestDoModel requestmodel = Mapper.Map<TravelReportRequestUIModel, TravelReportRequestDoModel>(
request);
            List<TravelReportConsumeCountModel> modelList = _TravelReportServiceBll.GetTravelReportConsumeCount(requestmodel);
            List<TravelReportConsumeCountViewModel> viewList = Mapper.Map<List<TravelReportConsumeCountModel>, List<TravelReportConsumeCountViewModel>>(
            modelList).ToList();

            return new TravelReportConsumeCountResponseViewModel() { TravelReportConsumeCountList = viewList };
        }
        //年享受航司协议节省金额
        public TravelReportConsumeCountResponseViewModel GetTravelReport_AirConsumeCount(TravelReportRequestUIModel request)
        {
            TravelReportRequestDoModel requestmodel = Mapper.Map<TravelReportRequestUIModel, TravelReportRequestDoModel>(
request);
            List<TravelReportConsumeCountModel> modelList = _TravelReportServiceBll.GetTravelReportAirConsumeCount(requestmodel);
            List<TravelReportConsumeCountViewModel> viewList = Mapper.Map<List<TravelReportConsumeCountModel>, List<TravelReportConsumeCountViewModel>>(
            modelList).Take(10).ToList();

            return new TravelReportConsumeCountResponseViewModel() { TravelReportConsumeCountList = viewList };
        }
        //预定提前天数占比 
        public TravelReportReserveDayResponseViewModel GetTravelReport_ReserveDay(TravelReportRequestUIModel request)
        {
            TravelReportRequestDoModel requestmodel = Mapper.Map<TravelReportRequestUIModel, TravelReportRequestDoModel>(
            request);
            List<TravelReportReserveDayModel> modelList = _TravelReportServiceBll.GetTravelReportReserveDay(requestmodel);
            List<TravelReportReserveDayViewModel> viewList = Mapper.Map<List<TravelReportReserveDayModel>, List<TravelReportReserveDayViewModel>>(
            modelList);
            if (modelList.Count > 0)
            {
                int manCount = 0;
                decimal salepriceCount = 0;
                for (int i = 0; i < modelList.Count; i++)
                {
                    manCount += modelList[i].manNum;
                    salepriceCount = modelList[i].SalePriceSum;

                }
                for (int i = 0; i < viewList.Count; i++)
                {
                    double percent = Convert.ToDouble(modelList[i].manNum) / Convert.ToDouble(manCount);
                    decimal result = Convert.ToDecimal((percent * 100).ToString("0.00"));
                    double saleprice = Convert.ToDouble(modelList[i].SalePriceSum) / Convert.ToDouble(salepriceCount);
                    decimal result1 = Convert.ToDecimal((saleprice * 100).ToString("0.00"));
                    viewList[i].ManPercentage = result;
                    viewList[i].moneyPercentage = result1;
                }
            }
            return new TravelReportReserveDayResponseViewModel() { TravelReportReserveDayList = viewList };
        }
        //前10位人员出差人次汇总表
        public TravelReportPassengerTopResponseViewModel GetTravelReport_PassengerTop(TravelReportRequestUIModel request)
        {
            TravelReportRequestDoModel requestmodel = Mapper.Map<TravelReportRequestUIModel, TravelReportRequestDoModel>(
 request);
            List<TravelReportPassengerTopModel> modelList = _TravelReportServiceBll.GetTravelReportPassengerTop(requestmodel);
            List<TravelReportPassengerTopViewModel> viewList = Mapper.Map<List<TravelReportPassengerTopModel>, List<TravelReportPassengerTopViewModel>>(
            modelList).Take(10).OrderByDescending(x=>x.manNum).ToList();

            return new TravelReportPassengerTopResponseViewModel() { TravelReportPassengerTopList = viewList };
        }
        //前10条出差航段汇总表
        public TravelReportDportCityResponseViewModel GetTravelReport_DportCity(TravelReportRequestUIModel request)
        {
            TravelReportRequestDoModel requestmodel = Mapper.Map<TravelReportRequestUIModel, TravelReportRequestDoModel>(
request);
            List<TravelReportDportCityModel> modelList = _TravelReportServiceBll.GetTravelReportDportCity(requestmodel);
            List<TravelReportDportCityViewModel> viewList = Mapper.Map<List<TravelReportDportCityModel>, List<TravelReportDportCityViewModel>>(
            modelList).Take(10).ToList();

            return new TravelReportDportCityResponseViewModel() { TravelReportDportCityList = viewList };
        }
        //全航司折扣舱位 
        public TravelReportAllSalePriceResponseViewModel GetTravelReport_AllSalePrice(TravelReportRequestUIModel request)
        {
            TravelReportRequestDoModel requestmodel = Mapper.Map<TravelReportRequestUIModel, TravelReportRequestDoModel>(
request);
            List<TravelReportAllSalePriceModel> modelList = _TravelReportServiceBll.GetTravelReportAllSalePrice(requestmodel);
            List<TravelReportAllSalePriceViewModel> viewList = Mapper.Map<List<TravelReportAllSalePriceModel>, List<TravelReportAllSalePriceViewModel>>(
            modelList);
            if (modelList.Count > 0)
            {
                int manCount = 0;
                for (int i = 0; i < modelList.Count; i++)
                {
                    manCount += modelList[i].manNum;
                }
                for (int i = 0; i < viewList.Count; i++)
                {
                    double percent = Convert.ToDouble(modelList[i].manNum) / Convert.ToDouble(manCount);
                    decimal result = Convert.ToDecimal((percent * 100).ToString("0.00"));
                    viewList[i].salePercentage = result;
                }
            }
            return new TravelReportAllSalePriceResponseViewModel() { TravelReportAllSalePriceList = viewList };
        }
        //分类航司
        public TravelReportSalePriceResponseViewModel GetTravelReport_SalePrice(TravelReportRequestUIModel request)
        {
            TravelReportRequestDoModel requestmodel = Mapper.Map<TravelReportRequestUIModel, TravelReportRequestDoModel>(
request);
            List<TravelReportSalePriceModel> modelList = _TravelReportServiceBll.GetTravelReportSalePrice(requestmodel);
            List<TravelReportSalePriceViewModel> viewList = Mapper.Map<List<TravelReportSalePriceModel>, List<TravelReportSalePriceViewModel>>(
            modelList);
            if (modelList.Count > 0)
            {
                int manCount = 0;
                for (int i = 0; i < modelList.Count; i++)
                {
                    manCount += modelList[i].manNum;
                }
                for (int i = 0; i < viewList.Count; i++)
                {
                    double percent = Convert.ToDouble(modelList[i].manNum) / Convert.ToDouble(manCount);
                    decimal result = Convert.ToDecimal((percent * 100).ToString("0.00"));
                    viewList[i].salePercentage = result;
                }
            }
            return new TravelReportSalePriceResponseViewModel() { TravelReportSalePriceList = viewList };
        }
        
        //成本中心汇总表 
        public TravelReportCostCenterResponseViewModel GetTravelReport_CostCenter(TravelReportRequestUIModel request)
        {
            TravelReportRequestDoModel requestmodel = Mapper.Map<TravelReportRequestUIModel, TravelReportRequestDoModel>(
request);
            List<TravelReportCostCenterModel> modelList = _TravelReportServiceBll.GetTravelReportCostCenter(requestmodel);
            List<TravelReportCostCenterViewModel> viewList = Mapper.Map<List<TravelReportCostCenterModel>, List<TravelReportCostCenterViewModel>>(
            modelList).OrderByDescending(x => x.SalePriceSum).Take(6).ToList(); ;

            return new TravelReportCostCenterResponseViewModel() { TravelReportCostCenterList = viewList };
        }
        //航空公司占比分析
        public TravelReportAirlineCountResponseViewModel GetTravelReport_AirlineCount(TravelReportRequestUIModel request)
        {
            TravelReportRequestDoModel requestmodel = Mapper.Map<TravelReportRequestUIModel, TravelReportRequestDoModel>(
request);
            List < TravelReportAirlineCountModel > modelListTemp= _TravelReportServiceBll.GetTravelReportAirlineCount(requestmodel);
            List<string> airlineNoList = modelListTemp.Select(n => n.AirlineNo).Distinct().ToList();
            List<TravelReportAirlineCountModel> modelList = new List<TravelReportAirlineCountModel>();
            //合并重复的航段
            decimal s = 0;
            int m = 0;
            TravelReportAirlineCountModel other = null;
            foreach (string airlineNo in airlineNoList)
            {
               
                if (airlineNo!= "其它航空")
                {
                    var model = modelListTemp.Find(n => n.AirlineNo == airlineNo);
                    if (model == null)
                        continue;
                    modelList.Add(model);
                }
                else
                {

                    List< TravelReportAirlineCountModel> model = modelListTemp.FindAll(n => n.AirlineNo == airlineNo);
                    
                    if (model != null && model.Count > 0)
                    {
                        s = model.Sum(n => n.SalePriceSum);
                        m = model.Sum(n => n.manNum);
                        if (other == null)
                            other = model[0];
                    }
                }
            }

            if (other != null)
            {
                other.manNum = m;
                other.SalePriceSum = s;
                modelList.Add(other);
            }


            List<TravelReportAirlineCountViewModel> viewList = Mapper.Map<List<TravelReportAirlineCountModel>, List<TravelReportAirlineCountViewModel>>(
            modelList);

            if (modelList.Count > 0)
            {
                int manCount = 0;
                for (int i = 0; i < modelList.Count; i++)
                {
                    manCount += modelList[i].manNum;
                }
                for (int i = 0; i < viewList.Count; i++)
                {
                    double percent = Convert.ToDouble(modelList[i].manNum) / Convert.ToDouble(manCount);
                    decimal result = Convert.ToDecimal((percent * 100).ToString("0.00"));
                    viewList[i].ManPercentage = result;
                }
            }

            return new TravelReportAirlineCountResponseViewModel() { TravelReportAirlineCountList = viewList };

        }

      

    }
}
