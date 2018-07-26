using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Hotel.CTrip.Hotel
{
    public class GeoInfo
    {
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string AdjacentIntersection { get; set; }
        public City City { get; set; }
        public Area Area { get; set; }
        public IList<BusinessDistrict> BusinessDistrict { get; set; }
        public IList<Coordinate> Coordinates { get; set; }
    }
}
