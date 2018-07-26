using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.AutoMapperHelper;
using Mzl.Common.ConfigHelper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Train.Server;
using Mzl.Framework.Base;
using Mzl.IApplication.Train;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Train.Search;
using Mzl.UIModel.Search;
using Mzl.UIModel.Train.Search;

namespace Mzl.Application.Train
{
    internal class SearchTrainApplication : BaseApplicationService, ISearchTrainApplication
    {
        private readonly ISearchTrainServiceBll _searchTrainServiceBll;
        private readonly IGetCustomerCorpPolicyServiceBll _getCustomerCorpPolicyServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;


        public SearchTrainApplication(ISearchTrainServiceBll searchTrainServiceBll,
            IGetCustomerCorpPolicyServiceBll getCustomerCorpPolicyServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll)
        {
            _searchTrainServiceBll = searchTrainServiceBll;
            _getCustomerCorpPolicyServiceBll = getCustomerCorpPolicyServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
        }

        public SearchTrainResponseViewModel SearchTrain(SearchTrainRequestViewModel request)
        {
            if (request.Cid == 0)
                throw new Exception("请传入客户Id");

            //2.根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);

            string notAllowUserTrainCorpId = AppSettingsHelper.GetAppSettings(AppSettingsEnum.NotAllowUserTrain);

            if (!string.IsNullOrEmpty(customerModel.CorpID) && notAllowUserTrainCorpId.Contains(customerModel.CorpID.ToUpper()))
            {
                throw new Exception("当前公司不能使用火车票功能");
            }

            //调用查询该客户的差旅政策服务
            CorpPolicyDetailConfigModel poilConfigModel =
                _getCustomerCorpPolicyServiceBll.GetCorpPolicyById(request.PolicyId ?? 0, customerModel.CorpID,"T");

            TraQueryTrainModel queryTrainModel = new TraQueryTrainModel()
            {
                from_station = request.FromStation,
                needdistance = request.NeedDistance,
                purpose_codes = request.PurposeCodes,
                to_station = request.ToStation,
                train_date = request.TrainDate,
                CorpPolicy = poilConfigModel,
                CorpId = customerModel.CorpID,
                IsTraAllSeat = customerModel.Corporation == null ? 0 : customerModel.Corporation.IsTraAllSeat

            };

            List < TraTravelInfoModel > traTravelInfoModels= _searchTrainServiceBll.DoQueryTrain(queryTrainModel);
            SearchTrainResponseViewModel responseViewModel = new SearchTrainResponseViewModel();

            List<TraTravelInfoViewModel> travelInfo = new List<TraTravelInfoViewModel>();
            List<string> formStation = new List<string>();
            List<string> toStation = new List<string>();
            List<string> trainType = new List<string>();

            foreach (var item in traTravelInfoModels)
            {
                #region 循环
                if (!string.IsNullOrEmpty(item.train_type))
                {
                    trainType.Add(item.train_type);
                }
                if (!string.IsNullOrEmpty(item.from_station_name))
                {
                    formStation.Add(item.from_station_name);
                }
                if (!string.IsNullOrEmpty(item.to_station_name))
                {
                    toStation.Add(item.to_station_name);
                }
                TraTravelInfoViewModel travelInfoViewModel = new TraTravelInfoViewModel()
                {
                    AccessByidCard = item.access_byidcard,
                    ArriveDays = item.arrive_days,
                    ArriveTime = item.arrive_time,
                    CanBuyNow = item.can_buy_now,
                    DetailList = AutoMapperHelper.DoMapList<TraTravelInfoDetailModel, TraTravelInfoDetailViewModel>(item.DetailList).ToList(),
                    Distance = item.distance,
                    EndStationName = item.end_station_name,
                    FromStationCode = item.from_station_code,
                    FromStationName = item.from_station_name,
                    Note = item.note,
                    RunTime = item.run_time,
                    RunTimeMinute = item.run_time_minute,
                    SaleDateTime = item.sale_date_time,
                    StartStationName = item.start_station_name,
                    StartTime = item.start_time,
                    ToStationCode = item.to_station_code,
                    ToStationName = item.to_station_name,
                    TrainCode = item.train_code,
                    TrainNo = item.train_no,
                    TrainStartDate = Convert.ToDateTime(queryTrainModel.train_date).ToString("yyyy-MM-dd"),//item.train_start_date,
                    TrainType = item.train_type,
                    OnTrainDate= request.TrainDate
                };
                travelInfo.Add(travelInfoViewModel); 
                #endregion
            }

            responseViewModel.TravelInfo = travelInfo;
            responseViewModel.FormStation = formStation.Distinct().ToList();
            responseViewModel.ToStation = toStation.Distinct().ToList();
            responseViewModel.TrainType = trainType.Distinct().ToList();
            responseViewModel.PolicyReason = poilConfigModel?.PolicyReason;
            return responseViewModel;
        }
    }
}
