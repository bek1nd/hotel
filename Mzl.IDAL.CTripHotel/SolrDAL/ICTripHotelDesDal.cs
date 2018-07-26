using Mzl.EntityModel.Hotel.CTripHotel.SolrModel;
using Mzl.EntityModel.Proxy.CTripHotel;
using Mzl.EntityModel.Proxy.CTripHotel.HotelDesInfo;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.CTripHotel.SolrDAL
{
    public interface ICTripHotelDesDal
    {
        void AddHotelToSolr(HotelSolrModel hotelDes,string coreName);
        HotelStaticInfo QueryById(int id,string coreName);
        IList<KeyWordHotel> GetKeyWordHotel(int cityCode);
        SolrQueryResults<HotelSimpleInfoSolrModel> GetHotelSimple(string cityCode,QueryOptions op);
        SolrQueryResults<HotelOriginalInfoSolrModel> GetHotelOriginal(string cityCode, QueryOptions op);
        SolrQueryResults<HotelOriginalInfoSolrModel> GetHotelById(string hotelId, QueryOptions op);
    }
}
