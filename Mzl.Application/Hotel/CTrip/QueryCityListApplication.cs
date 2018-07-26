using AutoMapper;
using Mzl.DomainModel.Hotel.CTrip.City;
using Mzl.Framework.Base;
using Mzl.IApplication.Hotel.CTrip;
using Mzl.IBll.Hotel.CtripHotel;
using Mzl.UIModel.Hotel.CTrip.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Application.Hotel.CTrip
{
    internal class QueryCityListApplication : BaseApplicationService, IQueryCityListApplication
    {
        private readonly IQueryCityInofCNBll _queryCityInofCN;

        public QueryCityListApplication(IQueryCityInofCNBll queryCityInofCN)
        {
            _queryCityInofCN = queryCityInofCN;
        }
        public CountryViewModel QueryCityList()
        {
            Country responseModel = _queryCityInofCN.Query();

            return Mapper.Map<Country, CountryViewModel>(responseModel);
        }
    }
}
