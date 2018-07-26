using AutoMapper;
using Mzl.BLL.Flight.IBEService;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;

namespace Mzl.BLL.Flight.MapperConfig
{
    public class FlightMapperCofig: IMapperConfig
    {
        public void InitializeConfig(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Flt_SearchFlightModel, SearchFlightModel>();
            cfg.CreateMap<Flt_SearchFlightDetailModel, SearchFlightDetailModel>();
        }
    }
}
