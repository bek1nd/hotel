using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.Passenger;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Customer.Customer;
using Mzl.UIModel.Passenger;

namespace Mzl.Application.Customer
{
    internal class SearchPassengersApplication: BaseApplicationService,ISearchPassengersApplication
    {
        private readonly IGetPassengerServiceBll _getPassengerServiceBll;

        public SearchPassengersApplication(IGetPassengerServiceBll getPassengerServiceBll)
        {
            _getPassengerServiceBll = getPassengerServiceBll;
        }

        public SearchPassengersResponseViewModel SearchPassengers(SearchPassengersRequestViewModel request)
        {
            List<PassengerInfoModel> passengerInfoModels = _getPassengerServiceBll.GetPassenger(request.Cid,
                request.IsTemporary,
                request.SearchArgs, (request.OrderSource == "O" ? 0 : 1));
            SearchPassengersResponseViewModel viewModel = new SearchPassengersResponseViewModel();
            viewModel.PassengerList = Mapper.Map<List<PassengerInfoModel>, List<PassengerViewModel>>(passengerInfoModels);
            return viewModel;
        }
    }
}
