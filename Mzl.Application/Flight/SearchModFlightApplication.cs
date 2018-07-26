using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Flight;
using Mzl.UIModel.Flight;
using Mzl.DomainModel.Flight;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.IBLL.Customer.Customer;
using Mzl.DomainModel.Customer.Base;

namespace Mzl.Application.Flight
{
    public class SearchModFlightApplication : BaseApplicationService, ISearchModFlightApplication
    {
        private readonly ISearchFlightServiceBll _searchFlightServiceBll;
        private readonly IGetCustomerCorpPolicyServiceBll _getCustomerCorpPolicyServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;

        public SearchModFlightApplication(ISearchFlightServiceBll searchFlightServiceBll, IGetCustomerCorpPolicyServiceBll getCustomerCorpPolicyServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll) : base()
        {
            _searchFlightServiceBll = searchFlightServiceBll;
            _getCustomerCorpPolicyServiceBll = getCustomerCorpPolicyServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
        }

        public SearchModFlightResponseViewModel Search(SearchModFlightRequestViewModel request)
        {
            //2.根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);


            //调用查询该客户的差旅政策服务
            CorpPolicyDetailConfigModel poilConfigModel =
                _getCustomerCorpPolicyServiceBll.GetCorpPolicyById(request.PolicyId ?? 0, customerModel.CorpID, "N");


            //调用查询航班服务
            List<SearchFlightModel> searchFlightModels =
                _searchFlightServiceBll.SearchFlight(new SearchFlightQueryModel()
                {
                    AirlineNo = request.AirlineNo,
                    Aport = request.Aport,
                    TackOffTime = request.TackOffTime,
                    Dport = request.Dport,
                    CorpPolicy = poilConfigModel,
                    CorpId = request.CorpId,
                    Class = request.Class,
                    IsShareFly= customerModel.Corporation.IsShareFly,
                    IsXYPrice = customerModel.Corporation.IsXYPrice,
                    IsAllSeat = customerModel.Corporation.IsAllSeat,
                    IsHeightSeat = customerModel.Corporation.IsHeightSeat
                });

            SearchModFlightResponseViewModel viewModel = new SearchModFlightResponseViewModel();
            viewModel.FlightList = Mapper.Map<List<SearchFlightModel>, List<SearchModFlightViewModel>>(searchFlightModels);
            viewModel.AirlineQuery = searchFlightModels.Select(n => n.AirlineDesc).Distinct().ToList();
            viewModel.AportNameQuery = searchFlightModels.Select(n => n.AportName).Distinct().ToList();
            viewModel.DportNameQuery = searchFlightModels.Select(n => n.DportName).Distinct().ToList();
            viewModel.TackOffTimeQuery = searchFlightModels.Select(n => n.TackOffDate).Distinct().ToList();
            viewModel.ClassQuery = searchFlightModels.SelectMany(n => n.DetailList).Select(n => n.ClassDesc).Distinct().ToList();
            return viewModel;
        }
    }
}
