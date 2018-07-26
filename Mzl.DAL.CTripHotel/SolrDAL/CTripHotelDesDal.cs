using Mzl.Common.JsonHelper;
using Mzl.EntityModel.Hotel.CTripHotel.SolrModel;
using Mzl.EntityModel.Proxy.CTripHotel;
using Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo;
using Mzl.IDAL.CTripHotel.SolrDAL;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DAL.CTripHotel.SolrDAL
{
    public class CTripHotelDesDal:ICTripHotelDesDal
    {

        public void AddHotelToSolr(HotelSolrModel hotel,string coreName)
        {

            SolrApi.Add(hotel,coreName);
        }
        public void AddHotelsToSolr(List<HotelSolrModel> hotels,string coreName)
        {
            SolrApi.Adds(hotels,coreName);
        }
        public IList<KeyWordHotel> GetKeyWordHotel(int cityCode)
        {
            return SolrApi.Query<KeyWordHotel>("citycode:"+ cityCode,null,"testsolr2").Select(c => new KeyWordHotel
            {
                HotelId = c.HotelId,
                HotelName = c.HotelName,
                CityName = c.CityName,
                CityCode = c.CityCode,
                AreaName = c.AreaName,
                AreaCode = c.AreaCode,
                BusinessDistrict = c.BusinessDistrict,
                HotelBrandName = c.HotelBrandName,
                HotelBrandCode = c.HotelBrandCode
            }).ToList();
        }
        public HotelStaticInfo QueryById(int id,string coreName)
        {
            var hotelStaticInfo = new HotelStaticInfo();
            var solrQueryResults=SolrApi.Query<HotelSolrModel>("id:" + id,null,coreName);
            foreach (var solrQueryResult in solrQueryResults)
            {
                hotelStaticInfo = JsonHelper.DeserializeJsonToObject<HotelStaticInfo>(solrQueryResult.Value);
            }
            return hotelStaticInfo;
        }

        public SolrQueryResults<HotelSimpleInfoSolrModel> GetHotelSimple(string cityCode,QueryOptions op)
        {
            return SolrApi.Query<HotelSimpleInfoSolrModel>("*:*", op,"hotelsimple");
        }

        public SolrQueryResults<HotelOriginalInfoSolrModel> GetHotelOriginal(string cityCode,QueryOptions op)
        {
            return SolrApi.Query<HotelOriginalInfoSolrModel>("*:*",op, "originalhotel");
        }

        public SolrQueryResults<HotelOriginalInfoSolrModel> GetHotelById(string hotelId, QueryOptions op)
        {
            return SolrApi.Query<HotelOriginalInfoSolrModel>("id:"+ hotelId, op, "originalhotel");
        }
    }
}
