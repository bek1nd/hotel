using AutoMapper;
using Mzl.Bll.Hotel.CtripHotel;
using Mzl.DomainModel.Hotel.CTrip.City;
using Mzl.Framework.Base;
using Mzl.IApplication.CTripHotel;
using Mzl.IBll.Hotel.CtripHotel;
using Mzl.UIModel.Hotel.CTrip.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Application.CTripHotel
{
    public class QueryCityCNApplication : BaseApplicationService, IQueryCityCNApplication
    {
        private readonly IQueryCityInofCNBll _queryCityInofCN;


        public QueryCityCNApplication(IQueryCityInofCNBll queryCityInofCN) {
            _queryCityInofCN = queryCityInofCN;
        }

        public CountryViewModel Query()
        {
            var country = _queryCityInofCN.Query();
            return Mapper.Map<Country, CountryViewModel>(country);
        }
    }
}
