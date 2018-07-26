using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Hotel.CTrip.City
{
    public class Province
    {
        public int Id { get; set; }


        public string Name { get; set; }
        public string ENName { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public List<City> Cities { get; set; }
    }
}
