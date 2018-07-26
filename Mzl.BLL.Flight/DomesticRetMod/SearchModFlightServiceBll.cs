using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    internal class SearchModFlightServiceBll : BaseServiceBll, ISearchFlightServiceBll
    {
        

        public List<SearchFlightModel> SearchFlight(SearchFlightQueryModel query)
        {
            //改签
            ISearchFlightServiceBll ibeSearch = new SearchIBEFlightBll();//IBE航班信息
            ISearchFlightServiceBll individuationFlightSearch = new SearchIndividuationFlightBll(ibeSearch);
            SearchContainModPolicyFlightBll searchFlight=new SearchContainModPolicyFlightBll(individuationFlightSearch);
            ISearchFlightServiceBll shareFlightNoSearch = new SearchShareFlightNoFlightBll(searchFlight);//共享航班逻辑
            return shareFlightNoSearch.SearchFlight(query);
        }
    }
}
