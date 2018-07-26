using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Flight;
using Mzl.UIModel.Flight;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.AutoMapperHelper;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.IBLL.Customer.Customer.BLL;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Customer.Passenger;
using Mzl.IBLL.Customer.Customer;

namespace Mzl.Application.Flight
{
    /// <summary>
    /// 查询航班应用层
    /// </summary>
    internal class SearchFlightApplication : BaseApplicationService, ISearchFlightApplication
    {
        private readonly ISearchFlightServiceBll _searchFlightServiceBll;
        private readonly IGetCustomerCorpPolicyServiceBll _getCustomerCorpPolicyServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IGetPassengerServiceBll _getPassengerServiceBll;

        public SearchFlightApplication(ISearchFlightServiceBll searchFlightServiceBll,
            IGetCustomerCorpPolicyServiceBll getCustomerCorpPolicyServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll, IGetPassengerServiceBll getPassengerServiceBll) : base()
        {
            _searchFlightServiceBll = searchFlightServiceBll;
            _getCustomerCorpPolicyServiceBll = getCustomerCorpPolicyServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _getPassengerServiceBll = getPassengerServiceBll;
        }

        public SearchFlightResponseViewModel Search(SearchFlightRequestViewModel request)
        {
            if(request.Cid==0)
                throw new Exception("请传入客户Id");

            //2.根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);

            //调用查询该客户的差旅政策服务
            CorpPolicyDetailConfigModel poilConfigModel =
                _getCustomerCorpPolicyServiceBll.GetCorpPolicyById(request.PolicyId ?? 0, customerModel.CorpID,"N");

            SearchFlightQueryModel query = new SearchFlightQueryModel()
            {
                AirlineNo = request.AirlineNo,
                Aport = request.Aport,
                TackOffTime = request.TackOffTime,
                Dport = request.Dport,
                CorpPolicy = poilConfigModel,
                CardNoList = request.CardNoList,
                PassengerNameList = request.PassengerNameList,
                CorpId = customerModel.CorpID,
                OrderSource = request.OrderSource,
                IsShareFly = customerModel.Corporation.IsShareFly,
                IsXYPrice = customerModel.Corporation.IsXYPrice,
                IsAllSeat = customerModel.Corporation.IsAllSeat,
                IsHeightSeat = customerModel.Corporation.IsHeightSeat
            };

            //调用查询航班服务
            List<SearchFlightModel> searchFlightModels =  _searchFlightServiceBll.SearchFlight(query);

            SearchFlightResponseViewModel viewModel = new SearchFlightResponseViewModel();
            viewModel.FlightList = Mapper.Map<List<SearchFlightModel>, List<SearchFlightViewModel>>(searchFlightModels);
            viewModel.AirlineQuery = searchFlightModels.Select(n => n.AirlineDesc).Distinct().ToList();
            viewModel.AportNameQuery = searchFlightModels.Select(n => n.AportName).Distinct().ToList();
            viewModel.DportNameQuery = searchFlightModels.Select(n => n.DportName).Distinct().ToList();
            viewModel.TackOffTimeQuery = searchFlightModels.Select(n => n.TackOffDate).Distinct().ToList();
            viewModel.ClassQuery = searchFlightModels.SelectMany(n => n.DetailList).Select(n => n.ClassDesc).Distinct().ToList();
            viewModel.PolicyReason = poilConfigModel?.PolicyReason;
            return viewModel;
        }
    }
}
