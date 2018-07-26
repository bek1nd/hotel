using Mzl.Common.EnumHelper;
using Mzl.Common.Exceptions;
using Mzl.IApplication.Customer;
using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Customer.Customer;
using Mzl.UIModel.Customer.TravelReport;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    public class TravelReportController : ApiController
    {
        public readonly ITravelReportApplication _TravelReportApplication;
        
        public TravelReportController(ITravelReportApplication TravelReportApplication)
        {
            _TravelReportApplication = TravelReportApplication;
        }
        //退改签
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportFltRefundFltModResponseViewModel>> GetTravelReportFltRefund([FromBody]TravelReportRequestUIModel request)
        {

            TravelReportFltRefundFltModResponseViewModel viewModel = new TravelReportFltRefundFltModResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_FltRefund(request);
            });

            ResponseBaseViewModel<TravelReportFltRefundFltModResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportFltRefundFltModResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportFltRefundFltModResponseViewModel>> GetTravelReportFltMod([FromBody]TravelReportRequestUIModel request)
        {

            TravelReportFltRefundFltModResponseViewModel viewModel = new TravelReportFltRefundFltModResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_FltMod(request);
            });

            ResponseBaseViewModel<TravelReportFltRefundFltModResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportFltRefundFltModResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        //汇总页面订单条数统计
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportCountDataResponseViewModel>> GetTravelReportCountData([FromBody]TravelReportCountDataRequestViewModel request)
        {
        
            TravelReportCountDataResponseViewModel viewModel = new TravelReportCountDataResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_CountData(request);
            });

            ResponseBaseViewModel<TravelReportCountDataResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportCountDataResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        //汇总页面
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportYearPriceCountResponseViewModel>> GetYearPriceCount([FromBody]TravelReportRequestUIModel request)
        {
            request.Cid = this.GetCid();
            TravelReportYearPriceCountResponseViewModel viewModel = new TravelReportYearPriceCountResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_YearPriceCount(request);
            });

            ResponseBaseViewModel<TravelReportYearPriceCountResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportYearPriceCountResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportConsumeCountResponseViewModel>> GetConsumeCount([FromBody]TravelReportRequestUIModel request)
        {
            request.Cid = this.GetCid();
            TravelReportConsumeCountResponseViewModel viewModel = new TravelReportConsumeCountResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_ConsumeCount(request);
            });

            ResponseBaseViewModel<TravelReportConsumeCountResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportConsumeCountResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        //年享受航司协议节省金额
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportConsumeCountResponseViewModel>> GetAirConsumeCount([FromBody]TravelReportRequestUIModel request)
        {
            request.Cid = this.GetCid();
            TravelReportConsumeCountResponseViewModel viewModel = new TravelReportConsumeCountResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_ConsumeCount(request);
            });

            ResponseBaseViewModel<TravelReportConsumeCountResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportConsumeCountResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        //年享受航司协议节省金额Table
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportAirConsumeCountTableResponseViewModel>> GetAirConsumeCountTable([FromBody]TravelReportRequestUIModel request)
        {
            request.Cid = this.GetCid();
            TravelReportAirConsumeCountTableResponseViewModel viewModel = new TravelReportAirConsumeCountTableResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_AirConsumeCountTable(request);
            });

            ResponseBaseViewModel<TravelReportAirConsumeCountTableResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportAirConsumeCountTableResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        //预定提前天数占比 
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportReserveDayResponseViewModel>> GetReserveDay([FromBody]TravelReportRequestUIModel request)
        {
            request.Cid = this.GetCid();
            TravelReportReserveDayResponseViewModel viewModel = new TravelReportReserveDayResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_ReserveDay(request);
            });

            ResponseBaseViewModel<TravelReportReserveDayResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportReserveDayResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        //前10位人员出差人次汇总表
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportPassengerTopResponseViewModel>> GetPassengerTop([FromBody]TravelReportRequestUIModel request)
        {
            request.Cid = this.GetCid();
            TravelReportPassengerTopResponseViewModel viewModel = new TravelReportPassengerTopResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_PassengerTop(request);
            });

            ResponseBaseViewModel<TravelReportPassengerTopResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportPassengerTopResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        //前10条出差航段汇总表
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportDportCityResponseViewModel>> GetDportCity([FromBody]TravelReportRequestUIModel request)
        {
            request.Cid = this.GetCid();
            TravelReportDportCityResponseViewModel viewModel = new TravelReportDportCityResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_DportCity(request);
            });

            ResponseBaseViewModel<TravelReportDportCityResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportDportCityResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        //全航司折扣舱位
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportAllSalePriceResponseViewModel>> GetAllSalePrice([FromBody]TravelReportRequestUIModel request)
        {
            request.Cid = this.GetCid();
            TravelReportAllSalePriceResponseViewModel viewModel = new TravelReportAllSalePriceResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_AllSalePrice(request);
            });

            ResponseBaseViewModel<TravelReportAllSalePriceResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportAllSalePriceResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportSalePriceResponseViewModel>> GetSalePrice([FromBody]TravelReportRequestUIModel request)
        {
            request.Cid = this.GetCid();
            TravelReportSalePriceResponseViewModel viewModel = new TravelReportSalePriceResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_SalePrice(request);
            });

            ResponseBaseViewModel<TravelReportSalePriceResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportSalePriceResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
  
        //成本中心汇总表 
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportCostCenterResponseViewModel>> GetCostCenter([FromBody]TravelReportRequestUIModel request)
        {
            request.Cid = this.GetCid();
            TravelReportCostCenterResponseViewModel viewModel = new TravelReportCostCenterResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_CostCenter(request);
            });

            ResponseBaseViewModel<TravelReportCostCenterResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportCostCenterResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        //航空公司占比分析
        [HttpPost]
        public async Task<ResponseBaseViewModel<TravelReportAirlineCountResponseViewModel>> GetAirlineCount([FromBody]TravelReportRequestUIModel request)
        {
            request.Cid = this.GetCid();
            TravelReportAirlineCountResponseViewModel viewModel = new TravelReportAirlineCountResponseViewModel();
            await new TaskFactory().StartNew(() =>
            {
                viewModel = _TravelReportApplication.GetTravelReport_AirlineCount(request);
            });

            ResponseBaseViewModel<TravelReportAirlineCountResponseViewModel> v = new ResponseBaseViewModel
                <TravelReportAirlineCountResponseViewModel>
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        //年享受航司协议价格节省价格

    }
}