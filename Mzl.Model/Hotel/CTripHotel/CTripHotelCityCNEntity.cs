using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Hotel.CTripHotel
{
    [Table("CTripHotel_CityCN")]
    public class CTripHotelCityCNEntity
    {
        /// <summary>
        /// 城市ID
        /// </summary>
        [Key]
        [Column("cityid")]
        public int CityId { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [Column("pcityid")]
        public int PCityId { get; set; }

        /// <summary>
        /// 城市名称
        /// </summary>
        [Column("cityname")]
        public string CityName { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [Column("province")]
        public int Province { get; set; }

        /// <summary>
        /// 省名
        /// </summary>
        [Column("provincename")]
        public string ProvinceName { get; set; }
        
        /// <summary>
        /// 国
        /// </summary>
        [Column("country")]
        public int Country { get; set; }
        
        /// <summary>
        /// 国名
        /// </summary>
        [Column("countryname")]
        public string CountryName { get; set; }

        /// <summary>
        /// 当前标记
        /// </summary>
        [Column("currentflag")]
        public string CurrentFlag { get; set; }
    }
}
