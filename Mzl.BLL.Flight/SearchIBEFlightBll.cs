using AutoMapper;
using Mzl.BLL.Flight.IBEService;
using Mzl.DomainModel.Flight;
using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight
{
    /// <summary>
    /// 查询IBE接口信息
    /// </summary>
    public class SearchIBEFlightBll : ISearchFlightServiceBll
    {
        private readonly SearchFlightSoapClient _searchFlightSoap =new SearchFlightSoapClient();
        public List<SearchFlightModel> SearchFlight(SearchFlightQueryModel query)
        {
            List < SearchFlightModel > flightModels=new List<SearchFlightModel>();
            try
            {
                List<Flt_SearchFlightModel> ibeFlightModels = null;
                List<Flt_SearchFlightModel> list = new List<Flt_SearchFlightModel>();
                if (query.OrderSource == "O")
                {
                    ibeFlightModels = _searchFlightSoap.SearchFiightOffLine(query.Dport, query.Aport,
                        query.TackOffTime.ToString("yyyy-MM-dd"),
                        query.AirlineNo, query.CorpId).ToList();
                }
                else
                {
                    ibeFlightModels = _searchFlightSoap.SearchFiight(query.Dport, query.Aport,
                   query.TackOffTime.ToString("yyyy-MM-dd"),
                   query.AirlineNo, query.CorpId).ToList();
                }

                flightModels = Mapper.Map<List<Flt_SearchFlightModel>, List<SearchFlightModel>>(ibeFlightModels);

            }
            catch (Exception ex)
            {

            }
            return flightModels;
        }
    }
}
