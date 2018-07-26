using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight
{
    public class SearchFlightServiceBll : BaseServiceBll, ISearchFlightServiceBll
    {
        private readonly ICheckPassengerIsInWhiteListBll _checkPassengerIsInWhiteListBll;

        public SearchFlightServiceBll(ICheckPassengerIsInWhiteListBll checkPassengerIsInWhiteListBll)
        {
            _checkPassengerIsInWhiteListBll = checkPassengerIsInWhiteListBll;
        }

        public List<SearchFlightModel> SearchFlight(SearchFlightQueryModel query)
        {
            ISearchFlightServiceBll ibeSearch = new SearchIBEFlightBll();//IBE航班信息
            ISearchFlightServiceBll checkWhitelFlightSearch = new SearchCheckWhitelFlightBll(ibeSearch, _checkPassengerIsInWhiteListBll);

            ISearchFlightServiceBll individuationFlightSearch = new SearchIndividuationFlightBll(checkWhitelFlightSearch);

            ISearchFlightServiceBll policyFlightSearch =new SearchContainPolicyFlightBll(individuationFlightSearch);//在IBE航班信息中添加了差旅政策
            ISearchFlightServiceBll shareFlightNoSearch = new SearchShareFlightNoFlightBll(policyFlightSearch);//共享航班逻辑
            return shareFlightNoSearch.SearchFlight(query);
        }
    }
}
